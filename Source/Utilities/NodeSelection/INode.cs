namespace Beryl.Utilities.NodeSelection
{
    public interface INode<ParameterType, ValueType>
    {
        ValueType GetFirstValue(ParameterType x);
        ValueType[] GetAllValues(ParameterType x);
        bool Contains(ParameterType x);
    }
}
