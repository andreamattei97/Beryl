using Beryl.Structures;

namespace Beryl.ODE
{
    //the interface for ODE discretizer
    interface IDiscretizer
    {
        //returns the step for moving to the left of the given point
        double CalculateLeftStep(Vector2D currentPoint);
        //returns the step for moving to the right of the given point
        double CalculateRightStep(Vector2D currentPoint);
        //find the interpolated step of x, a point in the interval [previousPoint,nextPoint]
        double IntermediateStep(double x, Vector2D previousPoint, Vector2D nextPoint);
    }
}
