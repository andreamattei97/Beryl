namespace Beryl.Structures
{
    struct Result
    {
        public Vector2D Point { get; }
        public bool Success { get; }

        public Result(Vector2D point,bool success)
        {
            Point = point;
            Success = success;
        }
    }
}
