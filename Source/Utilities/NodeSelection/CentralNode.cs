using System;
using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection
{
    //a node associated to a bidirectional interval
    public class CentralNode : Node
    {
        public readonly double rightInterval;//the dimension of the right part of the interval
        public readonly double leftInterval;//the dimension of the left part of the interval

        public CentralNode(Vector2D point,double rightInterval,double leftInterval) : base(point)
        {
            if (leftInterval < 0)
                throw new ArgumentOutOfRangeException("leftInterval", leftInterval, "the left interval must be non-negative");
            this.leftInterval = leftInterval;

            if (rightInterval < 0)
                throw new ArgumentOutOfRangeException("rightInterval", rightInterval, "the right interval must be non-negative");
            this.rightInterval = rightInterval;
        }

        //checks if the associated interval contains x
        public override bool Contains(double x)
        {
            if (x < (point.x + rightInterval) && x > point.x - leftInterval)
                return true;
            return false;
        }
    }
}
