using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public struct StepPoint
    {
        public Point2D Coordinates { get; }
        public double Step { get; }

        public StepPoint(Point2D coordinates,double step)
        {
            Coordinates = coordinates;
            Step = step;
        }
    }
}
