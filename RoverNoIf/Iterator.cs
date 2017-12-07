using System;

namespace RoverNoIf
{
    public abstract class Iterator
    {
        public abstract Iterator Next { get; }
        public abstract TState Reduce<TState>(TState initial, Func<Iterator, TState, char, TState> func);

        public static Iterator Create(string commands)
        {
            if (string.IsNullOrEmpty(commands)) return new DoneIterator();
            return new GoIterator(commands);
        }

        public class GoIterator : Iterator
        {
            private readonly string _commands;

            public GoIterator(string commands)
            {
                _commands = commands;
            }

            public override Iterator Next => Create(_commands.Substring(1));

            public override TState Reduce<TState>(TState initial, Func<Iterator, TState, char, TState> func)
            {
                return func(this, initial, _commands[0]);
            }
        }

        public class DoneIterator : Iterator
        {
            public override Iterator Next => this;

            public override TState Reduce<TState>(TState initial, Func<Iterator, TState, char, TState> func)
            {
                return initial;
            }
        }
    }
}