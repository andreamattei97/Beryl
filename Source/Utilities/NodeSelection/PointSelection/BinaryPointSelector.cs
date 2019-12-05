using System;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public class BinaryPointSelector : BinarySelector<double, StepPoint,PointNode>
    {

        public static PointSelector MakeSelector(LeftPointNode[] leftNodes, CentralPointNode centralNode, RightPointNode[] rightNodes)
        {
            PointNode[] nodes = new PointNode[leftNodes.Length + rightNodes.Length + 1];
            Array.Copy(leftNodes, nodes, leftNodes.Length);
            nodes[leftNodes.Length] = centralNode;
            Array.Copy(rightNodes, 0, nodes, leftNodes.Length + 1, rightNodes.Length);
            Array.Sort(nodes);
            return new BinaryPointSelector(nodes).SelectNode;
        }

        private BinaryPointSelector(PointNode[] nodes) : base(nodes)
        {
        }

        protected override int SelectDirection(PointNode node, double x)
        {
            if (node.Contains(x))
                return 0;
            else if (node.Coordinates.x > x)
                return -1;
            else
                return 1;
        }

    }
}
