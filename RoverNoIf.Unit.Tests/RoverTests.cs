using Xunit;

namespace RoverNoIf.Unit.Tests
{
    public class RoverTests
    {
        [Fact]
        public void InitialPosition()
        {
            var position = new Position(0, 0);
            var heading = Heading.North;
            var rover = new Rover(position, heading);

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

        public void Move(int initialX, int initialY, Heading initialHeading, string command, int expectedX, int expectedY, Heading expectedHeading)
        {
            var initial = new Rover(new Position(initialX, initialY), initialHeading);

            var after = initial.Move(command);

            after.ShouldBeAt(new Position(expectedX, expectedY));
            after.ShouldHaveHeading(expectedHeading);
        }
    }
}
