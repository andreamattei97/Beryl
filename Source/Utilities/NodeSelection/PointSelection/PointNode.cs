using System;
using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public abstract class PointNode : INode<double, StepPoint>, IComparable<PointNode>, IComparable
    {

        public Vector2D Coordinates
        {
            get;
        }

        public PointNode(Vector2D coordinates)
        {
            Coordinates = coordinates;
        }

        public abstract bool Contains(double x);

        public abstract StepPoint[] GetAllValues(double x);

        public abstract StepPoint GetFirstValue(double x);

        public int CompareTo(PointNode other)
        {
            if (other==null)
                throw new ArgumentNullException();
            return Coordinates.x.CompareTo(other.Coordinates.x);
        }

        public int CompareTo(object obj)
        {
            PointNode other = obj as PointNode;
            if (obj == null)
                throw new ArgumentException("The comparand is not a PointNode");
            return Coordinates.x.CompareTo(other.Coordinates);
            throw new NotImplementedException();
        }
    }
}
