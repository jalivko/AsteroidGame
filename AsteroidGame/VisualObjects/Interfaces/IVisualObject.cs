using System.Drawing;

namespace AsteroidGame.VisualObjects.Interfaces
{
    internal interface IVisualObject
    {
        void Update();

        void Draw(Graphics g);
    }
}
