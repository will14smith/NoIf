namespace RoverNoIf
{
    public class Position
    {
        public Planet Planet { get; }

        public int X { get; }
        public int Y { get; }

        public Position(Planet planet, int x, int y)
        {
            Planet = planet;

            X = x;
            Y = y;
        }
    }
}