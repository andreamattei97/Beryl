using System;

namespace Beryl.NumericalDerivation
{
    /// <summary>
    /// Numerical derivative based on forward finite difference
    /// </summary>
    /// <remarks>
    /// <para>This class serves for generating a function that estimates the derivative through forward finite differences of uniform step.</para>
    /// <para>It is possible to choose the order of the derivative. If not specified the first derivative will be generated.</para>
    /// <para>
    /// The step of finite differences is an optional parameter, see <see cref="DefaultNumericalDerivationParameters"/> for its default value.
    /// </para>
    /// <para>For more info on how the method works check the related <a href="https://en.wikipedia.org/wiki/Numerical_differentiation">Wikipedia page</a> </para>
    /// </remarks>
    public class ForwardDerivative
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

        /// <summary>
        /// <para>Generates the numerical derivative of the given order of the function based on forward finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function MakeDerivative(Function function, double step, int order)
        {
            ForwardDerivative derivative = new ForwardDerivative(function, step, order);
            return derivative.CalculateDerivative;
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on forward finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function MakeDerivative(Function function, double step)
        {
            return MakeDerivative(function, step, 1);
        }

        /// <summary>
        /// <para>Generates the numerical derivative of the given order of the function based on forward finite differences of the default step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static Function MakeDerivative(Function function, int order)
        {
            return MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order);
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on forward finite differences of the default step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static Function MakeDerivative(Function function)
        {
            return MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1);
        }

        /// <summary>
        /// <para>Provides a generator for numerical derivatives based on forward finite differences of given order and step.</para> 
        /// </summary>
        /// <param name="step">The step of the finite differences</param>
        /// <param name="order">The order of the generated derivatives</param>
        /// <returns>The generator of numerical derivatives of the given step and order</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        public static DerivativeGenerator MakeGenerator(double step, int order)
        {
            return (Function function) => { return MakeDerivative(function, step, order); };
        }

        /// <summary>
        /// <para>Provides a generator for numerical first derivatives based on forward finite differences of the given step.</para> 
        /// </summary>
        /// <param name="step">The step used by the generator</param>
        /// <returns>The generator of numerical derivatives of the given step and order</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static DerivativeGenerator MakeGenerator(double step)
        {
            return MakeGenerator(step, 1);
        }

        /// <summary>
        /// <para>Provides a generator for numerical derivatives based on forward finite differences of the default step.</para> 
        /// </summary>
        /// <param name="step">The step used by the generator</param>
        /// <param name="order">The order of the generated derivatives</param>
        /// <returns>The generator of numerical derivatives of the given step and order</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static DerivativeGenerator MakeGenerator(int order)
        {
            return (Function function) => { return MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order); };
        }

        /// <summary>
        /// <para>Provides a generator for numerical first derivatives based on forward finite differences of the default step.</para> 
        /// </summary>
        /// <param name="step">The step used by the generator</param>
        /// <param name="order">The order of the generated derivatives</param>
        /// <returns>The generator of numerical derivatives of the given step and order</returns>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static DerivativeGenerator MakeGenerator()
        {
            return (Function function) => { return MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1); };
        }

        //precalculated Step^n
        private readonly double nStep;

        private readonly Function function;

        //the terms of the finite difference
        private readonly Term[] terms;

        private ForwardDerivative(Function function, double step, int order)
        {
            if (function == null)
                throw new ArgumentNullException("function");

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

        private double CalculateDerivative(double x)
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

