using System.Collections.Generic;
using RoverNoIf.Results;

namespace RoverNoIf
{
    public class ObstacleScanner
    {
        private delegate Result ResultFactory(Rover rover);
        private readonly ResultFactory[,] _obstacles;

        public ObstacleScanner(Planet planet, IReadOnlyCollection<Obstacle> obstacles)
        {
            _obstacles = new ResultFactory[planet.Width,planet.Height];
            for (var x = 0; x < planet.Width; x++)
            {
                for (var y = 0; y < planet.Height; y++)
                {
                    _obstacles[x, y] = rover => new Result.Success(rover);
                }
            }

            foreach (var obstactle in obstacles)
            {
                _obstacles[obstactle.Position.X, obstactle.Position.Y] = rover => new Result.Blocked(obstactle, rover);
            }
        }

        public Result Scan(Rover rover)
        {
            return _obstacles[rover.Position.X, rover.Position.Y](rover);
        }
    }
}