using System;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public class SequentialPointSelector : SequentialSelector<double, StepPoint, PointNode>
    {

        public static PointSelector MakeSelector(LeftPointNode[] leftNodes, CentralPointNode centralNode, RightPointNode[] rightNodes)
        {
            PointNode[] nodes = new PointNode[leftNodes.Length + rightNodes.Length + 1];
            Array.Copy(leftNodes, nodes,leftNodes.Length);
            nodes[leftNodes.Length] = centralNode;
            Array.Copy(rightNodes, 0, nodes, leftNodes.Length + 1,rightNodes.Length);
            Array.Sort(nodes);
            return new SequentialPointSelector(nodes, leftNodes.Length).SelectNode;
        }

        private SequentialPointSelector(PointNode[] nodes, int startingIndex) : base(nodes, startingIndex)
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
