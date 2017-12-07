using System;
using System.Collections.Generic;
using System.Text;

namespace RoverNoIf.Results
{
    public abstract class Result
    {
        public class Success : Result
        {
            public Rover Rover { get; }

            public Success(Rover rover)
            {
                Rover = rover;
            }
        }
    }
}
