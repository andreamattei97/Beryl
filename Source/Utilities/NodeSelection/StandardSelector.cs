using System;

namespace Beryl.Utilities.NodeSelection
{
    //the standard implementation for a node selector
    /// <summary>
    /// Base node selector.
    /// </summary>
    /// <typeparam name="ParameterType">The type of the parameters searched</typeparam>
    /// <typeparam name="ValueType">The type of the values contained by nodes</typeparam>
    /// <typeparam name="NodeType">The type of nodes (must implement INode interface)</typeparam>
    /// <remarks>
    /// This class is the basis to all node selectors.
    /// A selector contains a set/range of nodes (represented by the interface INode), each node contains one or multiple objects (of type ValueType).
    /// Given a parameter (of type ParameterType) a selector search for the node associated to the parameter and returns its values.
    /// </remarks>
    public abstract class Selector<ParameterType,ValueType,NodeType> where NodeType:INode<ParameterType,ValueType>
    {
        private NodeType[] nodes;

        /// <summary>
        /// Initializes the selector.
        /// </summary>
        /// <param name="nodes">The nodes of the selector</param>
        /// <exception cref="ArgumentNullException">Thrown when the passed node array is null</exception>
        protected Selector(NodeType[] nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException("nodes");
            this.nodes = nodes;
        }


        /// <summary>
        /// Selects the node associated to the range/set that contains x.
        /// </summary>
        /// <param name="x">The element to search</param>
        /// <returns>The elements associated to the node and to the parameter x. If x is not associated to any node it returns null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed argument is null</exception>
        /// <exception cref="ArgumentException">No node associated to the given parameter is found</exception>
        public ValueType[] SelectNode(ParameterType x)
        {
            if (x == null)
                throw new ArgumentNullException("x");
            NodeType searchResult = NodeSearch(x, nodes);
            if(searchResult!=null)
            {
                ValueType[] result = searchResult.GetAllValues(x);
                if (result == null)
                    throw new ArgumentException("No node associated to the given parameter is found", "x");
                return searchResult.GetAllValues(x);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Searches for a node associated to the parameter x in the given array of nodes
        /// </summary>
        /// <param name="x">The parameter of the search</param>
        /// <param name="nodes">The nodes to explore</param>
        /// <returns>The node of the array associted to the given parameter</returns>
        protected abstract NodeType NodeSearch(ParameterType x, NodeType[] nodes);
    }
}
