using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    public class ImageObject: MovedObject
    {
        protected Image _Sprite;

        public ImageObject(Point Position, Point Direction, Size Size, Image Sprite) : base(Position, Direction, Size)
        {
            this._Sprite = Sprite;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_Sprite, Rect);
        }
    }
}
