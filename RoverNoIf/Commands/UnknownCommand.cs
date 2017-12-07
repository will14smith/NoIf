using RoverNoIf.Results;

namespace RoverNoIf.Commands
{
    public class UnknownCommand : Command
    {
        private readonly char _command;

        public UnknownCommand(char command)
        {
            _command = command;
        }

        public override CommandResult Apply(Rover rover)
        {
            return new CommandResult.Unknown(_command, rover);
        }
    }
}