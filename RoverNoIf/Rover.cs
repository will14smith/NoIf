using System.Linq;
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
            var nullTerminatedCommands = commands.ToList();
            nullTerminatedCommands.Add((char) 0);

            CommandResult Reduce(Iterator i, CommandResult r, char c)
            {
                var result = CommandsMapping.Commands[c].Apply(r.Rover);

                var next = result.GetNextIterator(i);

                return next.Reduce(result, Reduce);
            }

            var initial = new Iterator.GoIterator(nullTerminatedCommands, 0);

            return initial.Reduce<CommandResult>(new CommandResult.Success(rover), Reduce);
        }
    }
}
