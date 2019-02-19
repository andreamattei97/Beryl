using System;
using Beryl.Utilities;

namespace Beryl.NumericalDerivation
{
    abstract class NumericalDerivative
    {
        //the spacing interval
        private double _h;
        public double H
        {
            get
            {
                return _h;
            }

            set
            {
                if (value.IsFinite() || value <= 0 )
                    throw new ArgumentOutOfRangeException("not valid spacing h (h must be a finite positive number");
                _h = value;
            }
        }

        //the function of which the derivative is approximated
        public Func<double, double> Function
        {
            get;
            private set;
        }

        //gets the order of the derivative
        public abstract int Order { get; }

        public NumericalDerivative(Func<double, double> function,double h)
        {
            H = h;
            Function = function;
        }

        //calculates the finite difference of the function on the spacing intervale H
        public abstract double CalculateFiniteDifference(double x);
        //calculates the numerical approximated derivative using the spacing H
        public abstract double CalculateDerivative(double x);

    }
}
