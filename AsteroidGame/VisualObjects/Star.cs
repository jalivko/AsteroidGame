using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    class Star: MovedObject
    {
        public Star(Point Position, Point Direction, int Size): base(Position, Direction, new Size(Size, Size))
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.Gray,
                _Position.X, _Position.Y,
                _Position.X + _Size.Width, _Position.Y + _Size.Height);

            g.DrawLine(Pens.Gray,
                _Position.X + _Size.Width, _Position.Y,
                _Position.X, _Position.Y + _Size.Height);
        }

        public override void Update()
        {
            _Position = new Point(
                _Position.X + _Direction.X,
                _Position.Y + _Direction.Y);

            if (_Position.X < 0)
                _Position = new Point(Game.Width - _Size.Width, _Position.Y);
            if (_Position.Y < 0)
                _Position = new Point(_Position.X, Game.Height - _Size.Height);

            if (_Position.X + _Size.Width > Game.Width)
                _Position = new Point(0, _Position.Y);
            if (_Position.Y + _Size.Height > Game.Height)
                _Position = new Point(_Position.X, 0);
        }
    }
}
