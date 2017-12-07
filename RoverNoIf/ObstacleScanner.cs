using System;
using System.Collections.Generic;
using RoverNoIf.Results;

namespace RoverNoIf
{
    public class ObstacleScanner
    {
        private readonly IReadOnlyCollection<Obstacle> _obstacles;

        public ObstacleScanner(IReadOnlyCollection<Obstacle> obstacles)
        {
            _obstacles = obstacles;
        }

        public Result Scan(Rover rover)
        {
            throw new NotImplementedException();
        }
    }
}