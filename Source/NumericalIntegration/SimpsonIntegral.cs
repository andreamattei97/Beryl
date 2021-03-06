﻿using System;

namespace Beryl.NumericalIntegration
{
    class SimpsonIntegral
    {

        public static IntegratalFunction MakeIntegral(Function function, double maxStep)
        {
            return (new SimpsonIntegral(function, maxStep)).Integrate;
        }

        private readonly double maxStep;

        private readonly Function function;

        private SimpsonIntegral(Function function, double maxStep)
        {

            if (maxStep <= 0)
                throw new ArgumentOutOfRangeException("maxStep", "the maximum step of integration must be positive");

            this.maxStep = maxStep;
            this.function = function;

        }

        //approximates the integral between a and b divided the interval in n sub-intervals (with n defined by the parameter intervals) 
        //each integrated with a trapezoid formula
        public double Integrate(double a, double b)
        {

            int intervals = (int)Math.Ceiling((b - a) / maxStep);
            double correctedStep = (b - a) / intervals;

            double result = correctedStep / 6 * (function(a) + function(b));

            for (int i = 1; i < intervals; i++)
            {
                double x = a + correctedStep * i;
                result += function(x) * correctedStep/3;
            }

            for (int i = 0; i < intervals; i++)
            {
                double x = a + correctedStep * (i + 0.5);
                result += function(x) * correctedStep * 2 / 3;
            }

            return result;
        }
    }
}
