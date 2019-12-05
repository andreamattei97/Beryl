using System;
using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    public struct ODEInitialConditions
    {
        public readonly Vector2D StartingPoint;
        public readonly Vector2D[] LeftPoints;
        public readonly Vector2D[] RightPoints;

        public ODEInitialConditions(Vector2D startingPoint,Vector2D[] leftPoints,Vector2D[] rightPoints)
        {
            if(!startingPoint.IsFinite())
                throw new ArgumentOutOfRangeException("startingPoint", "Non-finite initial startingPoint");
            StartingPoint = startingPoint;

            if (leftPoints == null)
                throw new ArgumentNullException("leftPoints");
            foreach (Vector2D point in leftPoints)
            {
                if (!point.IsFinite())
                    throw new ArgumentOutOfRangeException("leftPoints", "Non-finite point in leftPoints");
            }
            LeftPoints = leftPoints;

            if (rightPoints == null)
                throw new ArgumentNullException("rightPoints");
            foreach (Vector2D point in rightPoints)
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
