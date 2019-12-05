using System;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public class LeftPointNode:PointNode
    {
        public readonly double Interval;

        public LeftPointNode(StepPoint stepPoint, double interval): this(stepPoint,interval,new StepPoint[0]) { }

        public LeftPointNode(StepPoint stepPoint, double interval, StepPoint[] previousPoints) : base(stepPoint.Coordinates)
        {
            this.stepPoint = stepPoint;

            if (previousPoints == null)
                throw new ArgumentNullException("previousPoints");
            stepPointsArray = new StepPoint[previousPoints.Length + 1];
            stepPointsArray[0] = stepPoint;
            for(int i=0;i<stepPointsArray.Length-1;i++)
            {
                stepPointsArray[i + 1] = previousPoints[i];
            }

            if (interval < 0)
                throw new ArgumentOutOfRangeException("interval", interval, "the interval must be non-negative");
            Interval = interval;
        }

        //checks if the associated interval contains x
        public override bool Contains(double x)
        {
            if (x <= stepPoint.Coordinates.x && x > (stepPoint.Coordinates.x - Interval)) //checks if the interval contains x
                return true;
            return false;
        }

        private readonly StepPoint stepPoint;
        private readonly StepPoint[] stepPointsArray;
        public override StepPoint[] GetAllValues(double x)
        {
            return (StepPoint[]) stepPointsArray.Clone();
        }

        public override StepPoint GetFirstValue(double x)
        {
            return stepPoint;
        }
    }
}
