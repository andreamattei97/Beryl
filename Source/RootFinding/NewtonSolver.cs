using System;
using Beryl.NumericalDerivation;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{


    public class NewtonSolver
    {

        public static NewtonSolverFunction  MakeSolver(Function function, Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new NewtonSolver(function, derivative, stoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return new NewtonSolver(function, derivative, stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new NewtonSolver(function, derivativeGenerator(function), stoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return new NewtonSolver(function, derivativeGenerator(function), stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), stoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function,Function derivative,int maxIterations)
        {
            return new NewtonSolver(function, derivative, DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function, Function derivative)
        {
            return new NewtonSolver(function, derivative, DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return new NewtonSolver(function, derivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator)
        {
            return new NewtonSolver(function, derivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function,int maxIterations)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        public static NewtonSolverFunction MakeSolver(Function function)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;

        //the function derivative
        private readonly Function derivative;

        private NewtonSolver(Function function,Function derivative,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            this.function = function;

            this.derivative = derivative;

            this.stoppingCriteria = stoppingCriteria;

            this.maxIterations = maxIterations;
        }

        public Vector2D Solve(double initialEstimation,int multiplicity=DefaultRootFindingParameters.DEFAULT_NEWTON_METHOD_MULTIPLICITY)
        {
            if (multiplicity < 1)
                throw new ArgumentOutOfRangeException("multiplicity", "the multiplicity of the root must be equal or greater than 1");

            double xn = initialEstimation;
            double fn = 0;
            double dfn = 0;
            bool success = false;

            stoppingCriteria.SetCriteria(new Vector2D(xn, function(xn)));

            for(int k=0;k<maxIterations;k++)
            {
                fn = function(xn);
                dfn = derivative(xn);

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
