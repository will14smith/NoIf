namespace RoverNoIf.Results
{
    public abstract class CommandResult
    {
        public Rover Rover { get; }

        public abstract Iterator GetNextIterator(Iterator current);

        protected CommandResult(Rover rover)
        {
            Rover = rover;
        }

        public class Success : CommandResult
        {
            public Success(Rover rover) : base(rover)
            {
            }

            public override Iterator GetNextIterator(Iterator current)
            {
                return current.Next;
            }
        }

        public class Blocked : CommandResult
        {
            public Obstacle Obstacle { get; }

            public Blocked(Obstacle obstacle, Rover rover) : base(rover)
            {
                Obstacle = obstacle;
            }

            public override Iterator GetNextIterator(Iterator current)
            {
                return new Iterator.DoneIterator();
            }
        }

        public class Unknown : CommandResult
        {
            public char Command { get; }

            public Unknown(char command, Rover rover) : base(rover)
            {
                Command = command;
            }

            public override Iterator GetNextIterator(Iterator current)
            {
                return new Iterator.DoneIterator();
            }
        }
    }
}
