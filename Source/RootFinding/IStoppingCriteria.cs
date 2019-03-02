using Beryl.Structures;

namespace Beryl.RootFinding
{
    interface IStoppingCriteria
    {
        bool FullfilCriteria(Vector2D point);

        void SetCriteria(Vector2D referencePoint);
    }
}
