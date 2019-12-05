using System;
using System.Collections.Generic;
using System.Text;

namespace Beryl.Utilities.NodeSelection.PointSelection
{
    public delegate StepPoint[] PointSelector(double x);
    public delegate PointSelector PointSelectorGenerator(LeftPointNode[] leftNodes, CentralPointNode centralNode, RightPointNode[] rightNode);
}
