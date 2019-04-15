using System;
using Beryl.Utilities.Math;

namespace Beryl.NumericalDerivation
{
    //numerical derivative base on forward finite difference
    class ForwardDerivative
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
        public static Function MakeDerivative(Function function, double step, int order=1)
        {
            ForwardDerivative derivative = new ForwardDerivative(function, step, order);
            return derivative.CalculateDerivative;
        }

        //precalculated Step^n
        private readonly double nStep;

        private readonly Function function;

        //the terms of the finite difference
        private readonly Term[] terms;

        private ForwardDerivative(Function function, double step, int order)
        {

            if (order < 0)
                throw new ArgumentOutOfRangeException("order", "The order of the derivative must be non-negative");

            if (step <= 0)
                throw new ArgumentOutOfRangeException("step", "The step of approximation must be positive");
            
            nStep = Math.Pow(step, order);
            this.function = function;

            terms = new Term[order + 1];
            for (int i = 0; i <= order; i++)
            {
                double coefficient = (i % 2 == 0) ? MathExtra.BinomialCoefficient(order, i) : -MathExtra.BinomialCoefficient(order, i);
                double translation = (order-i) * step;
                terms[i] = new Term(coefficient, translation);
            }
        }

        public double CalculateDerivative(double x)
        {
            double result = 0;

            //calculates the finite difference
            foreach (Term term in terms)
            {
                result += term.coefficient * function(x + term.translation);
            }
            //calculates the derivative
            result /= nStep;

            return result;
        }
    }
}

