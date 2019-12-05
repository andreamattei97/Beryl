using Beryl.Utilities.Structures;
using Beryl.Utilities.NodeSelection.PointSelection;

namespace Beryl.ODE
{
    //the argument delegate of ODE solver
    public delegate double ODEFunction(double x, double y);

    //the delegate for an ODE solver for a set of points
    public delegate Vector2D[] ArraySolver(double[] points);

    //the iteration of a single step method
    public delegate Vector2D SingleStepIteration(ODEFunction f,StepPoint point);
}
