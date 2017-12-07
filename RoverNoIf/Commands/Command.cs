namespace RoverNoIf.Commands
{
    public abstract class Command
    {
        public abstract Rover Apply(Rover rover);
    }
}