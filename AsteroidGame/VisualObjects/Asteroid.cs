using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.Properties;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame.VisualObjects
{
    class Asteroid : ImageObject, ICollision
    {
        public event Action<Asteroid> Removed;

        private int _Max_Health;

        private int _Health;

        public int Health => _Health;

        public int Damage { get; }

        public int Points { get; }

        public Asteroid(Point Position, Point Direction, Size Size, int Points, int Damage, int Health) : base(Position, Direction, Size, Resources.Asteroid)
        {
            (_Sprite as Bitmap).MakeTransparent();

            this.Points = Points;
            this.Damage = Damage;
            this._Max_Health = Health;
            this._Health = Health;
        }

        public void Collision(ICollision obj)
        {
            if (obj is SpaceShip spaceShip)
            {
                spaceShip.ChangeEnergy(-Damage);
                Removed?.Invoke(this);
            }
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            if (_Health != _Max_Health)
            {
                var healthbar_width = 50;
                var healthbar_height = 5;

                g.DrawRectangle(Pens.Red, _Position.X + (_Size.Width - healthbar_width) / 2, _Position.Y, healthbar_width, healthbar_height);
                g.FillRectangle(Brushes.Red, _Position.X + (_Size.Width - healthbar_width) / 2, _Position.Y, healthbar_width * _Health / _Max_Health, healthbar_height);
            }
        }

        public void Attack(int Damage)
        {
            _Health -= Damage;
            if (_Health <= 0) Removed?.Invoke(this);
        }

        public override void Update()
        {
            var position_x = _Position.X + _Direction.X;
            var position_y = _Position.Y + _Direction.Y;

            if (position_x + _Size.Width < 0) Game.UnregisterGameObject(this);

            _Position = new Point(position_x, position_y);
        }
    }
}
