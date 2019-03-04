using Beryl.Utilities;
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
        public static Func<double,double> MakeDerivative(Func<double, double> function, double step, int order=1)
        {
            CentralDerivative derivative = new CentralDerivative(function, step, order);
            return derivative.CalculateDerivative;
        }
        
        //precalculated Step^n
        private readonly double nStep;

        //the derived function wrapped for detecting non-finite returned values
        private readonly Func<double, double> wrappedFunction;

        //the terms of the finite difference
        private readonly Term[] terms;

        private CentralDerivative(Func<double,double> function, double step, int order)
        {

            if (order < 0)
                throw new ArgumentOutOfRangeException("order", "The order of the derivative must be non-negative");

            if (step <= 0)
                throw new ArgumentOutOfRangeException("step", "The step of approximation must be positive");

            nStep = Math.Pow(step, order);
            wrappedFunction = FunctionWrapper.MakeWrapper(function);

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
                result += term.coefficient * wrappedFunction(x + term.translation);
            }
            //calculates the derivative
            result /= nStep;

            return result;
        }
    }
}
