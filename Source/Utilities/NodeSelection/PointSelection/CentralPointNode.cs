using System;
using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public class CentralPointNode : PointNode
    {
        private readonly StepPoint[] RightPreviousPoints;
        private readonly StepPoint[] LeftPreviousPoints;

        public readonly double RightInterval;//the dimension of the right part of the interval
        public readonly double LeftInterval;//the dimension of the left part of the interval

        public CentralPointNode(Point2D coordinates, double rightStep, double leftStep, double rightInterval, double leftInterval) : 
            this(coordinates, new StepPoint[] { new StepPoint(coordinates, rightStep) }, new StepPoint[] { new StepPoint(coordinates, leftStep) },rightInterval,leftInterval)
        {
        }

        public CentralPointNode(Point2D coordinates, StepPoint[] rightPreviousPoints, StepPoint[] leftPreviousPoints, double rightInterval, double leftInterval):base(coordinates)
        {
            if (leftInterval < 0)
                throw new ArgumentOutOfRangeException("leftInterval", leftInterval, "the left interval must be non-negative");
            LeftInterval = leftInterval;

            if (rightInterval < 0)
                throw new ArgumentOutOfRangeException("rightInterval", rightInterval, "the right interval must be non-negative");
            RightInterval = rightInterval;

            if (rightPreviousPoints == null)
            {
                throw new ArgumentNullException("rightPreviousPoints");
            }
            else if(rightPreviousPoints.Length==0)
            {
                throw new ArgumentOutOfRangeException("rightPreviousPoints", "The right previous points array is empty");
            }
            RightPreviousPoints = rightPreviousPoints;

            if (leftPreviousPoints == null)
            {
                throw new ArgumentNullException("leftPreviousPoints");
            }
            else if (leftPreviousPoints.Length == 0)
            {
                throw new ArgumentOutOfRangeException("leftPreviousPoints", "The left previous points array is empty");
            }
            LeftPreviousPoints = leftPreviousPoints;

        }
        //checks if the associated interval contains x
        public override bool Contains(double x)
        {
            if (x < (Coordinates.x + RightInterval) && x > Coordinates.x - LeftInterval)
                return true;
            return false;
        }

        public override StepPoint[] GetAllValues(double x)
        {
            if (x >= Coordinates.x)
                return (StepPoint[])RightPreviousPoints.Clone();
            else
                return (StepPoint[])LeftPreviousPoints.Clone();
        }

        public override StepPoint GetFirstValue(double x)
        {
            if (x < Coordinates.x)
                return RightPreviousPoints[0];
            else
                return RightPreviousPoints[0];
        }
    }
}
