namespace game_of_life {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Pnl_Options = new System.Windows.Forms.Panel();
            this.GBox_TurnOpt = new System.Windows.Forms.GroupBox();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.GBox_TurnTimer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Timer = new System.Windows.Forms.TextBox();
            this.TrBar_Timer = new System.Windows.Forms.TrackBar();
            this.PBar_TurnTimer = new System.Windows.Forms.ProgressBar();
            this.Txt_VCells = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TrBar_VCells = new System.Windows.Forms.TrackBar();
            this.Txt_HCells = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TrBar_HCells = new System.Windows.Forms.TrackBar();
            this.Tbl_Grid = new System.Windows.Forms.TableLayoutPanel();
            this.Pnl_Options.SuspendLayout();
            this.GBox_TurnOpt.SuspendLayout();
            this.GBox_TurnTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBar_Timer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBar_VCells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBar_HCells)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Options
            // 
            this.Pnl_Options.AutoSize = true;
            this.Pnl_Options.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Pnl_Options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_Options.Controls.Add(this.GBox_TurnOpt);
            this.Pnl_Options.Controls.Add(this.GBox_TurnTimer);
            this.Pnl_Options.Controls.Add(this.Txt_VCells);
            this.Pnl_Options.Controls.Add(this.label2);
            this.Pnl_Options.Controls.Add(this.TrBar_VCells);
            this.Pnl_Options.Controls.Add(this.Txt_HCells);
            this.Pnl_Options.Controls.Add(this.label1);
            this.Pnl_Options.Controls.Add(this.TrBar_HCells);
            this.Pnl_Options.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Options.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Options.MinimumSize = new System.Drawing.Size(500, 100);
            this.Pnl_Options.Name = "Pnl_Options";
            this.Pnl_Options.Size = new System.Drawing.Size(524, 107);
            this.Pnl_Options.TabIndex = 2;
            // 
            // GBox_TurnOpt
            // 
            this.GBox_TurnOpt.Controls.Add(this.Btn_Stop);
            this.GBox_TurnOpt.Controls.Add(this.Btn_Start);
            this.GBox_TurnOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBox_TurnOpt.Location = new System.Drawing.Point(352, 6);
            this.GBox_TurnOpt.Name = "GBox_TurnOpt";
            this.GBox_TurnOpt.Size = new System.Drawing.Size(159, 94);
            this.GBox_TurnOpt.TabIndex = 7;
            this.GBox_TurnOpt.TabStop = false;
            this.GBox_TurnOpt.Text = "Control Options";
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Enabled = false;
            this.Btn_Stop.Location = new System.Drawing.Point(6, 56);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(147, 34);
            this.Btn_Stop.TabIndex = 4;
            this.Btn_Stop.Text = "Stop";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(6, 18);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(147, 32);
            this.Btn_Start.TabIndex = 2;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // GBox_TurnTimer
            // 
            this.GBox_TurnTimer.Controls.Add(this.label3);
            this.GBox_TurnTimer.Controls.Add(this.Txt_Timer);
            this.GBox_TurnTimer.Controls.Add(this.TrBar_Timer);
            this.GBox_TurnTimer.Controls.Add(this.PBar_TurnTimer);
            this.GBox_TurnTimer.Location = new System.Drawing.Point(160, 6);
            this.GBox_TurnTimer.Name = "GBox_TurnTimer";
            this.GBox_TurnTimer.Size = new System.Drawing.Size(186, 89);
            this.GBox_TurnTimer.TabIndex = 6;
            this.GBox_TurnTimer.TabStop = false;
            this.GBox_TurnTimer.Text = "Turn Timer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Time per Turn (seconds): ";
            // 
            // Txt_Timer
            // 
            this.Txt_Timer.Location = new System.Drawing.Point(130, 33);
            this.Txt_Timer.Name = "Txt_Timer";
            this.Txt_Timer.Size = new System.Drawing.Size(43, 20);
            this.Txt_Timer.TabIndex = 7;
            this.Txt_Timer.TextChanged += new System.EventHandler(this.Txt_Timer_TextChanged);
            // 
            // TrBar_Timer
            // 
            this.TrBar_Timer.AutoSize = false;
            this.TrBar_Timer.Location = new System.Drawing.Point(10, 33);
            this.TrBar_Timer.Minimum = 1;
            this.TrBar_Timer.Name = "TrBar_Timer";
            this.TrBar_Timer.Size = new System.Drawing.Size(114, 24);
            this.TrBar_Timer.TabIndex = 6;
            this.TrBar_Timer.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBar_Timer.Value = 1;
            // 
            // PBar_TurnTimer
            // 
            this.PBar_TurnTimer.Location = new System.Drawing.Point(10, 63);
            this.PBar_TurnTimer.Name = "PBar_TurnTimer";
            this.PBar_TurnTimer.Size = new System.Drawing.Size(163, 23);
            this.PBar_TurnTimer.Step = 1;
            this.PBar_TurnTimer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar_TurnTimer.TabIndex = 5;
            // 
            // Txt_VCells
            // 
            this.Txt_VCells.Location = new System.Drawing.Point(111, 72);
            this.Txt_VCells.Name = "Txt_VCells";
            this.Txt_VCells.Size = new System.Drawing.Size(43, 20);
            this.Txt_VCells.TabIndex = 5;
            this.Txt_VCells.TextChanged += new System.EventHandler(this.CellCountValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vertical Cell Count:";
            // 
            // TrBar_VCells
            // 
            this.TrBar_VCells.AutoSize = false;
            this.TrBar_VCells.Location = new System.Drawing.Point(3, 72);
            this.TrBar_VCells.Maximum = 50;
            this.TrBar_VCells.Minimum = 5;
            this.TrBar_VCells.Name = "TrBar_VCells";
            this.TrBar_VCells.Size = new System.Drawing.Size(102, 30);
            this.TrBar_VCells.TabIndex = 3;
            this.TrBar_VCells.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBar_VCells.Value = 5;
            this.TrBar_VCells.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CellCountValueChanged);
            // 
            // Txt_HCells
            // 
            this.Txt_HCells.Location = new System.Drawing.Point(111, 26);
            this.Txt_HCells.Name = "Txt_HCells";
            this.Txt_HCells.Size = new System.Drawing.Size(43, 20);
            this.Txt_HCells.TabIndex = 2;
            this.Txt_HCells.TextChanged += new System.EventHandler(this.CellCountValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Horizontal Cell Count:";
            // 
            // TrBar_HCells
            // 
            this.TrBar_HCells.AutoSize = false;
            this.TrBar_HCells.Location = new System.Drawing.Point(3, 26);
            this.TrBar_HCells.Maximum = 50;
            this.TrBar_HCells.Minimum = 5;
            this.TrBar_HCells.Name = "TrBar_HCells";
            this.TrBar_HCells.Size = new System.Drawing.Size(102, 30);
            this.TrBar_HCells.TabIndex = 0;
            this.TrBar_HCells.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBar_HCells.Value = 5;
            this.TrBar_HCells.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CellCountValueChanged);
            // 
            // Tbl_Grid
            // 
            this.Tbl_Grid.AllowDrop = true;
            this.Tbl_Grid.AutoScroll = true;
            this.Tbl_Grid.AutoSize = true;
            this.Tbl_Grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Tbl_Grid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Tbl_Grid.ColumnCount = 1;
            this.Tbl_Grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_Grid.Location = new System.Drawing.Point(0, 107);
            this.Tbl_Grid.MinimumSize = new System.Drawing.Size(500, 500);
            this.Tbl_Grid.Name = "Tbl_Grid";
            this.Tbl_Grid.RowCount = 1;
            this.Tbl_Grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Grid.Size = new System.Drawing.Size(524, 530);
            this.Tbl_Grid.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 637);
            this.Controls.Add(this.Tbl_Grid);
            this.Controls.Add(this.Pnl_Options);
            this.MinimumSize = new System.Drawing.Size(540, 675);
            this.Name = "MainWindow";
            this.Text = "Game of Life";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Pnl_Options.ResumeLayout(false);
            this.Pnl_Options.PerformLayout();
            this.GBox_TurnOpt.ResumeLayout(false);
            this.GBox_TurnTimer.ResumeLayout(false);
            this.GBox_TurnTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBar_Timer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBar_VCells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBar_HCells)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_Options;
        private System.Windows.Forms.TableLayoutPanel Tbl_Grid;
        private System.Windows.Forms.TrackBar TrBar_HCells;
        private System.Windows.Forms.TextBox Txt_HCells;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_VCells;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar TrBar_VCells;
        private System.Windows.Forms.GroupBox GBox_TurnTimer;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Stop;
        private System.Windows.Forms.ProgressBar PBar_TurnTimer;
        private System.Windows.Forms.TextBox Txt_Timer;
        private System.Windows.Forms.TrackBar TrBar_Timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GBox_TurnOpt;
    }
}

