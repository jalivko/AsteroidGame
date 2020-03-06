using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class AsteroidsRespawn : IGameObject
    {
        private Random _rnd;
        private Rectangle _Place;
        private Point _Direction;
        private int _SpawnTimeout;
        private int _Ticks = 0;

        public AsteroidsRespawn(Rectangle Place, Point Direction, int SpawnTimeout)
        {
            _Place = Place;
            _Direction = Direction;
            _SpawnTimeout = SpawnTimeout;
            _rnd = new Random();
        }

        public void Update()
        {
            _Ticks--;
            if (_Ticks > 0) return;
            _Ticks = _SpawnTimeout;

            Game.RegisterGameObject(CreateAsteroid());
        }

        private Asteroid CreateAsteroid()
        {
            var position = new Point(_rnd.Next(_Place.Left, _Place.Right), _rnd.Next(_Place.Top, _Place.Bottom));
            var asteroid = new Asteroid(position, _Direction, new Size(70, 50), 50, 100, 100);

            asteroid.Removed += Game.UnregisterGameObject;
            asteroid.Removed += (rm_object) =>
            {
                if (rm_object.Health <= 0) Game.Player.AddScore(rm_object.Points);
            };

            return asteroid;
        }
    }
}
