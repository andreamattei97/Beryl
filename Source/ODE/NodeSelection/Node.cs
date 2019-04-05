using Beryl.Structures;

namespace Beryl.ODE.NodeSelection
{
    //the base class for nodes
    abstract class Node
    {
        //the coordinate of the node
        public readonly Vector2D point;

        public Node(Vector2D point)
        {
            this.point = point;
        }

        //returns true if the given point is contained in the range associated to the node
        public abstract bool Contains(double x);

    }
}
