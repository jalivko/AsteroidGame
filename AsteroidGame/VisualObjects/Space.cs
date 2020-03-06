using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.VisualObjects.Interfaces;
using AsteroidGame;

namespace AsteroidGame.VisualObjects
{
    class Space : IGameObject
    {
        private Interval<int> _StarSizeInterval = new Interval<int>(1, 4);
        private Interval<int> _StarSpeedInterval = new Interval<int>(1, 4);

        public Space(int StarsCount)
        {
            var rnd = new Random();

            for (var i = 0; i < StarsCount; i++)
            {
                var star = new Star(
                    new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)),
                    new Point(-rnd.Next(_StarSpeedInterval.Min, _StarSpeedInterval.Max), 0),
                    rnd.Next(_StarSizeInterval.Min, _StarSizeInterval.Max));
                Game.RegisterGameObject(star);
            }

            var speed_nebula = new Point(-2, 0);
            var size_nebula = new Size(Game.Width + 500, Game.Height);

            var nebula1 = new Nebula(new Point(Game.Width, 30), speed_nebula, size_nebula);
            Game.RegisterGameObject(nebula1);
            var nebula2 = new Nebula(new Point(-250, -30), speed_nebula, size_nebula);
            Game.RegisterGameObject(nebula2);
        }

        public void Update()
        {
        }
    }
}
