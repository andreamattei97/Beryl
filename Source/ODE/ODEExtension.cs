using Beryl.Structures;

namespace Beryl.ODE
{
    //the argument delegate of ODE solver
    public delegate double ODEFunction(double x, double y);

    //the delegate for a node selector
    public delegate Vector2D NodeSelector(double x);
    //the delegate for generating a node selector
    public delegate NodeSelector NodeSelectorGenerator(Vector2D startingPoint, Vector2D[] nodePoints);

    public static class ODEExtension
    {

    }
}
