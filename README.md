# Beryl
A simple C# library for numerical computation. The library is currently on working, however the following modules are already usable:
* Numerical differentiation module
* Numerical integration module
* ODE solvers method (only single-step methods) + precalculated nodes optimization
* Root-finding methods module

Unfortunately there is currently no documentation, it will be provided as soon as possible.

Currently working on:
* ODE multistep solvers (Adams–Bashforth methods)
* Applying precalculated nodes optimization to the numerical integration module

Future modules:
* Interpolation module
* Generic matrices and vectors implementation
* Linear system solver module

## Notice
The library is currently on alpha therefore, even though the published code is fully working, refactoring and reworking of the already done modules may happen in future.

## Requirements
* .NET Framework minimum version: 3.5 (C# 3.0)
* .NET Core every version

## Quick Example 1
This is how to calculate the zero between 1 and 2 of the derivative of sine (approximated with a central finite difference with step 10-4) using the bisection method
```cs
//using the .net standard sine function
Function sine = Math.Sin; 
//result: (x=zero,y=error), stopping criteria: absolute with h=10-6
Vector2D zero=sine.CentralDerivative(0.0001).BisectionSolve(2,1);
```

## Quick Example 2
This example shows how to get the numerical approximated function of the solution of the Cauchy problem y'=y with y(0)=1 (y=e^x). 
The solver used is the Euler one while the discretizer used for calculating the steps of iteration is the default one (uniform steps of 0.001).
Since evaluating the solution function may be expensive since the Euler method is an iterative one, therefore in order to speed-up solution evaluation is possible to use precalculated points (nodes) of it. In the example, there are used 20 nodes right and 20 nodes left the initial condition spanning 500 iterations (covered interval [-10,10]) selected through a binary search.
```cs
//the ODE argument function
ODEFunction ODEArgument = (x, y) => y;
//sets optimization options (node selector type, number of nodes, and node spanning)
OptimizationOptions optimizationOptions = new OptimizationOptions(BinarySelector.BinarySelectorGenerator, 20, 20, 500);
//the initial condition of the problem
Vector2D initialCondition = new Vector2D(0, 1);
//gets the solution function
Function ODESolution = ODEArgument.EulerSolve(initialCondition, optimizationOptions);
```
