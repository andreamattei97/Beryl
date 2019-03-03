using System;

namespace Beryl
{

    //exception thrown when a function returns (positive/negative) Infinity or NaN for a value
    class FunctionEvaluationException : Exception
    {
        public Func<double,double> EvaluatedFunction { get; }
        public double Input { get; }

        public FunctionEvaluationException(Func<double,double> evaluatedFunction,double input):base("Non-finite value return by the function in "+input)
        {
            EvaluatedFunction = evaluatedFunction;
            Input = input;
        }

    }
}
