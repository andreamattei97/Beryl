using System;
using Beryl.Utilities.NodeSelection;

namespace Beryl.ODE
{
    public struct OptimizationOptions
    {
        public NodeSelectorGenerator SelectorGenerator { get; }
        public int LeftIntervalsSpan { get; }
        public int RightIntervalsSpan { get; }
        public int LeftIntervals { get; }
        public int RightIntervals { get; }

        public OptimizationOptions(NodeSelectorGenerator selectorGenerator,int rightIntervals,int leftIntervals,int rightIntervalsSpan,int leftIntervalsSpan)
        {
            if (selectorGenerator == null)
                throw new ArgumentException("selectorGenerator", "Null node selector generator passed");
            SelectorGenerator = selectorGenerator;
            if (rightIntervals <= 0)
                throw new ArgumentOutOfRangeException("rightIntervals", "The number of right intervals must be positive");
            RightIntervals = rightIntervals;
            if (leftIntervals <= 0)
                throw new ArgumentOutOfRangeException("leftIntervals", "The number of left intervals must be positive");
            LeftIntervals = leftIntervals;
            if(rightIntervalsSpan <= 0)
                throw new ArgumentOutOfRangeException("rightIntervalsSpan", "The span of right intervals must be positive");
            RightIntervalsSpan = rightIntervalsSpan;
            if (leftIntervalsSpan <= 0)
                throw new ArgumentOutOfRangeException("leftIntervalsSpan", "The span of left intervals must be positive");
            LeftIntervalsSpan = leftIntervalsSpan;
        }

        public OptimizationOptions(NodeSelectorGenerator selectorGenerator,int rightIntervals,int leftIntervals,int intervalsSpan):
            this(selectorGenerator,rightIntervals,leftIntervals,intervalsSpan,intervalsSpan)
        { }
    }
}
