using System;
using Beryl.Utilities;

namespace Beryl.NumericalDerivation
{

    //first order numerical derivative with backward finite difference
    class BackwardFirstDerivative :NumericalDerivative
    {
        public BackwardFirstDerivative(Func<double, double> function, double h) : base(function, h) { }

        public override int Order => 1;

        public override double CalculateDerivative(double x)
        {
            double result = 0;

            result = (Function(x) - Function(x - H)) / H;

            if (!result.IsFinite())
            {
                throw new CalculationException("Invalid derivated evaluated", passedFunction: Function);
            }

            return result;
        }

        public override double CalculateFiniteDifference(double x)
        {
            double result = 0;

            result = (Function(x) - Function(x - H));

            if (!result.IsFinite())
            {
                throw new CalculationException("Invalid function evaluated", passedFunction: Function);
            }

            return result;
        }
    }
}
