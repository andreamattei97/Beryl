namespace Beryl.Utilities.NodeSelection
{
    /// <summary>
    /// Represents a generic node of a node selector. It defines a range/set of elements of type ParameterType associated to one or more stored values of ValueType.
    /// </summary>
    /// <typeparam name="ParameterType">The type of the elements of the range</typeparam>
    /// <typeparam name="ValueType">The type of the stored value</typeparam>
    public interface INode<ParameterType, ValueType>
    {

        /// <summary>
        /// Return the first stored value associated with the argument
        /// </summary>
        /// <param name="x">The argument that determines the output</param>
        /// <returns>The first value associated with the argument</returns>
        ValueType GetFirstValue(ParameterType x);

        /// <summary>
        /// Return all stored values associated with the argument
        /// </summary>
        /// <param name="x">The argument that determines the output</param>
        /// <returns>The values associated with the argument</returns>
        ValueType[] GetAllValues(ParameterType x);

        /// <summary>
        /// Checks if the argument is contained in the range/set defined by the node
        /// </summary>
        /// <param name="x">The argument to check</param>
        /// <returns>True if the argument is contained in the range/set definied by the node, otherwise returns False</returns>
        bool Contains(ParameterType x);

    }
}
