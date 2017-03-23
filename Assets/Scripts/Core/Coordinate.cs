
namespace SnakeGame.Core
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate Up
        {
            get { return new Coordinate(X, Y - 1); }
        }

        public Coordinate Right
        {
            get { return new Coordinate(X + 1, Y); }
        }

        public Coordinate Down
        {
            get { return new Coordinate(X, Y + 1); }
        }

        public Coordinate Left
        {
            get { return new Coordinate(X - 1, Y); }
        }
    }
}
