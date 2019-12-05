using System;

namespace Beryl.Utilities.NodeSelection
{
    //the standard implementation for a node selector
    public abstract class Selector<ParameterType,ValueType,NodeType> where NodeType:INode<ParameterType,ValueType>
    {
        private NodeType[] nodes;

        public Selector(NodeType[] nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException("nodes");
            this.nodes = nodes;
        }

        //selects the node associated to the interval that contains x
        public ValueType[] SelectNode(ParameterType x)
        {
            NodeType searchResult = NodeSearch(x, nodes);
            if(searchResult!=null)
            {
                return searchResult.GetAllValues(x);
            }
            else
            {
                throw new Exception("No node found for the given parameter");
            }
        }

        //node search algorithm
        protected abstract NodeType NodeSearch(ParameterType x, NodeType[] nodes);
    }
}
