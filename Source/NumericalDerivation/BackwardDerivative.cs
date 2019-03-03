using System;
using Beryl.Utilities;

namespace Beryl.NumericalDerivation
{
    //numerical derivative based on bacward finite difference
    class BackwardDerivative
    {
        //internal struct used for representing a term  c*f(x+t) of the finite difference
        private struct Term
        {
            public readonly double coefficient;
            public readonly double translation;

            public Term(double coefficient, double translation)
            {
                this.coefficient = coefficient;
                this.translation = translation;
            }
        }

        //derivative functor generator
        public static Func<double, double> MakeDerivative(Func<double, double> function, int order, double step)
        {
            BackwardDerivative derivative = new BackwardDerivative(function, order, step);
            return derivative.CalculateDerivative;
        }

        //the order of the derivative
        private int _order;
        public int Order
        {
            get { return _order; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Order", "The order of the derivative must be non-negative");
                _order = value;
            }
        }

        //the step used for calculating the derivative
        private double _step;
        public double Step
        {
            get { return _step; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Order", "The order of the derivative must be positive");
                _step = value;
            }
        }
        //precalculated Step^n
        private readonly double nStep;

        //the derived function wrapped for detecting non-finite returned values
        private readonly Func<double, double> wrappedFunction;

        //the terms of the finite difference
        private readonly Term[] terms;

        public BackwardDerivative(Func<double, double> function, int order, double step)
        {
            Order = order;
            Step = step;
            nStep = Math.Pow(step, order);
            wrappedFunction = FunctionWrapper.MakeWrapper(function);

            terms = new Term[order + 1];
            for (int i = 0; i <= order; i++)
            {
                double coefficient = (i % 2 == 0) ? MathExtra.BinomialCoefficient(order, i) : -MathExtra.BinomialCoefficient(order, i);
                double translation = -i* Step;
                terms[i] = new Term(coefficient, translation);
            }
        }

        public double CalculateDerivative(double x)
        {
            double result = 0;

            //calculates the finite difference
            foreach (Term term in terms)
            {
                result += term.coefficient * wrappedFunction(x + term.translation);
            }
            //calculates the derivative
            result /= nStep;

            return result;
        }
    }
}

