using System;

namespace Beryl.Utilities.NodeSelection
{
    /// <summary>
    /// A selector based on binary search algorithm
    /// </summary>
    /// <typeparam name="ParameterType">The type of the parameters searched</typeparam>
    /// <typeparam name="ValueType">The type of the values contained by nodes</typeparam>
    /// <typeparam name="NodeType">The type of nodes (must implement INode interface)</typeparam>
    /// <remarks>
    /// The class stores a set/range of nodes (of type NodeType). Given a parameter (of type ParameterType) the class
    /// searches for the node associated to the parameter through a binary search algorithm and returns the values contained by the node (of type ValueType).
    /// The selector decides using <see cref = "SelectDirection" /> function in which direction (with respect to the central node) the search is performed.
    /// </remarks>
    public abstract class BinarySelector<ParameterType, ValueType,NodeType> : Selector<ParameterType, ValueType,NodeType> where NodeType:INode<ParameterType,ValueType>
    {

        /// <summary>
        /// Initializes the selector.
        /// </summary>
        /// <param name="nodes">The nodes of the selector</param>
        /// <exception cref="ArgumentNullException">Thrown when the passed node array is null</exception>
        public BinarySelector(NodeType[] nodes) : base(nodes)
        {
        }

        /// <summary>
        /// Searches, through a binary search algorithm, for a node associated to the parameter x in the given array of nodes
        /// </summary>
        /// <param name="x">The parameter of the search</param>
        /// <param name="nodes">The nodes to explore</param>
        /// <returns>The node of the array associted to the given parameter</returns>
        /// <exception cref="SelectorException{ParameterType}">Thrown when the searching algorithm has no found a node</exception>
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

        /// <summary>
        /// ciao
        /// </summary>
        /// <param name="node"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        protected abstract int SelectDirection(NodeType node, ParameterType x);
    }
}
