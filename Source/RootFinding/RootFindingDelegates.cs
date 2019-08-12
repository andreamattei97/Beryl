using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    public delegate Vector2D BisectionSolverFunction(double inf, double sup);

    public delegate Vector2D NewtonSolverFunction(double x0, int multiplicity = DefaultRootFindingParameters.DEFAULT_NEWTON_METHOD_MULTIPLICITY);

    public delegate Vector2D SecantSolverFunction(double x0, double x1);
}
