using System;

namespace Beryl.Utilities
{
    class FunctionWrapper
    {
        //make a wrapper to function that detects non-finite results (and then throw an exception)
        public static Func<double,double> MakeWrapper(Func<double,double> function)
        {
            Func<double, double> wrappedFunction = (double input) =>
              {
                  double result = function(input);
                  if(!result.IsFinite())
                  {
                      throw new FunctionEvaluationException(function, input);
                  }
                  return result;
              };
            return wrappedFunction;
        }
    }
}
