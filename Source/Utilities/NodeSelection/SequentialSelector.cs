using System.Collections.Generic;
using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection
{
    //a standard selector that searches nodes through a sequential search
    public class SequentialSelector:StandardSelector
    {
        //the standard sequential selector generator
        public static NodeSelector SequentialSelectorGenerator(Vector2D startingPoint, List<Vector2D> rightPoints, List<Vector2D> leftPoints)
        {
            return new SequentialSelector(startingPoint, rightPoints, leftPoints).SelectNode;
        }

        public SequentialSelector(Vector2D startingPoint, List<Vector2D> rightPoints, List<Vector2D> leftPoints):base(startingPoint,rightPoints,leftPoints){}

        //sequential search algorithm
        protected override Vector2D NodeSearch(double x, Node[] nodes)
        {
            int currentPosition = 0;

            while (!nodes[currentPosition].Contains(x))
            {
                currentPosition++;
            }

            return nodes[currentPosition].point;

        }
    }
}
