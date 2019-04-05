using System;
using System.Collections.Generic;
using Beryl.Structures;

namespace Beryl.ODE.NodeSelection
{
    //Creates a partition of space associated to a set of points. It uses binary search for finding the interval in which a given point is located
    public class BinarySelector
    {
        //the standard binary selector generator
        public static NodeSelector BinarySelectorGenerator(Vector2D startingPoint, Vector2D[] nodePoints)
        {
            return new BinarySelector(startingPoint, nodePoints).SelectNode;
        }

        //the node of the starting point
        private readonly CentralNode startingNode;

        //nodes with a left interval
        private readonly LeftNode[] leftNodes;
        //nodes with a right interval
        private readonly RightNode[] rightNodes;

        public BinarySelector(Vector2D startingPoint, Vector2D[] nodePoints)
        {

            List<Vector2D> rightPoints = new List<Vector2D>(); //all points greater than the starting one
            List<Vector2D> leftPoints = new List<Vector2D>(); //all points lesser than the starting one

            //divides the points in left and right ones
            foreach (Vector2D point in nodePoints)
            {
                if (point.x > startingPoint.x)
                    rightPoints.Add(point);
                else if (point.x < startingPoint.x)
                    leftPoints.Add(point);
                else //node points that overlap the starting one are not valid
                    throw new ArgumentException("Invalid node point found: the node point overlaps the starting one", "nodePoints");
            }

            //sorts accord to point positions (increasing order for right points, decreasing order for the left ones)
            rightPoints.Sort((Vector2D point1, Vector2D point2) =>
            {
                int comparison = point1.x.CompareTo(point2.x);
                if (comparison == 0) //checks if 2 points overlap
                    throw new ArgumentException("Invalid node point found: the node point overlaps another one", "nodePoints");
                return comparison;
            });
            leftPoints.Sort((Vector2D point1, Vector2D point2) =>
            {
                int comparison = point1.x.CompareTo(point2.x);
                if (comparison == 0) //checks if 2 points overlap
                    throw new ArgumentException("Invalid node point found: the node point overlaps another one", "nodePoints");
                return comparison;
            });

            //generates all left nodes
            leftNodes = new LeftNode[leftPoints.Count];
            leftNodes[0] = new LeftNode(leftPoints[0], double.PositiveInfinity);
            for (int i = 1; i < leftPoints.Count; i++)
            {
                leftNodes[i] = new LeftNode(leftPoints[i], leftPoints[i].x - leftPoints[i - 1].x);
            }

            //generates all right nodes
            rightNodes = new RightNode[rightPoints.Count];
            for (int i = 0; i < rightPoints.Count - 1; i++)
            {
                rightNodes[i] = new RightNode(rightPoints[i], rightPoints[i + 1].x - rightPoints[i].x);
            }
            rightNodes[rightPoints.Count - 1] = new RightNode(rightPoints[rightPoints.Count - 1], double.PositiveInfinity); //the interval of the last node extends to infinity

            //makes the starting node
            startingNode = new CentralNode(startingPoint, rightPoints[0].x - startingPoint.x, startingPoint.x - leftPoints[leftPoints.Count - 1].x);

        }

        //selects the node associated to the interval that contains x using a binary search
        public Vector2D SelectNode(double x)
        {
            if (startingNode.Contains(x)) //checks if the point is near the central node
            {
                return startingNode.point;
            }
            else if (x > startingNode.point.x)
            {
                return BinarySearch(x, rightNodes); //right node search
            }
            else
            {
                return BinarySearch(x, leftNodes); //left node search
            }
        }

        //binary search algorithm
        private Vector2D BinarySearch(double x, Node[] nodes)
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
