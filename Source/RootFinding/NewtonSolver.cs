using System;
using Beryl.NumericalDerivation;
using Beryl.Structures;
using Beryl.Utilities;

namespace Beryl.RootFinding
{

    public delegate Vector2D NewtonSolverFunction (double x0,int multiplicity=1);

    class NewtonSolver
    {

        public static NewtonSolverFunction  MakeSolver(Function function, Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations = 50)
        {
            return new NewtonSolver(function, derivative, stoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function,IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            return new NewtonSolver(function, CentralDerivative.MakeDerivative(function, 0.0001), stoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function,Function derivative,int maxIterations=50)
        {
            return new NewtonSolver(function, derivative, new AbsoluteCriteria(0.000001), maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function,int maxIterations=50)
        {
            return new NewtonSolver(function, CentralDerivative.MakeDerivative(function, 0.0001), new AbsoluteCriteria(0.000001), maxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;
        //the function wrapped for detecting non-finite returned values
        private readonly Function wrappedFunction;

        //the function derivative
        private readonly Function derivative;
        //the derivative wrapped for detecting non-finite returned values
        private readonly Function wrappedDerivative;

        private NewtonSolver(Function function,Function derivative,IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            this.function = function;
            wrappedFunction = FunctionWrapper.MakeWrapper(function);

            this.derivative = derivative;
            wrappedDerivative = FunctionWrapper.MakeWrapper(derivative);

            this.stoppingCriteria = stoppingCriteria;

            this.maxIterations = maxIterations;
        }

        public Vector2D Solve(double initialEstimation,int multiplicity=1)
        {
            if (multiplicity < 1)
                throw new ArgumentOutOfRangeException("multiplicity", "the multiplicity of the root must be equal or greater than 1");

            double xn = initialEstimation;
            double fn = 0;
            double dfn = 0;
            bool success = false;

            stoppingCriteria.SetCriteria(new Vector2D(xn, wrappedFunction(xn)));

            for(int k=0;k<maxIterations;k++)
            {
                fn = wrappedFunction(xn);
                dfn = wrappedDerivative(xn);

                if (dfn == 0 && fn != 0)
                    throw new CalculationException("Cannot continue calculation, the function derivative is 0 in " + xn, function);

                if(stoppingCriteria.FullfilCriteria(new Vector2D(xn,fn)))
                {
                    success = true;
                    break;
                }

                xn = xn -multiplicity * fn / dfn;
            }

            if (!success)
                throw new CalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return new Vector2D(xn,fn);
        }
        

    }
}
