using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public struct StepPoint
    {
        public Vector2D Coordinates { get; }
        public double Step { get; }

        public StepPoint(Vector2D coordinates,double step)
        {
            Coordinates = coordinates;
            Step = step;
        }
    }
}
