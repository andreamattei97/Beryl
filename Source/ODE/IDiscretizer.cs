using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    //the interface for ODE discretizer
    public interface IDiscretizer
    {
        //returns the step for moving to the left of the given point
        double CalculateLeftStep(Point2D currentPoint);
        //returns the step for moving to the right of the given point
        double CalculateRightStep(Point2D currentPoint);
        //find the interpolated step of x, a point in the interval [previousPoint,nextPoint]
        double IntermediateStep(double x, Point2D previousPoint, Point2D nextPoint);
    }
}
