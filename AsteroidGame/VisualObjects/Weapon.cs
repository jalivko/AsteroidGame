using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame.VisualObjects
{
    class Weapon : IGameObject
    {
        public Point Position { get; set; } = Point.Empty;

        private Point _BulletDirection = new Point(20, 0);
        private Size _BulletSize = new Size(15, 3);

        private int _WaitingTicks = 0;

        public void Fire()
        {
            if (_WaitingTicks > 0) return;
            _WaitingTicks = 10;

            Game.RegisterGameObject(CreateBullet());
        }

        public void Update()
        {
            if (_WaitingTicks > 0) _WaitingTicks--;
        }

        private Bullet CreateBullet()
        {
            var bullet = new Bullet(Position, _BulletDirection, _BulletSize);
            return bullet;
        }
    }
}
