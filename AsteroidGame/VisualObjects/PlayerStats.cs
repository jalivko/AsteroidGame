using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class PlayerStats : IVisualObject
    {
        private SpaceShip _Player;

        public PlayerStats(SpaceShip Player)
        {
            _Player = Player;
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Blue, Game.Width / 2 - 202, Game.Height - 22, 402, 12);
            g.FillRectangle(Brushes.Red, Game.Width / 2 - 200, Game.Height - 20, 400 * _Player.Energy / SpaceShip.MAX_ENERGY, 10);
            g.DrawString($"Score: {_Player.Score}", new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold), Brushes.White, 10, 10);
        }

        public void Update()
        {
        }
    }
}
