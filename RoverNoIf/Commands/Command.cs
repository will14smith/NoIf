﻿using RoverNoIf.Results;

namespace RoverNoIf.Commands
{
    public abstract class Command
    {
        public abstract CommandResult Apply(Rover rover);
    }
}