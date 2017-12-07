using Xunit;

namespace RoverNoIf.Unit.Tests
{
    public static class PositionAssertionExtensions
    {
        public static void ShouldBe(this Position position, Position expected)
        {
            Assert.Equal((x: expected.X, y: expected.Y), (x: position.X, y: position.Y));
        }
    }
}