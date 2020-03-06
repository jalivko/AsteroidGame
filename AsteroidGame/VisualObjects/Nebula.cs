using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsteroidGame.Properties;

namespace AsteroidGame.VisualObjects
{
    class Nebula : ImageObject
    {
        public Nebula(Point Position, Point Direction, Size Size) : base(Position, Direction, Size, Resources.Nebula)
        {
            (_Sprite as Bitmap).MakeTransparent();
        }
    }
}
