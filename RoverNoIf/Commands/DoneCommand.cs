using RoverNoIf.Results;

namespace RoverNoIf.Commands
{
    public class DoneCommand : Command
    {
        public override CommandResult Apply(Rover rover)
        {
            return new CommandResult.Done(rover);
        }
    }
}