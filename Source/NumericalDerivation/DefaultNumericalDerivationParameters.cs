using System;

namespace Beryl.NumericalDerivation
{
    /// <summary>
    /// Manages the default parameters of the Numerical Derivation module
    /// </summary>
    public static class DefaultNumericalDerivationParameters
    {

        /// <summary>
        /// The initial default step
        /// </summary>
        /// <value>0.0001</value>
        public static readonly double INITIAL_DEFAULT_STEP = 0.0001;

        //the property behind DefaultStep
        private static double _defaultStep;
        /// <summary>
        /// <para>The default step of finite differences</para>
        /// <para>Check <see cref="INITIAL_DEFAULT_STEP"/> for the intial default value</para>
        /// </summary>
        /// <value>The default step</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed step is non-positive</exception>
        public static double DefaultStep
        {
            get
            {
                return _defaultStep;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The step must be positive");
                _defaultStep = value;
            }
        }

        static DefaultNumericalDerivationParameters()
        {
            _defaultStep = INITIAL_DEFAULT_STEP;
        }
    }
}
