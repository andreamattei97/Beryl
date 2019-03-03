using System;
using Beryl.Structures;
using Beryl.Utilities;

namespace Beryl.RootFinding
{
    class SecantSolver
    {
        private int _maxIterations = 50;
        public int MaxIterations
        {
            get { return _maxIterations; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("MaxIterations", "The number of iteractions must be non-negative");
                _maxIterations = value;
            }
        }

        //the stopping criteria
        public IStoppingCriteria StoppingCriteria
        {
            get;
        }

        public Func<double, double> Function { get; }
        //the function wrapped for detecting non-finite returned values
        private readonly Func<double, double> _wrappedFunction;

        public SecantSolver(Func<double, double> function, IStoppingCriteria stoppingCriteria)
        {
            Function = function;
            _wrappedFunction = FunctionWrapper.MakeWrapper(function);

            StoppingCriteria = stoppingCriteria;
        }

        //set an absolute tollerance of 10^-6 as stopping criteria
        public SecantSolver(Func<double, double> function) : this(function, new AbsoluteCriteria(0.000001))
        { }

        public Result Solve(double x0, double x1)
        {

            double xn1 = x1,xn0=x0,x=0;
            double fn1 = _wrappedFunction(xn1),fn0=_wrappedFunction(xn0);
            bool success = false;

            StoppingCriteria.SetCriteria(new Vector2D(xn1, _wrappedFunction(fn1)));

            for (int k = 0; k < MaxIterations; k++)
            {
                double d = (fn1 - fn0)/ (xn1 - xn0);
                x = xn1 - fn1/ d ;
                if (!x.IsFinite())
                    throw new CalculationException("Found a non finite point in the succession to the root", Function);

                fn0 = fn1;
                xn0 = xn1;
                fn1 = _wrappedFunction(x);
                xn1 = x;

                if (StoppingCriteria.FullfilCriteria(new Vector2D(xn1, fn1)))
                {
                    success = true;
                    break;
                }
            }

            return new Result(new Vector2D(xn1, fn1), success);
        }
    }
}
