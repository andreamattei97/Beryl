namespace Beryl.NumericalDerivation
{
    /// <summary>
    /// Extension methods of Function delegate for calculating numerical derivatives
    /// </summary>
    public static class DerivativeExtension
    {
        #region CentralDerivative

        /// <summary>
        /// Estimates the derivative of the function in x using a central finite difference
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static double CentralDerivative(this Function function,double x,double step,int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order)(x);
        }

        /// <summary>
        /// <para>Estimates the derivative of the function in x using a central finite difference. The order of the finite difference is the default one.</para>
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static double CentralDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder)(x);
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
        public static Function CentralDerivative(this Function function,double step,int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order);
        }

        /// <summary>
        /// <para>Generates the numerical derivative function based on the central finite difference of the default step and given step.</para> 
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static Function CentralDerivative(this Function function, double step)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        #endregion

        #region BackwardDerivative

        /// <summary>
        /// Estimates the derivative of the function in x using a backward finite difference
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static double BackwardDerivative(this Function function, double x, double step, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, order)(x);
        }

        /// <summary>
        /// <para>Estimates the derivative of the function in x using a backward finite difference. The order of the finite difference is the default one.</para>
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static double BackwardDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder)(x);
        }

        /// <summary>
        /// Generates the numerical derivative function based on the backward finite difference of given order and step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static Function BackwardDerivative(this Function function, double step, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, order);
        }

        /// <summary>
        /// <para>Generates the numerical derivative function based on the backward finite difference of the default step and given step.</para> 
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static Function BackwardDerivative(this Function function, double step)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        #endregion

        #region ForwardDerivative

        /// <summary>
        /// Estimates the derivative of the function in x using a forward finite difference
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static double ForwardDerivative(this Function function, double x, double step, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, order)(x);
        }

        /// <summary>
        /// <para>Estimates the derivative of the function in x using a forward finite difference. The order of the finite difference is the default one.</para>
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static double ForwardDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder)(x);
        }

        /// <summary>
        /// Generates the numerical derivative function based on the forward finite difference of given order and step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static Function ForwardDerivative(this Function function, double step, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, order);
        }

        /// <summary>
        /// <para>Generates the numerical derivative function based on the forward finite difference of the default step and given step.</para> 
        /// <para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para>
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the given step is negative or zero</exception>
        public static Function ForwardDerivative(this Function function, double step)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        #endregion
    }
}
