using System.Collections.Generic;
using Beryl.Utilities.Structures;

namespace Beryl.Utilities.NodeSelection
{
    //the delegate for a node selector
    public delegate Vector2D NodeSelector(double x);
    //the delegate for generating a node selector
    public delegate NodeSelector NodeSelectorGenerator(Vector2D startingPoint, List<Vector2D> rightPoints, List<Vector2D> leftPoints);

}
