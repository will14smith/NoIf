using System.Collections.Generic;

namespace RoverNoIf.Commands
{
    public class MoveCommand : Command
    {
        private static readonly IReadOnlyDictionary<Heading, Position> MovementOffsets = new Dictionary<Heading, Position>
        {
            { Heading.North, new Position(1, 0) },
            { Heading.East, new Position(0, 1) },
            { Heading.South, new Position(-1, 0) },
            { Heading.West, new Position(0, -1) },
        };
        private static readonly IReadOnlyDictionary<MoveDirection, Position> DirectionTransforms = new Dictionary<MoveDirection, Position>
        {
            { MoveDirection.Forward, new Position(1, 1) },
            { MoveDirection.Backward, new Position(-1, -1) },
        };

        private readonly MoveDirection _direction;

        public MoveCommand(MoveDirection direction)
        {
            _direction = direction;
        }

        public override Rover Apply(Rover rover)
        {
            var offset = MovementOffsets[rover.Heading];
            var transform = DirectionTransforms[_direction];

            var delta = new Position(offset.X * transform.X, offset.Y * transform.Y);
            var newPosition = new Position(rover.Position.X + delta.X, rover.Position.Y + delta.Y);

            return new Rover(newPosition, rover.Heading);
        }
    }
}