using System;
using System.Collections.Generic;

namespace RoverNoIf
{
    public abstract class Iterator
    {
        public abstract Iterator Next { get; }
        public abstract TState Reduce<TState>(TState initial, Func<Iterator, TState, char, TState> func);


        public class GoIterator : Iterator
        {
            private readonly IReadOnlyList<char> _commands;
            private readonly int _index;

            public GoIterator(IReadOnlyList<char> commands, int index)
            {
                _commands = commands;
                _index = index;
            }

            public override Iterator Next => new GoIterator(_commands, _index + 1);

            public override TState Reduce<TState>(TState initial, Func<Iterator, TState, char, TState> func)
            {
                return func(this, initial, _commands[_index]);
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