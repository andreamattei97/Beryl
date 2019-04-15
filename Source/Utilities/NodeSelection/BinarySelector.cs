using System.Collections.Generic;
using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection
{
    //Creates a partition of space associated to a set of points. It uses binary search for finding the interval in which a given point is located
    public class BinarySelector:StandardSelector
    {
        //the standard binary selector generator
        public static NodeSelector BinarySelectorGenerator(Vector2D startingPoint, List<Vector2D> rightPoints, List<Vector2D> leftPoints)
        {
            return new BinarySelector(startingPoint, rightPoints, leftPoints).SelectNode;
        }

        public BinarySelector(Vector2D startingPoint,List<Vector2D> rightPoints, List<Vector2D>leftPoints):base(startingPoint,rightPoints,leftPoints){}

        //binary search algorithm
        protected override Vector2D NodeSearch(double x, Node[] nodes)
        {
            int inferiorLimit = 0;
            int superiorLimit = nodes.Length - 1;
            int currentPosition = inferiorLimit;

            while (!nodes[currentPosition].Contains(x) && inferiorLimit<=superiorLimit)
            {
                currentPosition = (superiorLimit + inferiorLimit) / 2;
                if (x < nodes[currentPosition].point.x)
                {
                    superiorLimit = currentPosition-1;
                }
                else
                {
                    inferiorLimit = currentPosition+1;
                }
            }

            return nodes[currentPosition].point;
        }
    }
}
