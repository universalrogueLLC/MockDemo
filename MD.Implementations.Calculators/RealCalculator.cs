using MD.Interfaces;
using System;

namespace MD.Implementations.Calculators
{
    public class RealCalculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0.0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }
    }
}
