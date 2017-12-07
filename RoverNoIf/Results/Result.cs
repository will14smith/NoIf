namespace RoverNoIf.Results
{
    public abstract class Result
    {
        public class Success : Result
        {
            public Rover Rover { get; }

            public Success(Rover rover)
            {
                Rover = rover;
            }
        }

        public class Blocked : Result
        {
            public Obstacle Obstacle { get; }

            public Blocked(Obstacle obstacle)
            {
                Obstacle = obstacle;
            }
        }
    }
}
