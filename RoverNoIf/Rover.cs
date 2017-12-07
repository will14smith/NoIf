using System;

namespace RoverNoIf
{
    public class Rover
    {
        public Position Position { get; }
        public Heading Heading { get; }

        public Rover(Position position, Heading heading)
        {
            Position = position;
            Heading = heading;
        }

        public Rover Move(string command)
        {
            throw new NotImplementedException();
        }
    }
}
