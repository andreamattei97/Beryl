using System;

namespace Beryl.Utilities.NodeSelection
{
    public abstract class BinarySelector<ParameterType, ValueType,NodeType> : Selector<ParameterType, ValueType,NodeType> where NodeType:INode<ParameterType,ValueType>
    {
        public BinarySelector(NodeType[] nodes) : base(nodes)
        {
        }

        protected override NodeType NodeSearch(ParameterType x, NodeType[] nodes)
        {
            int inferiorLimit = 0;
            int superiorLimit = nodes.Length - 1;
            int currentPosition = inferiorLimit;

            while (!nodes[currentPosition].Contains(x) && inferiorLimit <= superiorLimit)
            {
                currentPosition = (superiorLimit + inferiorLimit) / 2;

                int direction=SelectDirection(nodes[currentPosition],x);
                
                if(direction>0)
                {
                    inferiorLimit = currentPosition + 1;
                }
                else if(direction==0)
                {
                    break;
                }
                else
                {
                    superiorLimit = currentPosition - 1;
                }
            }

            if(inferiorLimit>superiorLimit)
            {
                throw new SelectorException<ParameterType>(x);
            }

            return nodes[currentPosition];
        }

        protected abstract int SelectDirection(NodeType node, ParameterType x);
    }
}
