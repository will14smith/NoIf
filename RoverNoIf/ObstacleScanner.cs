using System;
using System.Collections.Generic;
using RoverNoIf.Commands;

namespace RoverNoIf
{
    public class ObstacleScanner
    {
        private readonly IReadOnlyCollection<Obstacle> _obstacles;

        public ObstacleScanner(IReadOnlyCollection<Obstacle> obstacles)
        {
            _obstacles = obstacles;
        }

        public bool IsDirectionBlocked(Rover rover, MoveDirection direction)
        {
            throw new NotImplementedException();
        }
    }
}