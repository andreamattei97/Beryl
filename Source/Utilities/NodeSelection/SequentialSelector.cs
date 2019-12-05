using System;

namespace Beryl.Utilities.NodeSelection
{
    public abstract class SequentialSelector<ParameterType, ValueType, NodeType> : Selector<ParameterType, ValueType, NodeType> where NodeType:INode<ParameterType,ValueType>
    {
        protected readonly int StartingIndex;

        public SequentialSelector(NodeType[] nodes, int startingIndex) : base(nodes)
        {
            if (startingIndex < 0 && startingIndex >= nodes.Length)
                throw new ArgumentOutOfRangeException("startingIndex");
            StartingIndex = startingIndex;
        }

        protected override NodeType NodeSearch(ParameterType x, NodeType[] nodes)
        {
            int currentPosition = StartingIndex;

            int direction = Math.Sign(SelectDirection(nodes[StartingIndex], x));
            if (direction == 0)
                return nodes[StartingIndex];

            while (currentPosition>=0 && currentPosition<nodes.Length && !nodes[currentPosition].Contains(x))
            {
                currentPosition+=direction;
            }

            if(currentPosition==-1 || currentPosition == nodes.Length)
            {
                throw new SelectorException<ParameterType>(x);
            }

            return nodes[currentPosition];

        }

        protected abstract int SelectDirection(NodeType node, ParameterType x);

    }
}
