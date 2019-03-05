using System;
using Beryl.Structures;
using Beryl.Utilities;

namespace Beryl.RootFinding
{

    public delegate Vector2D BisectionSolverFunction(double inf, double sup);

    class BisectionSolver
    {

        public static BisectionSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations = 50)
        {
            return new BisectionSolver(function, stoppingCriteria, maxIterations).Solve;
        }

        public static BisectionSolverFunction MakeSolver(Function function,int maxIterations=50)
        {
            return new BisectionSolver(function, new AbsoluteCriteria(0.000001), maxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;
        //the function wrapped for non-finite return values detection
        private readonly Function wrappedFunction;

        private BisectionSolver(Function function, IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            if (maxIterations < 0)
                throw new ArgumentOutOfRangeException("MaxIterations", "The number of iteractions must be non-negative");

            this.maxIterations = maxIterations;

            this.stoppingCriteria = stoppingCriteria;

            this.function = function;
            wrappedFunction = FunctionWrapper.MakeWrapper(function);

        }

        //returns the point which axproximates the zero inside the interval
        public Vector2D Solve(double inf,double sup)
        {

            double a=inf, b=sup, x=0;
            double fa=wrappedFunction(a), fb=wrappedFunction(b),fx=0;
            
            bool success = false;

            //check if the interval is valid
            if(fa*fb>0)
            {
                throw new CalculationException("Not valid interval",function);
            }

            //first iteration is used for providing a reference estimation
            x = (a + b) / 2;
            fx = wrappedFunction(x);
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
            stoppingCriteria.SetCriteria(new Vector2D(x,fx));

            for(int k=0; k<maxIterations;k++)
            {
                x = (a + b) / 2;
                fx = wrappedFunction(x);

                if(stoppingCriteria.FullfilCriteria(new Vector2D(x,fx)))
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

            if (!success)
                throw new CalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return new Vector2D(x, fx);
        }
    }
}
