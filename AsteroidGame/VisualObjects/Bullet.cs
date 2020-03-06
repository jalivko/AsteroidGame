using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidGame.Properties;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame.VisualObjects
{
    class Bullet : MovedObject, ICollision
    {
        private const int _Damage = 50;

        public Bullet(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        {
        }

        public void Collision(ICollision obj)
        {
            if (obj is Asteroid asteroid) asteroid.Attack(_Damage);
            Game.UnregisterGameObject(this);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Yellow, new Rectangle(_Position.X, _Position.Y, _Size.Width, _Size.Height));
        }

        public override void Update()
        {
            var position_x = _Position.X + _Direction.X;
            var position_y = _Position.Y + _Direction.Y;

            if (position_x > Game.Width) Game.UnregisterGameObject(this);

            _Position = new Point(position_x, position_y);
        }
    }
}
