using RoverNoIf.Commands;
using RoverNoIf.Results;

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

        public CommandResult Move(string commands)
        {
            return Move(this, commands);
        }

        public static CommandResult Move(Rover rover, string commands)
        {
            Result result = null;
            foreach (var c in commands)
            {
                result = CommandsMapping.Commands[c].Apply(rover);

                rover = result.Rover;
            }

            return result;
        }
    }
}
