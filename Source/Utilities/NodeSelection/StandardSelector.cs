using System;
using System.Collections.Generic;
using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection
{
    //the standard implementation for a node selector
    public abstract class StandardSelector
    {

        //the node of the starting point
        private readonly CentralNode startingNode;

        //nodes with a left interval
        private readonly LeftNode[] leftNodes;
        //nodes with a right interval
        private readonly RightNode[] rightNodes;

        public StandardSelector(Vector2D startingPoint, List<Vector2D> rightPoints, List<Vector2D> leftPoints)
        {

            //sorts accord to point positions (increasing order for right points, decreasing order for the left ones)
            rightPoints.Sort((Vector2D point1, Vector2D point2) =>
            {
                int comparison = point1.x.CompareTo(point2.x);
                if (comparison == 0) //checks if 2 points overlap
                    throw new ArgumentException("Invalid node point found: the node point overlaps another one x:" + point1.x.ToString(), "rightPoints");
                return comparison;
            });
            leftPoints.Sort((Vector2D point1, Vector2D point2) =>
            {
                int comparison = point1.x.CompareTo(point2.x);
                if (comparison == 0) //checks if 2 points overlap
                    throw new ArgumentException("Invalid node point found: the node point overlaps another one x:" + point1.x.ToString(), "leftPoints");
                return comparison;
            });

            //generates all left nodes
            leftNodes = new LeftNode[leftPoints.Count];
            leftNodes[0] = new LeftNode(leftPoints[0], double.PositiveInfinity);
            for (int i = 1; i < leftPoints.Count; i++)
            {
                if (leftPoints[i].x >= startingPoint.x)
                    throw new ArgumentException("Invalid node point found: the point is greater or equal to the starting one x:" + leftPoints[i].x, "leftPoints");
                leftNodes[i] = new LeftNode(leftPoints[i], leftPoints[i].x - leftPoints[i - 1].x);
            }

            //generates all right nodes
            rightNodes = new RightNode[rightPoints.Count];
            for (int i = 0; i < rightPoints.Count - 1; i++)
            {
                if (rightPoints[i].x <= startingPoint.x)
                    throw new ArgumentException("Invalid node point found: the point is less or equal to the starting one x:" + rightPoints[i].x, "rightPoints");
                rightNodes[i] = new RightNode(rightPoints[i], rightPoints[i + 1].x - rightPoints[i].x);
            }
            rightNodes[rightPoints.Count - 1] = new RightNode(rightPoints[rightPoints.Count - 1], double.PositiveInfinity); //the interval of the last node extends to infinity

            //makes the starting node
            startingNode = new CentralNode(startingPoint, rightPoints[0].x - startingPoint.x, startingPoint.x - leftPoints[leftPoints.Count - 1].x);

        }

        //selects the node associated to the interval that contains x
        public Vector2D SelectNode(double x)
        {
            if (startingNode.Contains(x)) //checks if the point is near the central node
            {
                return startingNode.point;
            }
            else if (x > startingNode.point.x)
            {
                return NodeSearch(x, rightNodes); //right node search
            }
            else
            {
                return NodeSearch(x, leftNodes); //left node search
            }
        }

        //node search algorithm
        protected abstract Vector2D NodeSearch(double x, Node[] nodes);
    }
}
