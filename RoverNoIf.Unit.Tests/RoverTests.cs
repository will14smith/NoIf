using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

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
    }
}
