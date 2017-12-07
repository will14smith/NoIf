using System.Collections.Generic;

namespace RoverNoIf.Commands
{
    public static class CommandsMapping
    {
        public static IReadOnlyDictionary<char, Command> Commands { get; }

        static CommandsMapping()
        {
            Commands = new Dictionary<char, Command>
            {
                { 'F', new MoveCommand(MoveDirection.Forward) },
                { 'B', new MoveCommand(MoveDirection.Backward) }
            };
        }
    }
}