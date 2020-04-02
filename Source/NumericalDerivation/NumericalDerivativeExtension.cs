namespace Beryl.NumericalDerivation
{
    /// <summary>
    /// Extension methods of Function delegate for calculating numerical derivatives
    /// </summary>
    public static class DerivativeExtension
    {
        #region CentralDerivative direct derivative

        /// <summary>
        /// Estimates the derivative of the given order of the function in x using a central finite difference with the given step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static double CentralDerivative(this Function function,double x,double step,int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order)(x);
        }

        /// <summary>
        /// Estimates the first derivative of the function in x using a central finite difference of the given step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static double CentralDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step)(x);
        }

        /// <summary>
        /// Estimates the derivative of the given order of the function in x using a central finite difference with the default step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static double CentralDerivative(this Function function, double x, int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order)(x);
        }

        /// <summary>
        /// Estimates the first derivative of the function in x using a central finite difference with the default step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static double CentralDerivative(this Function function, double x)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1)(x);
        }

        #endregion

        #region CentralDerivative function derivative

        /// <summary>
        /// <para>Generates the numerical derivative of the given order of the function based on central finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function CentralDerive(this Function function,double step,int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order);
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on central finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function CentralDerive(this Function function, double step)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, 1);
        }

        /// <summary>
        /// <para>Generates the numerical derivative of the given order of the function based on central finite differences of the default step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static Function CentralDerive(this Function function, int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order);
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on central finite differences of the default step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static Function CentralDerive(this Function function)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1);
        }

        #endregion

        #region BackwardDerivative direct derivative

        /// <summary>
        /// Estimates the derivative of the given order of the function in x using a backward finite difference with the given step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static double BackwardDerivative(this Function function, double x, double step, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, order)(x);
        }

        /// <summary>
        /// Estimates the first derivative of the function in x using a backward finite difference of the given step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static double BackwardDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step)(x);
        }

        /// <summary>
        /// Estimates the derivative of the given order of the function in x using a backward finite difference with the default step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static double BackwardDerivative(this Function function, double x, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order)(x);
        }

        /// <summary>
        /// Estimates the first derivative of the function in x using a backward finite difference with the default step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static double BackwardDerivative(this Function function, double x)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1)(x);
        }

        #endregion

        #region BackwardDerivative function derivative

        /// <summary>
        /// <para>Generates the numerical derivative of the given order of the function based on backward finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function BackwardDerive(this Function function, double step, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, order);
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on backward finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function BackwardDerive(this Function function, double step)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, 1);
        }

        /// <summary>
        /// <para>Generates the numerical derivative of the given order of the function based on backward finite differences of the default step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static Function BackwardDerive(this Function function, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order);
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on backward finite differences of the default step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static Function BackwardDerive(this Function function)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1);
        }

        #endregion

        #region ForwardDerivative direct derivative

        /// <summary>
        /// Estimates the derivative of the given order of the function in x using a forward finite difference with the given step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static double ForwardDerivative(this Function function, double x, double step, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, order)(x);
        }

        /// <summary>
        /// Estimates the first derivative of the function in x using a forward finite difference of the given step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="step">The step of the finite difference</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static double ForwardDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step)(x);
        }

        /// <summary>
        /// Estimates the derivative of the given order of the function in x using a forward finite difference with the default step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <param name="order">The order of the derivative</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static double ForwardDerivative(this Function function, double x, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order)(x);
        }

        /// <summary>
        /// Estimates the first derivative of the function in x using a forward finite difference with the default step
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="x">The point in which the derivative is estimated</param>
        /// <returns>The estimated derivative</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static double ForwardDerivative(this Function function, double x)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1)(x);
        }

        #endregion

        #region ForwardDerivative function derivative

        /// <summary>
        /// <para>Generates the numerical derivative of the given order of the function based on forward finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <param name="order">The order of the finite difference</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function ForwardDerive(this Function function, double step, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, order);
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on forward finite differences of the given step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <param name="step">The step of the finite differences</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is negative or zero</exception>
        public static Function ForwardDerive(this Function function, double step)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, 1);
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
        public static Function ForwardDerive(this Function function, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, order);
        }

        /// <summary>
        /// <para>Generates the numerical first derivative of the function based on forward finite differences of the default step.</para> 
        /// </summary>
        /// <param name="function">The function to derive</param>
        /// <returns>The function that estimates the derivative of the input function</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed function is null</exception>
        /// <remarks><para>For default parameters check <see cref="DefaultNumericalDerivationParameters"/></para></remarks>
        public static Function ForwardDerive(this Function function)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, DefaultNumericalDerivationParameters.DefaultStep, 1);
        }

        #endregion
    }
}
