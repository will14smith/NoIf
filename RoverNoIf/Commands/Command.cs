using RoverNoIf.Results;

namespace RoverNoIf.Commands
{
    public abstract class Command
    {
        public abstract Result Apply(Rover rover);
    }
}