namespace RoverNoIf.Results
{
    public abstract class Result
    {
        public Rover Rover { get; }

        protected Result(Rover rover)
        {
            Rover = rover;
        }

        public class Success : Result
        {
            public Success(Rover rover) : base(rover)
            {
            }
        }

        public class Blocked : Result
        {
            public Obstacle Obstacle { get; }

            public Blocked(Obstacle obstacle, Rover rover) : base(rover)
            {
                Obstacle = obstacle;
            }
        }
    }
}
