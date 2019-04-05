using System;
using Beryl.Structures;

namespace Beryl.ODE.NodeSelection
{
    //a node associated to a left interval
    class LeftNode:Node
    {
        public readonly double interval;//the dimension of the interval

        public LeftNode(Vector2D point, double interval):base(point)
        {
            if (interval < 0)
                throw new ArgumentOutOfRangeException("interval", interval, "the interval must be non-negative");
            this.interval = interval;
        }

        //checks if the associated interval contains x
        public override bool Contains(double x)
        {
            if (x <= point.x && x > (point.x - interval)) //checks if the interval contains x
                return true;
            return false;
        }
    }
}
