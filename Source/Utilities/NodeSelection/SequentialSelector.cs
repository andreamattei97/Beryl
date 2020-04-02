using System;

namespace Beryl.Utilities.NodeSelection
{

    /// <summary>
    /// A selector based on sequential search algorithm
    /// </summary>
    /// <typeparam name="ParameterType">The type of the parameters searched</typeparam>
    /// <typeparam name="ValueType">The type of the values contained by nodes</typeparam>
    /// <typeparam name="NodeType">The type of nodes (must implement INode interface)</typeparam>
    /// <remarks>
    /// The class stores a set/range of nodes (of type NodeType). Given a parameter (of type ParameterType) the class
    /// searches for the node associated to the parameter through a sequential search algorithm and returns the values contained by the node (of type ValueType).
    /// <para>
    /// It is possible to set the initial index of the search, the selector decides using <see cref="SelectDirection"/> function in which direction the search is performed.
    /// </para>
    /// </remarks>
    public abstract class SequentialSelector<ParameterType, ValueType, NodeType> : Selector<ParameterType, ValueType, NodeType> where NodeType:INode<ParameterType,ValueType>
    {
        /// <summary>
        /// The starting index of the node sequence from which the search starts
        /// </summary>
        protected int StartingIndex { get; }

        /// <summary>
        /// Initializes the selector.
        /// </summary>
        /// <param name="nodes">The nodes of the selector</param>
        /// <param name="startingIndex">The starting index of nodes from which the search starts</param>
        /// <exception cref="ArgumentNullException">Thrown when the passed node array is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the starting index is not a valid index for the nodes array</exception>
        public SequentialSelector(NodeType[] nodes, int startingIndex) : base(nodes)
        {
            if (startingIndex < 0 && startingIndex >= nodes.Length)
                throw new ArgumentOutOfRangeException("startingIndex");
            StartingIndex = startingIndex;
        }

        /// <summary>
        /// Searches, through a sequential search algorithm, for a node associated to the parameter x in the given array of nodes
        /// </summary>
        /// <param name="x">The parameter of the search</param>
        /// <param name="nodes">The nodes to explore</param>
        /// <returns>The node of the array associted to the given parameter</returns>
        /// <exception cref="SelectorException{ParameterType}">Thrown when the searching algorithm has no found a node</exception>
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

        /// <summary>
        /// Selects the direction of the search with respect to the given node according to the given parameter
        /// </summary>
        /// <param name="node">The reference node</param>
        /// <param name="x">The parameter to evaluate</param>
        protected abstract int SelectDirection(NodeType node, ParameterType x);

    }
}
