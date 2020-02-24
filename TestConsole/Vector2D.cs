using System;

namespace TestConsole
{
    struct Vector2D
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Vector2D(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double Length => Math.Sqrt(X * X + Y * Y);

        public static Vector2D operator +(Vector2D left, Vector2D right) => new Vector2D(left.X + right.X, left.Y + right.Y);

        public static Vector2D operator -(Vector2D left, Vector2D right) => new Vector2D(left.X - right.X, left.Y - right.Y);

        public override string ToString() => $"({X}:{Y})";
    }
}
