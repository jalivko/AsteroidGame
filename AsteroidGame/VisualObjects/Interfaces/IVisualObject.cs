using System.Collections.Generic;
using System.Drawing;

namespace AsteroidGame.VisualObjects.Interfaces
{
    internal interface IVisualObject: IGameObject
    {
        void Draw(Graphics g);
    }
}
