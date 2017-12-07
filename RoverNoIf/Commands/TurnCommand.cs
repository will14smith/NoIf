using System.Collections.Generic;

namespace RoverNoIf.Commands
{
    public class TurnCommand : Command
    {
        private const int NumberOfDirections = 4;
        private static readonly IReadOnlyDictionary<TurnDirection, int> DirectionDeltas = new Dictionary<TurnDirection, int>
        {
            { TurnDirection.Left, 1 },
            { TurnDirection.Right, -1 },
        };

        private readonly TurnDirection _direction;

        public TurnCommand(TurnDirection direction)
        {
            _direction = direction;
        }

        public override Rover Apply(Rover rover)
        {
            var delta = DirectionDeltas[_direction];

            var oldHeadingAsInt = (int)rover.Heading;
            var newHeadingAsInt = (oldHeadingAsInt + delta + NumberOfDirections) % NumberOfDirections;

            var newHeading = (Heading)newHeadingAsInt;

            return new Rover(rover.Position, newHeading);
        }
    }
}