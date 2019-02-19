using System;
using Beryl.Utilities;

namespace Beryl.NumericalDerivation
{
    //first order numerical derivative with forward finite difference
    class ForwardFirstDerivative : NumericalDerivative
    {

        public ForwardFirstDerivative(Func<double, double> function, double h) : base(function, h){}

        public override int Order => 1;

        public override double CalculateDerivative(double x)
        {
            double result = 0;
            
            result = (Function(x + H) - Function(x)) / H;

            if(!result.IsFinite())
            {
                throw new CalculationException("Invalid derivated evaluated", passedFunction: Function);
            }

            return result;
        }
        
        public override double CalculateFiniteDifference(double x)
        {
            double result = 0;
            
            result = (Function(x + H) - Function(x));

            if (!result.IsFinite())
            {
                throw new CalculationException("Invalid function evaluated", passedFunction: Function);
            }

            return result;
        }
    }
}
