using System;

namespace RoverNoIf.Results
{
    public abstract class ScanResult
    {
        public abstract T Select<T>(Func<Success, T> success, Func<Blocked, T> blocked);

        public class Success : ScanResult
        {
            public override T Select<T>(Func<Success, T> success, Func<Blocked, T> blocked)
            {
                return success(this);
            }
        }

        public class Blocked : ScanResult
        {
            public Obstacle Obstacle { get; }

            public Blocked(Obstacle obstacle)
            {
                Obstacle = obstacle;
            }

            public override T Select<T>(Func<Success, T> success, Func<Blocked, T> blocked)
            {
                return blocked(this);
            }
        }
    }
}
