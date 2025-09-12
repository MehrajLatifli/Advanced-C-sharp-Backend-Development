using CalculatorClassLibrary;

namespace CalculatorNet8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Add: {CalculatorHelper.Add(10, 5)}");
            Console.WriteLine($"Subtract: {CalculatorHelper.Subtract(10, 5)}");
            Console.WriteLine($"Multiply: {CalculatorHelper.Multiply(10, 5)}");
            Console.WriteLine($"Divide: {CalculatorHelper.Divide(10, 5)}");
            Console.WriteLine($"Power: {CalculatorHelper.Power(2, 3)}");
            Console.WriteLine($"SquareRoot: {CalculatorHelper.SquareRoot(16)}");
            Console.WriteLine($"Factorial: {CalculatorHelper.Factorial(5)}");
            Console.WriteLine($"Mod: {CalculatorHelper.Mod(10, 3)}");
        }
    }
}
