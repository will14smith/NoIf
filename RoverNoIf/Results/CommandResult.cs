namespace RoverNoIf.Results
{
    public abstract class CommandResult
    {
        public Rover Rover { get; }

        protected CommandResult(Rover rover)
        {
            Rover = rover;
        }

        public class Success : CommandResult
        {
            public Success(Rover rover) : base(rover)
            {
            }
        }

        public class Blocked : CommandResult
        {
            public Obstacle Obstacle { get; }

            public Blocked(Obstacle obstacle, Rover rover) : base(rover)
            {
                Obstacle = obstacle;
            }
        }

    }
}
