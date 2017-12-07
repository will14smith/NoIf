using RoverNoIf.Commands;

namespace RoverNoIf
{
    public class Rover
    {
        public Position Position { get; }
        public Heading Heading { get; }

        public ObstacleScanner ObstacleScanner { get; }
        
        public Rover(Position position, Heading heading, ObstacleScanner obstacleScanner)
        {
            Position = position;
            Heading = heading;
            ObstacleScanner = obstacleScanner;
        }

        public Rover WithPosition(Position position)
        {
            return new Rover(position, Heading, ObstacleScanner);
        }
        public Rover WithHeading(Heading heading)
        {
            return new Rover(Position, heading, ObstacleScanner);
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
