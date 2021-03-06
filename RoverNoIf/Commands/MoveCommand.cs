﻿using System.Collections.Generic;
using RoverNoIf.Results;

namespace RoverNoIf.Commands
{
    public class MoveCommand : Command
    {
        private static readonly IReadOnlyDictionary<Heading, PositionDelta> MovementOffsets = new Dictionary<Heading, PositionDelta>
        {
            { Heading.North, new PositionDelta(1, 0) },
            { Heading.East, new PositionDelta(0, 1) },
            { Heading.South, new PositionDelta(-1, 0) },
            { Heading.West, new PositionDelta(0, -1) },
        };
        private static readonly IReadOnlyDictionary<MoveDirection, PositionDelta> DirectionTransforms = new Dictionary<MoveDirection, PositionDelta>
        {
            { MoveDirection.Forward, new PositionDelta(1, 1) },
            { MoveDirection.Backward, new PositionDelta(-1, -1) },
        };

        private readonly MoveDirection _direction;

        public MoveCommand(MoveDirection direction)
        {
            _direction = direction;
        }

        public override CommandResult Apply(Rover rover)
        {
            var offset = MovementOffsets[rover.Heading];
            var transform = DirectionTransforms[_direction];

            var delta = new PositionDelta(offset.X * transform.X, offset.Y * transform.Y);
            var newPosition = new PositionDelta(rover.Position.X + delta.X, rover.Position.Y + delta.Y);

            var planet = rover.Position.Planet;
            var newPositionOnPlanet = new Position(
                planet: planet,
                x: (newPosition.X + planet.Width) % planet.Width,
                y: (newPosition.Y + planet.Height) % planet.Height);

            var newRover = rover.WithPosition(newPositionOnPlanet);
            var scanner = rover.ObstacleScanner;
            var scanResult = scanner.Scan(newRover);

            return scanResult.Select<CommandResult>(
                success: _ => new CommandResult.Success(newRover),    
                blocked: blocked => new CommandResult.Blocked(blocked.Obstacle, rover)
            );
        }

        private class PositionDelta
        {
            public int X { get; }
            public int Y { get; }

            public PositionDelta(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}