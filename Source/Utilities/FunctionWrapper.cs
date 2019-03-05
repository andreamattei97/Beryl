using System;

namespace Beryl.Utilities
{
    class FunctionWrapper
    {
        //make a wrapper to function that detects non-finite results (and then throw an exception)
        public static Function MakeWrapper(Function function)
        {
            Function wrappedFunction = (double input) =>
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
