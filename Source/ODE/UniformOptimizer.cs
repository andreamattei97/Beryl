using System;
using Beryl.Utilities.NodeSelection.PointSelection;

namespace Beryl.ODE
{
    public class UniformOptimizer : IODEOptimizer
    {

        public PointSelectorGenerator SelectorGenerator { get; }
        public int LeftIntervalsSpan { get; }
        public int RightIntervalsSpan { get; }
        public int LeftIntervals { get; }
        public int RightIntervals { get; }

        public UniformOptimizer(PointSelectorGenerator selectorGenerator, int rightIntervals, int leftIntervals, int rightIntervalsSpan, int leftIntervalsSpan)
        {
            if (selectorGenerator == null)
                throw new ArgumentException("selectorGenerator", "Null node selector generator passed");
            SelectorGenerator = selectorGenerator;
            if (rightIntervals < 0)
                throw new ArgumentOutOfRangeException("rightIntervals", "The number of right intervals must be non-negative");
            RightIntervals = rightIntervals;
            if (leftIntervals < 0)
                throw new ArgumentOutOfRangeException("leftIntervals", "The number of left intervals must be non-negative");
            LeftIntervals = leftIntervals;
            if (rightIntervalsSpan <= 0)
                throw new ArgumentOutOfRangeException("rightIntervalsSpan", "The span of right intervals must be positive");
            RightIntervalsSpan = rightIntervalsSpan;
            if (leftIntervalsSpan <= 0)
                throw new ArgumentOutOfRangeException("leftIntervalsSpan", "The span of left intervals must be positive");
            LeftIntervalsSpan = leftIntervalsSpan;
        }

        public UniformOptimizer(PointSelectorGenerator selectorGenerator, int rightIntervals, int leftIntervals, int intervalsSpan) :
            this(selectorGenerator, rightIntervals, leftIntervals, intervalsSpan, intervalsSpan)
        { }

        public int[] LeftPointDistribution()
        {
            int[] result = new int[LeftIntervals];
            for(int i=0;i<LeftIntervals;i++)
            {
                result[i] = LeftIntervalsSpan;
            }

            return result;
        }

        public int[] RightPointDistribution()
        {
            int[] result = new int[RightIntervals];
            for (int i = 0; i < RightIntervals; i++)
            {
                result[i] = RightIntervalsSpan;
            }

            return result;
        }
    }
}
