using RoverNoIf.Commands;

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

        public Rover Move(string commands)
        {
            return Move(this, commands);
        }

        public static Rover Move(Rover rover, string commands)
        {
            foreach (var c in commands)
            {
                rover = CommandsMapping.Commands[c].Apply(rover);
            }

            return rover;
        }
    }
}
