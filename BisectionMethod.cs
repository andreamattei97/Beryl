using System;
using Beryl.Structures;
using Beryl.Utilities;

namespace Beryl.RootFinding
{
    class BisectionMethod
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
        
        public ITollerance Tollerance
        {
            get;
            private set;
        }

        public BisectionMethod(ITollerance tollerance)
        {
            Tollerance = tollerance;
        }

        public BisectionMethod()
        {
            Tollerance = new AbsoluteTollerance(0.000001);
        }

        //returns the point which axproximates the zero
        public Result FindZero(Func<double,double> function, double inf,double sup)
        {
            double a=inf, b=sup, x=0;
            double fa=function(a), fb=function(b),fx=0;
            //reference value for tollerance
            double f0 = function((a + b) / 2);
            bool success = false;

            //check if the interval is valid
            if(fa*fb>0)
            {
                throw new CalculationException("Not valid interval");
            }

            for(int k=0; k<MaxIterations;k++)
            {
                x = (a + b) / 2;
                fx = function(x);

                if(Math.Abs(fx)<=Math.Abs(Tollerance.GetTollerance(f0)))
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
                else
                {
                    throw new CalculationException("Not valid function (the function must be continuos)");
                }
            }

            return new Result(new Vector2D(x, fx), success);
        }
    }
}
