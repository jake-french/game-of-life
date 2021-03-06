﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_of_life {
    /// <summary>
    /// MainWindow GUI class displaying the cell grid and handling GUI events.
    /// </summary>
    public partial class MainWindow : Form {
        //Variables
        private Simulation simulation;
        private bool reDrawGrid = true;

        private bool validHCell, validVCell, validTurnTimer;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Clears grid and redraws based off values of on-screen sliders.
        /// </summary>
        private void CreateGrid() {
            if (reDrawGrid) {
                reDrawGrid = false;

                //Check Sliders take new Text Values
                try {
                    int tempCols = Int32.Parse(Txt_HCells.Text);
                    int tempRows = Int32.Parse(Txt_VCells.Text);

                    System.Diagnostics.Debug.WriteLine("Values: " + tempCols + " : " + tempRows);

                    //Overwrite Slider count based of text value
                    if (TrBar_HCells.Value != tempCols) {
                        TrBar_HCells.Value = tempCols;
                    }
                    if (TrBar_VCells.Value != tempRows) {
                        TrBar_VCells.Value = tempRows;
                    }
                } catch (FormatException fe) {
                    reDrawGrid = true;
                    System.Diagnostics.Debug.WriteLine(fe.Message);
                    return;
                }

                int cols = TrBar_HCells.Value;
                int rows = TrBar_VCells.Value;

                //Hide Grid during Redraw
                Tbl_Grid.SuspendLayout();
                Tbl_Grid.Visible = false;
                TrBar_HCells.Enabled = false;
                TrBar_VCells.Enabled = false;
                Btn_Start.Enabled = false;
                Tbl_Grid.ColumnStyles.Clear();
                Tbl_Grid.RowStyles.Clear();
                Tbl_Grid.Controls.Clear();

                Tbl_Grid.ColumnCount = cols + 2;
                Tbl_Grid.RowCount = rows + 2;

                //Reset Cell List
                Cell.ResetCells();

                //Populate Buttons
                for (int x = 0; x < cols + 1; x++) {        //foreach column
                    for (int y = 0; y < rows + 1; y++) {        //foreach row
                        if (x != 0 && y != 0) {
                            //Creates Cell button
                            Tbl_Grid.Controls.Add(new Cell(x, y), x, y);
                        } else {
                            if (x == 0 && y != 0) {
                                //Y-Axis Label
                                Tbl_Grid.Controls.Add(new Label() {
                                    Font = new Font("Arial", 7, FontStyle.Bold),
                                    Text = "" + y,
                                    TextAlign = ContentAlignment.MiddleCenter
                                }, x, y);
                            } else if (y == 0 && x != 0) {
                                //X-Axis Label
                                Tbl_Grid.Controls.Add(new Label() {
                                    Font = new Font("Arial", 7, FontStyle.Bold),
                                    Text = "" + x,
                                    TextAlign = ContentAlignment.MiddleCenter
                                }, x, y);
                            } else {
                                Tbl_Grid.Controls.Add(new Label(), x, y);
                            }
                        }
                        Tbl_Grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 24f));
                        Tbl_Grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 24f));
                    }
                }

                //Displays grid upon drawing finished
                Tbl_Grid.ResumeLayout();
                Tbl_Grid.Visible = true;
                TrBar_HCells.Enabled = true;
                TrBar_VCells.Enabled = true;
                Btn_Start.Enabled = true;

                reDrawGrid = true;
            }
        }

        /// <summary>
        /// Sets the control for player interaction of certain objects based of parameter value.
        /// </summary>
        /// <param name="enabled">Enabled state for objects.</param>
        private void EnableComponents(bool enabled) {
            TrBar_HCells.Enabled = enabled;
            TrBar_VCells.Enabled = enabled;
            TrBar_Timer.Enabled = enabled;

            //Txt_HCells.Enabled = enabled;
            //Txt_VCells.Enabled = enabled;
            //Txt_Timer.Enabled = enabled;

        }

        /// <summary>
        /// Window Load Event Handler
        /// </summary>
        /// <param name="sender">Object sending the event.</param>
        /// <param name="e">Event Arguments.</param>
        private void MainWindow_Load(object sender, EventArgs e) {
            Tbl_Grid.RowCount = 0;
            Tbl_Grid.ColumnCount = 0;

            CreateGrid();

            //Binds the text value to equal the value of Sliders.
            Txt_HCells.DataBindings.Add(new Binding("Text", TrBar_HCells, "Value"));
            Txt_VCells.DataBindings.Add(new Binding("Text", TrBar_VCells, "Value"));
            Txt_Timer.DataBindings.Add(new Binding("Text", TrBar_Timer, "Value"));

            //Failsafe - Strict Validation
            Txt_HCells.Enabled = false;
            Txt_VCells.Enabled = false;
            Txt_Timer.Enabled = false;

            simulation = Simulation.Instance;
            simulation.AssignProgressBar(PBar_TurnTimer);

            //Add LostFocus Event Handlers
            Txt_HCells.LostFocus += CellCountValueChanged;
            Txt_VCells.LostFocus += CellCountValueChanged;
        }

        /// <summary>
        /// Start Button Event Handler
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Event Arguments.</param>
        private void Btn_Start_Click(object sender, EventArgs e) {
            simulation.SetTurnTime(TrBar_Timer.Value);
            if (validHCell && validVCell && validTurnTimer && simulation.Seconds != -1) {
                if (!simulation.IsRunning) {
                    simulation.SetTurnTime(TrBar_Timer.Value);
                    simulation.Run();       //Commences the Simulation

                    Btn_Start.Text = "Pause";
                    Btn_Stop.Enabled = true;
                    EnableComponents(false);
                } else {
                    if (!simulation.IsPaused) {
                        simulation.Pause();

                        Btn_Start.Text = "Resume";
                    } else {
                        simulation.Run();

                        Btn_Start.Text = "Pause";
                    }
                }
            } else {
                //Validation
                string errors = "";
                if (!validHCell) errors += "Horizontal Cell Count invalid!\n";
                if (!validVCell) errors += "Vertical Cell Count invalid!\n";
                if (!validTurnTimer) errors += "Turn Timer Value invalid!";

                MessageBox.Show("The following errors occured:\n " + errors, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(this + " : Cannot Start! Values: " + validHCell + "," + validVCell + "," + validTurnTimer + ", " + simulation.Seconds + ".");
            }
        }

        /// <summary>
        /// Stop Button Event Handler
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Event Arguments.</param>
        private void Btn_Stop_Click(object sender, EventArgs e) {
            if (simulation.IsRunning) {
                simulation.Stop();      //Stops Simulation

                Btn_Start.Text = "Start";
                Btn_Stop.Enabled = false;
                EnableComponents(true);
                //Foreach record pair in dictionary
                foreach (KeyValuePair<Coords, Cell> pair in Cell.Cells) {
                    pair.Value.ResetCell();
                }
            }
        }
        
        /// <summary>
        /// Slider Mouse Event Handler
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Mouse Event Arguments.</param>
        private void CellCountValueChanged(object sender, MouseEventArgs e) {
            CreateGrid();
        }

        /// <summary>
        /// Window Close Event Handler
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Event Arguments.</param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

        /// <summary>
        /// Slider TextBox Event Handler
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Event Arguments.</param>
        private void CellCountValueChanged(object sender, EventArgs e) {
            try {
                int cols = Int32.Parse(Txt_HCells.Text);
                int rows = Int32.Parse(Txt_VCells.Text);

                //Validates text values
                if (cols < TrBar_HCells.Minimum) {
                    validHCell = false;
                    return;
                } else if (cols > TrBar_HCells.Maximum) {
                    validHCell = false;
                    return;
                }
                if (rows < TrBar_VCells.Minimum) {
                    validVCell = false;
                    return;
                } else if (rows > TrBar_VCells.Maximum) {
                    validVCell = false;
                    return;
                }

                //If no validation errors, create grid
                validHCell = true;
                validVCell = true;
                CreateGrid();
            } catch (FormatException fe) {
                if (sender == TrBar_HCells) {
                    validHCell = false;
                } else if (sender == TrBar_VCells) {
                    validVCell = false;
                }
            }
        }

        /// <summary>
        /// Timer TextBox Event Handler
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Event Arguments.</param>
        private void Txt_Timer_TextChanged(object sender, EventArgs e) {
            try {
                int parseVal = Int32.Parse(Txt_Timer.Text);
                if (parseVal > TrBar_Timer.Maximum) {
                    validTurnTimer = false;
                    return;
                } else if (parseVal < TrBar_Timer.Minimum) {
                    validTurnTimer = false;
                    return;
                }
                TrBar_Timer.Value = parseVal;

                validTurnTimer = true;
            } catch (FormatException fe) {
                validTurnTimer = false;
            }
        }
    }
}
