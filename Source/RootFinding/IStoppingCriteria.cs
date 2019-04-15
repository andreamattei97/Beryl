using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    public interface IStoppingCriteria
    {
        bool FullfilCriteria(Vector2D point);

        void SetCriteria(Vector2D referencePoint);
    }
}
