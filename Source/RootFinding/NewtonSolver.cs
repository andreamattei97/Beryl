using System;
using Beryl.NumericalDerivation;
using Beryl.Structures;
using Beryl.Utilities;

namespace Beryl.RootFinding
{
    class NewtonSolver
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

        //the function derivative
        public Func<double,double> Derivative { get; }
        //the derivative wrapped for detecting non-finite returned values
        private readonly Func<double, double> _wrappedDerivative;

        public NewtonSolver(Func<double,double> function,Func<double,double> derivative,IStoppingCriteria stoppingCriteria)
        {
            Function = function;
            _wrappedFunction = FunctionWrapper.MakeWrapper(function);

            Derivative = derivative;
            _wrappedDerivative = FunctionWrapper.MakeWrapper(derivative);

            StoppingCriteria = stoppingCriteria;
        }
        
        public NewtonSolver(Func<double,double> function,IStoppingCriteria stoppingCriteria):this(function,CentralDerivative.MakeDerivative(function,1,0.0001),stoppingCriteria)
        { }

        public NewtonSolver(Func<double,double> function):this(function,new AbsoluteCriteria(0.000001))
        { }

        public NewtonSolver(Func<double, double> function, Func<double, double> derivative) : this(function, derivative, new AbsoluteCriteria(0.000001))
        { }

        public Result Solve(double initialEstimation,int multiplicity=1)
        {
            if (multiplicity < 1)
                throw new ArgumentOutOfRangeException("multiplicity", "the multiplicity of the root must be equal or greater than 1");

            double xn = initialEstimation;
            double fn = 0;
            double dfn = 0;
            bool success = false;

            StoppingCriteria.SetCriteria(new Vector2D(xn, _wrappedFunction(xn)));

            for(int k=0;k<MaxIterations;k++)
            {
                fn = _wrappedFunction(xn);
                dfn = _wrappedDerivative(xn);

                if (dfn == 0 && fn != 0)
                    throw new CalculationException("Cannot continue calculation, the function derivative is 0 in " + xn, Function);

                if(StoppingCriteria.FullfilCriteria(new Vector2D(xn,fn)))
                {
                    success = true;
                    break;
                }

                xn = xn -multiplicity * fn / dfn;
            }

            return new Result(new Vector2D(xn,fn),success);
        }
        

    }
}
