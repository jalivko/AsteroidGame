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

        public MainForm()
        {
            InitializeComponent();
            Game.Initialize(this);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            (sender as Button).Visible = false;
            Game.Run();
        }

        private void MainForm_Shown(object sender, EventArgs e) => Game.Show();

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            (sender as Button).Visible = false;
            Game.Run();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && !Game.IsPaused())
            {
                Game.Stop();
                ContinueButton.Visible = true;
                ContinueButton.Focus();
            }
        }
    }
}
