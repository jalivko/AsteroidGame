using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.VisualObjects.Interfaces;
using AsteroidGame.Properties;

namespace AsteroidGame.VisualObjects
{
    class SpaceShip : ImageObject, ICollision
    {
        public const int MAX_ENERGY = 1000;

        private int _Energy = MAX_ENERGY;

        public int Energy => _Energy;

        private Weapon _Weapon;

        public bool IsMotionUp { get; set; } = false;
        public bool IsMotionDown { get; set; } = false;
        public bool IsMotionLeft { get; set; } = false;
        public bool IsMotionRight { get; set; } = false;
        public bool IsFiring { get; set; } = false;

        private const int _SPEED = 10;

        private int _Score = 0;
        public int Score => _Score;

        public SpaceShip(Point Position, Size Size, Weapon Weapon) : base(Position, Point.Empty, Size, Resources.Spaceship)
        {
            (_Sprite as Bitmap).MakeTransparent();
            _Weapon = Weapon;
        }

        public override void Update()
        {
            _Direction = _GetNextDirection();
            _Position = _GetNextPosition();
            _Weapon.Position = _GetWeaponPosition();

            if (IsFiring) _Weapon.Fire();
        }

        public void ChangeEnergy(int delta)
        {
            _Energy = Math.Min(Math.Max(_Energy + delta, 0), MAX_ENERGY);
            if (_Energy == 0) Game.UnregisterGameObject(this);
        }

        private Point _GetWeaponPosition()
        {
            return new Point(_Position.X + _Size.Width, _Position.Y + _Size.Height / 2);
        }

        private Point _GetNextDirection()
        {
            var direction_x = 0;
            var direction_y = 0;

            if (IsMotionUp) direction_y -= _SPEED;
            if (IsMotionDown) direction_y += _SPEED;
            if (IsMotionLeft) direction_x -= _SPEED;
            if (IsMotionRight) direction_x += _SPEED;

            return new Point(direction_x, direction_y);
        }

        private Point _GetNextPosition()
        {
            var position_x = _Position.X + _Direction.X;
            var position_y = _Position.Y + _Direction.Y;

            if (position_x < 0)
                position_x = 0;
            else if (position_x + _Size.Width > Game.Width)
                position_x = Game.Width - _Size.Width;

            if (position_y < 0)
                position_y = 0;
            else if (position_y + _Size.Height > Game.Height)
                position_y = Game.Height - _Size.Height;

            return new Point(position_x, position_y);
        }

        public void Collision(ICollision obj)
        {
        }

        public void AddScore(int Points)
        {
            _Score += Points;
        }
    }
}
