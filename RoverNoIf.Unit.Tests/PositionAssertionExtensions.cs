using Xunit;

namespace RoverNoIf.Unit.Tests
{
    public static class PositionAssertionExtensions
    {
        public static void ShouldBe(this Position position, Position expected)
        {
            // make sure we are on the correct planet
            Assert.Equal(expected.Planet, position.Planet);
            // now we are pretty close, check the actual coordinates
            Assert.Equal((x: expected.X, y: expected.Y), (x: position.X, y: position.Y));
        }
    }
}