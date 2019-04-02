using Beryl.Structures;

namespace Beryl.ODE
{
    //used for having uniform discretization (constant step)
    class UniformDiscretizer : IDiscretizer
    {
        //the constant modulus of the step
        public double StepModulus { get; }

        //sets the modulus of the step
        public UniformDiscretizer(double stepModulus) => StepModulus = stepModulus;

        //negative step for moving to the left
        public double CalculateLeftStep(Vector2D currentPoint)
        {
            return -StepModulus;
        }

        //positive step for moving to the right
        public double CalculateRightStep(Vector2D currentPoint)
        {
            return StepModulus;
        }

        //calculates the interpolated step using linear interpolation
        public double IntermediateStep(double x, Vector2D previousPoint, Vector2D nextPoint)
        {
            return x - previousPoint.x;
        }
    }
}
