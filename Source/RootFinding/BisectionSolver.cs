using System;

using Beryl.Structures;
using Beryl.Utilities;

namespace Beryl.RootFinding
{
    class BisectionSolver
    {
        private int _maxIterations=50;
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

        public Func<double,double> Function { get; }
        //the function wrapped for detecting non-finite returned values
        private readonly Func<double, double> _wrappedFunction;

        public BisectionSolver(Func<double, double> function, IStoppingCriteria stoppingCriteria)
        {
            StoppingCriteria = stoppingCriteria;
            _wrappedFunction = FunctionWrapper.MakeWrapper(function);
        }

        //set an absolute tollerance of 10^-6 as stopping criteria centered in 0
        public BisectionSolver(Func<double, double> function):this (function, new AbsoluteCriteria(0.000001))
        { }

        //returns the point which axproximates the zero inside the interval
        public Result FindZero(double inf,double sup)
        {

            double a=inf, b=sup, x=0;
            double fa=_wrappedFunction(a), fb=_wrappedFunction(b),fx=0;
            
            bool success = false;

            //check if the interval is valid
            if(fa*fb>0)
            {
                throw new CalculationException("Not valid interval",Function);
            }

            //first iteration is used for providing a reference estimation
            x = (a + b) / 2;
            fx = _wrappedFunction(x);
            if (fx * fa < 0)
            {
                b = x;
                fb = fx;
            }
            else if (fx * fb < 0)
            {
                a = x;
                fa = fx;
            }
            StoppingCriteria.SetCriteria(new Vector2D(x,fx));

            for(int k=0; k<MaxIterations;k++)
            {
                x = (a + b) / 2;
                fx = _wrappedFunction(x);

                if(StoppingCriteria.FullfilCriteria(new Vector2D(x,fx)))
                {
                    success = true;
                    break;
                }

                if(fx*fa<0)
                {
                    b = x;
                    fb = fx;
                }
                else if(fx*fb<0)
                {
                    a = x;
                    fa = fx;
                }
            }

            return new Result(new Vector2D(x, fx), success);
        }
    }
}
