using System;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{

    public class BisectionSolver
    {

        public static BisectionSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new BisectionSolver(function, stoppingCriteria, maxIterations).Solve;
        }

        public static BisectionSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria)
        {
            return new BisectionSolver(function, stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        public static BisectionSolverFunction MakeSolver(Function function,int maxIterations)
        {
            return new BisectionSolver(function, DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        public static BisectionSolverFunction MakeSolver(Function function)
        {
            return new BisectionSolver(function, DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;

        private BisectionSolver(Function function, IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            if (maxIterations < 0)
                throw new ArgumentOutOfRangeException("MaxIterations", "The number of iteractions must be non-negative");
            if (stoppingCriteria == null)
                throw new ArgumentNullException("stoppingCriteria");

            this.maxIterations = maxIterations;
            this.stoppingCriteria = stoppingCriteria;
            this.function = function;

        }

        //returns the point which axproximates the zero inside the interval
        public Vector2D Solve(double inf,double sup)
        {

            double a=inf, b=sup, x=0;
            double fa=function(a), fb=function(b),fx=0;
            
            bool success = false;

            //check if the interval is valid
            if(fa*fb>0)
            {
                throw new CalculationException("Not valid interval",function);
            }

            //first iteration is used for providing a reference estimation
            x = (a + b) / 2;
            fx = function(x);
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
                fx = function(x);

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
