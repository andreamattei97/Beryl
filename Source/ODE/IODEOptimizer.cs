using Beryl.Utilities.NodeSelection.PointSelection;

namespace Beryl.ODE
{
    public interface IODEOptimizer
    {
        PointSelectorGenerator SelectorGenerator { get; }

        int[] RightPointDistribution();
        int[] LeftPointDistribution();
    }
}
