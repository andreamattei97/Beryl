using System;
using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    public struct ODEInitialConditions
    {
        public readonly Point2D StartingPoint;
        public readonly Point2D[] LeftPoints;
        public readonly Point2D[] RightPoints;

        public ODEInitialConditions(Point2D startingPoint,Point2D[] leftPoints,Point2D[] rightPoints)
        {
            if(!startingPoint.IsFinite())
                throw new ArgumentOutOfRangeException("startingPoint", "Non-finite initial startingPoint");
            StartingPoint = startingPoint;

            if (leftPoints == null)
                throw new ArgumentNullException("leftPoints");
            foreach (Point2D point in leftPoints)
            {
                if (!point.IsFinite())
                    throw new ArgumentOutOfRangeException("leftPoints", "Non-finite point in leftPoints");
            }
            LeftPoints = leftPoints;

            if (rightPoints == null)
                throw new ArgumentNullException("rightPoints");
            foreach (Point2D point in rightPoints)
            {
                if (!point.IsFinite())
                    throw new ArgumentOutOfRangeException("rightPoints", "Non-finite point in rightPoints");
            }
            RightPoints = rightPoints;
        }

        public bool CheckOrder(int order)
        {
            return LeftPoints.Length <= (order - 1) && RightPoints.Length <= (order - 1);
        }
    }
}
