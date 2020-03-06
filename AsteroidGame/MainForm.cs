using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    public partial class MainForm : Form
    {
        public bool IsPaused { get; set; } = true;

        private bool _StartMenuVisible = false;
        private bool _ContinueMenuVisible = false;

        public MainForm()
        {
            InitializeComponent();
            SetStartMenuVisible(true);

            Game.Initialize(this);
            Game.Run();
        }

        private void SetStartMenuVisible(bool IsVisible)
        {
            StartButton.Visible = IsVisible;
            ExitButton.Visible = IsVisible;
            if (IsVisible) StartButton.Focus();
            _StartMenuVisible = IsVisible;
        }

        private void SetContinueMenuVisible(bool IsVisible)
        {
            ContinueButton.Visible = IsVisible;
            ExitButton.Visible = IsVisible;
            if (IsVisible) ContinueButton.Focus();
            _ContinueMenuVisible = IsVisible;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            SetStartMenuVisible(false);
            Game.IsPaused = false;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            SetContinueMenuVisible(false);
            Game.IsPaused = false;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_StartMenuVisible) return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Game.IsPaused = !Game.IsPaused;
                    SetContinueMenuVisible(Game.IsPaused);
                    break;
                case Keys.W:
                case Keys.Up:
                    Game.Player.IsMotionUp = true;
                    break;
                case Keys.S:
                case Keys.Down:
                    Game.Player.IsMotionDown = true;
                    break;
                case Keys.A:
                case Keys.Left:
                    Game.Player.IsMotionLeft = true;
                    break;
                case Keys.D:
                case Keys.Right:
                    Game.Player.IsMotionRight = true;
                    break;
                case Keys.Space:
                case Keys.ControlKey:
                    Game.Player.IsFiring = true;
                    break;
                case Keys.R:
                    Game.Restart();
                    break;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) => this.Close();

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (_StartMenuVisible) return;

            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    Game.Player.IsMotionUp = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    Game.Player.IsMotionDown = false;
                    break;
                case Keys.A:
                case Keys.Left:
                    Game.Player.IsMotionLeft = false;
                    break;
                case Keys.D:
                case Keys.Right:
                    Game.Player.IsMotionRight = false;
                    break;
                case Keys.Space:
                case Keys.ControlKey:
                    Game.Player.IsFiring = false;
                    break;
            }
        }
    }
}
