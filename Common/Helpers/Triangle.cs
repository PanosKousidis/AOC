namespace Common.Helpers
{
    public class Triangle
    {
        private int X { get; }
        private int Y { get; }
        private int Z { get; }
        public bool IsPossible() => X + Y > Z && Y + Z > X && Z + X > Y;

        public Triangle(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

    }
}