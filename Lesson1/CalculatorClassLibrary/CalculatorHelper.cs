using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorClassLibrary
{
    public static class CalculatorHelper
    {


        public static double Add(double a, double b) => a + b;


        public static double Subtract(double a, double b) => a - b;


        public static double Multiply(double a, double b) => a * b;


        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero is not possible!");

            return a / b;
        }


        public static double Power(double number, double exponent) => Math.Pow(number, exponent);


        public static double SquareRoot(double number)
        {
            if (number < 0)
                throw new ArgumentException("Division by zero is not possible!");

            return Math.Sqrt(number);
        }

        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("The factorial of a negative number is not calculated!");

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static int Mod(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("The second number in the mod operation cannot be 0!");

            return a % b;
        }
    }
}
