using RoverNoIf.Results;
using Xunit;

namespace RoverNoIf.Unit.Tests
{
    public class RoverTests
    {
        public const int PlanetWidth = 100;
        public const int PlanetHeight = 100;
        public static readonly Planet Pluto = new Planet(PlanetWidth, PlanetHeight);

        public static readonly ObstacleScanner FlatPlanet = new ObstacleScanner(Pluto, new Obstacle[0]);

        [Fact]
        public void InitialPosition()
        {
            var position = new Position(Pluto, 0, 0);
            var heading = Heading.North;
            var rover = new Rover(position, heading, FlatPlanet);

            rover.ShouldBeAt(position);
            rover.ShouldHaveHeading(heading);
        }

        [Theory]

        [InlineData(0, 0, Heading.North, "F", 1, 0, Heading.North)]
        [InlineData(1, 0, Heading.North, "B", 0, 0, Heading.North)]
        [InlineData(0, 0, Heading.East, "F", 0, 1, Heading.East)]
        [InlineData(0, 1, Heading.East, "B", 0, 0, Heading.East)]
        [InlineData(1, 0, Heading.South, "F", 0, 0, Heading.South)]
        [InlineData(0, 0, Heading.South, "B", 1, 0, Heading.South)]
        [InlineData(0, 1, Heading.West, "F", 0, 0, Heading.West)]
        [InlineData(0, 0, Heading.West, "B", 0, 1, Heading.West)]

        [InlineData(1, 1, Heading.North, "L", 1, 1, Heading.East)]
        [InlineData(1, 1, Heading.North, "R", 1, 1, Heading.West)]
        [InlineData(1, 1, Heading.East, "L", 1, 1, Heading.South)]
        [InlineData(1, 1, Heading.East, "R", 1, 1, Heading.North)]
        [InlineData(1, 1, Heading.South, "L", 1, 1, Heading.West)]
        [InlineData(1, 1, Heading.South, "R", 1, 1, Heading.East)]
        [InlineData(1, 1, Heading.West, "L", 1, 1, Heading.North)]
        [InlineData(1, 1, Heading.West, "R", 1, 1, Heading.South)]

        [InlineData(0, 0, Heading.South, "F", PlanetWidth - 1, 0, Heading.South)]
        [InlineData(0, 0, Heading.West, "F", 0, PlanetHeight - 1, Heading.West)]
        [InlineData(PlanetWidth - 1, PlanetHeight - 1, Heading.North, "F", 0, PlanetHeight - 1, Heading.North)]
        [InlineData(PlanetWidth - 1, PlanetHeight - 1, Heading.East, "F", PlanetWidth - 1, 0, Heading.East)]

        public void Move(int initialX, int initialY, Heading initialHeading, string command, int expectedX, int expectedY, Heading expectedHeading)
        {
            var initial = new Rover(new Position(Pluto, initialX, initialY), initialHeading, FlatPlanet);

            var after = initial.Move(command);

            Assert.IsType<CommandResult.Success>(after);
            after.Rover.ShouldBeAt(new Position(Pluto, expectedX, expectedY));
            after.Rover.ShouldHaveHeading(expectedHeading);
        }

        [Fact]
        public void UnknownCommand()
        {
            var initial = new Rover(new Position(Pluto, 0, 0), Heading.North, FlatPlanet);

            var after = initial.Move("FXF");

            Assert.IsType<CommandResult.Unknown>(after);
            after.Rover.ShouldBeAt(new Position(Pluto, 1, 0));
            after.Rover.ShouldHaveHeading(Heading.North);
        }

        [Fact]
        public void MoveWithObstables()
        {
            var bumpyPlanet = new ObstacleScanner(Pluto, new[] { new Obstacle(new Position(Pluto, 2, 0)) });
            var initial = new Rover(new Position(Pluto, 0, 0), Heading.North, bumpyPlanet);

            var after = initial.Move("FFF");

            Assert.IsType<CommandResult.Blocked>(after);
            after.Rover.ShouldBeAt(new Position(Pluto, 1, 0));
            after.Rover.ShouldHaveHeading(Heading.North);
        }
    }
}
