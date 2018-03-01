using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_of_life {
    /// <summary>
    /// Visual representations of individual life cells within a grid.
    /// </summary>
    public class Cell : Button {
        private static Dictionary<Coords, Cell> _cells;     //dictionary Structure for finding cells via co-ordinates
        private static int maxX, maxY;

        private LiveState state;        //current living state
        private Coords coords;          //unique cell co-ordinates
        private bool isRunning;

        /// <summary>
        /// Cell constructor
        /// </summary>
        public Cell(int x, int y) {
            coords.x = x;
            coords.y = y;
            if (x > maxX) {
                maxX = x;
            }
            if (y > maxY) {
                maxY = y;
            }

            isRunning = false;
            Dock = DockStyle.Fill;
            BackColor = System.Drawing.Color.GhostWhite;
            Click += Clicked;           //Add Click Event Handler
            state = LiveState.INTIAL;
            _cells.Add(coords, this);
        }

        /// <summary>
        /// Retrieves the current live state of the cell: intial, living, dead
        /// </summary>
        public LiveState State {
            get {
                return state;
            }
        }

        /// <summary>
        /// Retrieves the dictionary containing the co-ordinates for each cell
        ///
        public static Dictionary<Coords, Cell> Cells {
            get {
                if (_cells == null) {
                    _cells = new Dictionary<Coords, Cell>();
                }
                return _cells;
            }
        }

        /// <summary>
        /// Click Event Handler
        /// </summary>
        /// <param name="sender">Object that sends the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Clicked(object sender, EventArgs e) {
            if (state == LiveState.INTIAL) {
                state = LiveState.LIVING;
            } else if (state == LiveState.LIVING) {
                state = LiveState.DEAD;
            } else if (state == LiveState.DEAD) {
                state = LiveState.INTIAL;
            }

            ReColor();
            //} else {
            //    Simulation.Instance.Pause();
            //    MessageBox.Show("Cell : " + coords.x + ", " + coords.y + " is in state: " + state.ToString(), "Cell State");
            //    Simulation.Instance.Run();
            //}
        }

        /// <summary>
        /// Changes the cell's living state.
        /// </summary>
        /// <param name="state">New value for the cell living state.</param>
        public void ChangeState(LiveState state) {
            //Prevent dead turning to unused
            if (this.state == LiveState.DEAD && state == LiveState.INTIAL) {
                return;
            }
            this.state = state;
            ReColor();
        }

        /// <summary>
        /// Resets cell's living state to intial.
        /// </summary>
        public void ResetCell() {
            state = LiveState.INTIAL;
            ReColor();
        }

        /// <summary>
        /// Colors cell based on current living state.
        /// </summary>
        public void ReColor() {
            switch (state) {
                case LiveState.INTIAL:
                    BackColor = System.Drawing.Color.GhostWhite;

                    break;
                case LiveState.LIVING:
                    BackColor = System.Drawing.Color.Green;

                    break;
                case LiveState.DEAD:
                    BackColor = System.Drawing.Color.Red;

                    break;
            }
        }

        /// <summary>
        /// Checks what the next living state of the cell will be based upon nearby cells.
        /// </summary>
        /// <returns>Returns integer flag representing next living state. 0 - intial, 1 - living, 2 - dead.</returns>
        public int CheckState() {
            int flag = 0;
            int liveNeighbours = 0;
            Coords tempCoord;
            Cell tempCell;

            //Right
            if (coords.x < maxX) {
                tempCoord.x = coords.x + 1;
                tempCoord.y = coords.y;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }
            //BottomRight
            if (coords.x < maxX && coords.y < maxY) {
                tempCoord.x = coords.x + 1;
                tempCoord.y = coords.y + 1;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }
            //Bottom
            if (coords.y < maxY) {
                tempCoord.x = coords.x;
                tempCoord.y = coords.y + 1;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }
            //BottomLeft
            if (coords.x > 0 && coords.y < maxY) {
                tempCoord.x = coords.x - 1;
                tempCoord.y = coords.y + 1;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }
            //Left
            if (coords.x > 0) {
                tempCoord.x = coords.x - 1;
                tempCoord.y = coords.y;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }
            //TopLeft
            if (coords.x > 0 && coords.y > 0) {
                tempCoord.x = coords.x - 1;
                tempCoord.y = coords.y - 1;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }
            //Top
            if (coords.y > 0) {
                tempCoord.x = coords.x;
                tempCoord.y = coords.y - 1;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }
            //TopRight
            if (coords.x < maxX && coords.y > 0) {
                tempCoord.x = coords.x + 1;
                tempCoord.y = coords.y - 1;
                if (_cells.TryGetValue(tempCoord, out tempCell)) {
                    if (tempCell.State == LiveState.LIVING) {
                        liveNeighbours++;
                    }
                }
            }

            //Determine Flag
            System.Diagnostics.Debug.WriteLine("Cell (" + coords.x + "," + coords.y + ") Neighbours: " + liveNeighbours);
            if (liveNeighbours < 2 && state != LiveState.INTIAL) {
                flag = 2;
            } else if (liveNeighbours == 3 && (state == LiveState.INTIAL || state == LiveState.DEAD)) {
                flag = 1;
            } else if ((liveNeighbours == 2 || liveNeighbours == 3) && state == LiveState.LIVING) {
                flag = 1;
            } else if (liveNeighbours > 3) {
                flag = 2;
            } else if (liveNeighbours == 0) {
                if (state == LiveState.INTIAL) {
                    flag = 0;
                } else {
                    flag = 2;
                }
            }
            System.Diagnostics.Debug.WriteLine("Cell (" + coords.x + "," + coords.y + ") set flag: " + flag);

            return flag;
        }

        [Obsolete("Unused. Feature Removed")]
        public static void SetRunning(bool flag) {
            foreach (KeyValuePair<Coords, Cell> pair in _cells) {
                pair.Value.isRunning = flag;
            }
        }

        /// <summary>
        /// Empties the dictionary 
        /// </summary>
        public static void ResetCells() {
            _cells = new Dictionary<Coords, Cell>();
        }

    }

    /// <summary>
    /// Simple struct to simplify storing two integer values within collections.
    /// </summary>
    public struct Coords {
        public int x, y;
    }

    /// <summary>
    /// Enum storing the potential living states.
    /// </summary>
    public enum LiveState {
        INTIAL,
        LIVING,
        DEAD
    }

}
