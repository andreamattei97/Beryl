using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    //used for having uniform discretization (constant step)
    public class UniformDiscretizer : IDiscretizer
    {
        //the constant modulus of the step
        public double StepModulus { get; }

        //sets the modulus of the step
        public UniformDiscretizer(double stepModulus) => StepModulus = stepModulus;

        //negative step for moving to the left
        public double CalculateLeftStep(Point2D currentPoint)
        {
            return -StepModulus;
        }

        //positive step for moving to the right
        public double CalculateRightStep(Point2D currentPoint)
        {
            return StepModulus;
        }

        //calculates the interpolated step using linear interpolation
        public double IntermediateStep(double x, Point2D previousPoint, Point2D nextPoint)
        {
            return x - previousPoint.x;
        }
    }
}
