# Beryl
A simple C# library for numerical computation. The library is currently on working, however the following modules are already usable:
* Numerical differentiation module
* Numerical integration module
* Root-finding methods module

Unfortunately there is currently no documentation, it will be provided as soon as possible.

Currently working on:
* ODE solvers (Euler method, Runge-kutta methods, Adams–Bashforth methods)
* Optimizating the functions returned as ODE solution using precalculated points 

## Requirements
* .NET Framework minimum version: 3.5 (C# 3.0)
* .NET Core every version

## Quick Example
This is how to calculate the zero between 1 and 2 of the derivative of sine (approximated with a central finite difference with step 10-4) using the bisection method
```cs
//using the .net standard sine function
Function sine = Math.Sin; 
//result: (x=zero,y=error), stopping criteria: absolute with h=10-6
Vector2D zero=sine.CentralDerivative(0.0001).BisectionSolve(2,1);
```
