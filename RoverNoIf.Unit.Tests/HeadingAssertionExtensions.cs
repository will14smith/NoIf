using Xunit;

namespace RoverNoIf.Unit.Tests
{
    public static class HeadingAssertionExtensions
    {
        public static void ShouldBe(this Heading heading, Heading expected)
        {
            Assert.Equal(expected, heading);
        }
    }
}