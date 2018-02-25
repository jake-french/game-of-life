using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_of_life {
    public class Cell : Button {
        private static Dictionary<Coords, Cell> _cells;
        private static int maxX, maxY;

        private LiveState state;
        private Coords coords;
        private bool isRunning;

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
            Click += Clicked;
            state = LiveState.INTIAL;
            _cells.Add(coords, this);
        }

        public LiveState State {
            get {
                return state;
            }
        }

        public static Dictionary<Coords, Cell> Cells {
            get {
                if (_cells == null) {
                    _cells = new Dictionary<Coords, Cell>();
                }
                return _cells;
            }
        }

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

        public void ChangeState(LiveState state) {
            //Prevent dead turning to unused
            if (this.state == LiveState.DEAD && state == LiveState.INTIAL) {
                return;
            }
            this.state = state;
            ReColor();
        }

        public void ResetCell() {
            state = LiveState.INTIAL;
            ReColor();
        }

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

        [Obsolete("Unused")]
        public static void SetRunning(bool flag) {
            foreach (KeyValuePair<Coords, Cell> pair in _cells) {
                pair.Value.isRunning = flag;
            }
        }

        public static void ResetCells() {
            _cells = new Dictionary<Coords, Cell>();
        }

    }

    public struct Coords {
        public int x, y;
    }

    public enum LiveState {
        INTIAL,
        LIVING,
        DEAD
    }

}
