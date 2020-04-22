using Beryl;

namespace Beryl.Utilities.Structures
{
    public interface IMap<T> where T : IMap<T>
    {
        T ApplyFunction(ArrayFunction function);
    }
}