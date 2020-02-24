using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame.VisualObjects
{
    abstract class MovedObject : IVisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public Point Position => _Position;

        public Rectangle Rect => new Rectangle(_Position, _Size);

        protected MovedObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public abstract void Draw(Graphics g);

        public virtual void Update()
        {
            _Position = new Point(
                _Position.X + _Direction.X,
                _Position.Y + _Direction.Y);

            if (_Position.X < 0)
                //_Direction.X *= -1;
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y < 0)
                _Direction = new Point(_Direction.X, -_Direction.Y);

            if (_Position.X + _Size.Width > Game.Width)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y + _Size.Height > Game.Height)
                _Direction = new Point(_Direction.X, -_Direction.Y);
        }
    }
}
