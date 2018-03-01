using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace game_of_life {
    /// <summary>
    /// Class handling the turn based simulation of life cells within a grid.
    /// </summary>
    public class Simulation {
        private static Simulation _instance;
        private static bool _isRunning = false;
        private static bool _isPaused = false;
        private static int _seconds = -1;

        private static System.Windows.Forms.Timer timer;
        private static System.Timers.Timer second;
        private static ProgressBar progressBar;
        private static int timerInterval = 125;
        private static List<Cell> willLive, willDie, other;

        #region Singleton
        /// <summary>
        /// Access the Singleton Instance of Simulation
        /// </summary>
        public static Simulation Instance {
            get {
                if (_instance == null) {
                    _instance = new Simulation();
                }
                return _instance;
            }
        }

        //Prevent Construction Externally
        private Simulation() { }
        #endregion

        /// <summary>
        /// Returns the simulation is running value
        /// </summary>
        public bool IsRunning {
            get {
                return _isRunning;
            }
        }

        /// <summary>
        /// Returns the simulation is paused value
        /// </summary>
        public bool IsPaused {
            get {
                return _isPaused;
            }
        }

        /// <summary>
        /// Returns the number of seconds per turn
        /// </summary>
        public int Seconds {
            get {
                return _seconds;
            }
        }

        /// <summary>
        /// Sets the turn timer in seconds
        /// </summary>
        /// <param name="seconds">Number of seconds per turn.</param>
        public void SetTurnTime(int seconds) {
            _seconds = seconds;
            progressBar.Maximum = _seconds * (1000 / timerInterval);

        }

        //int cnt = 0;
        /// <summary>
        /// Starts or Resumes the simulation
        /// </summary>
        public void Run() {
            if (!_isRunning) {
                _isRunning = true;
                System.Diagnostics.Debug.WriteLine("Starting timer of " + _seconds + " stepping " + progressBar.Step + " every " + timerInterval + "ms.");

                timer = new System.Windows.Forms.Timer {
                    Interval = timerInterval,
                };
                timer.Tick += new EventHandler(TimerTick);
                timer.Enabled = true;

                /*
                second = new System.Timers.Timer(1000);
                second.Elapsed += delegate (object sender, ElapsedEventArgs e) {
                    cnt++;
                    System.Diagnostics.Debug.WriteLine("SECOND: " + cnt);
                };
                second.AutoReset = true;
                second.Enabled = true;
                */
            } else {
                if (_isPaused) {
                    _isPaused = false;
                    //Continue
                    timer.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Timer Tick Event Handler for turn timer
        /// </summary>
        /// <param name="sender">Object sending event.</param>
        /// <param name="e">Event Arguments.</param>
        private void TimerTick(object sender, EventArgs e) {
            //Sleep
            if (progressBar.Value + 1 >= progressBar.Maximum) {
                //Invokes method to prevent multi-thread access to progressBar
                progressBar.Invoke(new MethodInvoker(delegate () { progressBar.Value = 0; }));
                System.Diagnostics.Debug.WriteLine(_seconds + " passed!");
                DoTurn();       //Performs Turn Transition
            } else {
                //Invokes method to prevent multi-thread access to progressBar
                progressBar.Invoke(new MethodInvoker(delegate () { progressBar.Value++; }));
                if (progressBar.Maximum - progressBar.Value <= 2) {
                    progressBar.Invoke(new MethodInvoker(delegate () { progressBar.Value = progressBar.Maximum; }));
                }
            }
        }

        /// <summary>
        /// Pauses the Simulation
        /// </summary>
        public void Pause() {
            if (_isRunning) {
                if (!_isPaused) {
                    _isPaused = true;
                    timer.Enabled = false;
                    second.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Ends the Simulation
        /// </summary>
        public void Stop() {
            if (_isRunning) {
                _isRunning = false;
                //Stops timers
                timer.Stop();
                second.Stop();
                timer.Dispose();
                second.Dispose();
                //cnt = 0;

                progressBar.Value = 0;
            }
        }

        /// <summary>
        /// Tests every cell to determine potential living state changes
        /// </summary>
        public void DoTurn() {
            willLive = new List<Cell>();
            willDie = new List<Cell>();
            other = new List<Cell>();

            //Foreach record pair in cells dictionary
            foreach (KeyValuePair<Coords, Cell> pair in Cell.Cells) {
                int flag = pair.Value.CheckState();

                if (flag == 1) {
                    willLive.Add(pair.Value);
                } else if (flag == 2) {
                    willDie.Add(pair.Value);
                } else {
                    other.Add(pair.Value);
                }
            }

            foreach (Cell cell in willLive) {
                cell.ChangeState(LiveState.LIVING);
            }
            foreach (Cell cell in willDie) {
                cell.ChangeState(LiveState.DEAD);
            }
            foreach (Cell cell in other) {
                cell.ChangeState(LiveState.INTIAL);
            }
        }

        /// <summary>
        /// Creates reference to progress bar for easy access
        /// </summary>
        /// <param name="bar">Progress bar reference.</param>
        public void AssignProgressBar(ProgressBar bar) {
            progressBar = bar;
        }

    }
}
