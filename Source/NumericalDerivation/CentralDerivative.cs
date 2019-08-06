using System;

namespace Beryl.NumericalDerivation
{

    //numerical derivative base on central finite difference
    class CentralDerivative
    {

        //internal struct used for representing a term c*f(x+t) of the finite difference
        private struct Term
        {
            public readonly double coefficient;
            public readonly double translation;

            public Term(double coefficient,double translation)
            {
                this.coefficient = coefficient;
                this.translation = translation;
            }
        }

        //derivative functor generator
        public static Function MakeDerivative(Function function, double step, int order)
        {
            CentralDerivative derivative = new CentralDerivative(function, step, order);
            return derivative.CalculateDerivative;
        }

        //derivative functor generator (using the default order)
        public static Function MakeDerivative(Function function, double step)
        {
            return MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        //generates a central derivative generator
        public static DerivativeGenerator MakeGenerator(double step, int order)
        {
            return (Function function) => { return MakeDerivative(function, step, order); };
        }

        //generates a central derivative generator (using the default order)
        public static DerivativeGenerator MakeGenerator(double step)
        {
            return MakeGenerator(step,DefaultNumericalDerivationParameters.DefaultOrder);
        }

        //precalculated Step^n
        private readonly double nStep;

        private readonly Function function;

        //the terms of the finite difference
        private readonly Term[] terms;

        private CentralDerivative(Function function, double step, int order)
        {

            if (order < 0)
                throw new ArgumentOutOfRangeException("order", "The order of the derivative must be non-negative");

            if (step <= 0)
                throw new ArgumentOutOfRangeException("step", "The step of approximation must be positive");

            nStep = Math.Pow(step, order);
            this.function = function;

            terms = new Term[order+1];
            for(int i=0;i<=order;i++)
            {
                double coefficient = (i % 2==0) ? MathExtra.BinomialCoefficient(order,i) : -MathExtra.BinomialCoefficient(order,i);
                double translation = (order / 2.0 - i) * step;
                terms[i] = new Term(coefficient, translation);
            }
        }

        public double CalculateDerivative(double x)
        {
            double result = 0;

            //calculates the finite difference
            foreach(Term term in terms)
            {
                result += term.coefficient * function(x + term.translation);
            }
            //calculates the derivative
            result /= nStep;

            return result;
        }
    }
}
