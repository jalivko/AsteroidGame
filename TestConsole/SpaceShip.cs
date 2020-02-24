using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class SpaceShip
    {
        public Vector2D Position { get; set; }

        public SpaceShip(Vector2D Position) => this.Position = Position;

        public SpaceShip(): this(new Vector2D(0, 0))
        {
        }
    }
}
