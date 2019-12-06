using System;

namespace Beryl.NumericalDerivation
{
    /// <summary>
    /// Numerical derivative based on central finite difference
    /// </summary>
    /// <remarks>
    /// <para>This class serves for generating a function that estimates the derivative through central finite differences.</para>
    /// <para>Compulsary parameter: 
    /// <list type="bullet">
    /// <item>
    /// <term>Step:</term>
    /// <description> the step of the difference</description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>Optional parameters:
    /// <list type="bullet">
    /// <item>
    /// <term>Order:</term>
    /// <description> the order of the finite difference</description>
    /// </item>
    /// </list>
    /// See <see cref="DefaultNumericalDerivationParameters"/> for default values of optional parameters.
    /// </para>
    /// <para>For more info on how the method works check the related <a href="https://en.wikipedia.org/wiki/Numerical_differentiation">Wikipedia page</a> </para>
    /// </remarks>
    public class CentralDerivative
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

        /// <summary>
        /// Generates the numerical derivative function based on the central finite difference of given order and step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static Function MakeDerivative(Function function, double step, int order)
        {
            CentralDerivative derivative = new CentralDerivative(function, step, order);
            return derivative.CalculateDerivative;
        }

        /// <summary>
        /// <para>Generates the numerical derivative function based on the central finite difference of the default step and given step.</para> 
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static Function MakeDerivative(Function function, double step)
        {
            return MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        /// <summary>
        /// <para>Provides a generator for numerical derivates based on central finite differences of given order and step.</para> 
        /// </summary>
        /// <param name="step">The step used by the generator</param>
        /// <param name="order">The order of the generated derivatives</param>
        /// <returns>The generator of numerical derivatives of the given step and order</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static DerivativeGenerator MakeGenerator(double step, int order)
        {
            return (Function function) => { return MakeDerivative(function, step, order); };
        }

        /// <summary>
        /// <para>Provides a generator for numerical derivates based on central finite differences of the default order and step.</para> 
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="step">The step used by the generator</param>
        /// <returns>The generator of numerical derivatives of the given step and order</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
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

        private double CalculateDerivative(double x)
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
