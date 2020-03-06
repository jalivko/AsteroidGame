using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AsteroidGame.VisualObjects.Interfaces;

namespace AsteroidGame.VisualObjects
{
    public abstract class MovedObject : IVisualObject
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
            var position_x = _Position.X + _Direction.X;
            var position_y = _Position.Y + _Direction.Y;

            if (position_x + _Size.Width < 0)
                position_x = Game.Width;
            else if (position_x > Game.Width)
                position_x = 0;


            if (position_y + _Size.Height < 0)
                position_y = Game.Height;
            else if (position_y > Game.Height)
                position_y = 0;

            _Position = new Point(position_x, position_y);
        }
    }
}
