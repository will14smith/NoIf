namespace RoverNoIf.Unit.Tests
{
    public static class RoverAssertionExtensions
    {
        public static void ShouldBeAt(this Rover rover, Position expectedPosition)
        {
            rover.Position.ShouldBe(expectedPosition);
        }
        public static void ShouldHaveHeading(this Rover rover, Heading expectedHeading)
        {
            rover.Heading.ShouldBe(expectedHeading);
        }
    }
}