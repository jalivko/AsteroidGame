using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    public class Star: MovedObject
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
            var position_x = _Position.X + _Direction.X;
            var position_y = _Position.Y + _Direction.Y;

            if (position_x < 0)
                position_x = Game.Width - _Size.Width;
            else if (position_x + _Size.Width > Game.Width)
                position_x = 0;


            if (position_y < 0)
                position_y = Game.Height - _Size.Height;
            else if (position_y + _Size.Height > Game.Height)
                position_y = 0;

            _Position = new Point(position_x, position_y);
        }
    }
}
