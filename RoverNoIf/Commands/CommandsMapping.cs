using System.Collections.Generic;

namespace RoverNoIf.Commands
{
    public static class CommandsMapping
    {
        public static IReadOnlyDictionary<char, Command> Commands { get; }

        static CommandsMapping()
        {
            var commands = new Dictionary<char, Command>();
            for (var i = char.MinValue; i < char.MaxValue; i++)
            {
                commands.Add(i, new UnknownCommand(i));
            }

            commands[(char) 0] = new DoneCommand();

            commands['f'] = commands['F'] = new MoveCommand(MoveDirection.Forward);
            commands['b'] = commands['B'] = new MoveCommand(MoveDirection.Backward);
            commands['l'] = commands['L'] = new TurnCommand(TurnDirection.Left);
            commands['r'] = commands['R'] = new TurnCommand(TurnDirection.Right);

            Commands = commands;
        }
    }
}