using System.Numerics;

namespace Lab11;

public class Program
{
    public static void Main()
    {
        Calculator<int> integerCalculator = new();
        Calculator<double> fractionalCalculator = new();

        UseIntegerCalculator(integerCalculator);
        UseFractionalCalculator(fractionalCalculator);
    }

    public static void UseIntegerCalculator<T>(Calculator<T> calculator)
        where T : IBinaryInteger<T>
    {
        Console.WriteLine("Integer calculator:");
        Console.WriteLine($"5 + 3 = {calculator.Add(T.CreateChecked(5), T.CreateChecked(3))}");
        Console.WriteLine($"5 - 3 = {calculator.Subtract(T.CreateChecked(5), T.CreateChecked(3))}");
        Console.WriteLine($"5 * 3 = {calculator.Multiply(T.CreateChecked(5), T.CreateChecked(3))}");
        Console.WriteLine($"6 / 3 = {calculator.Divide(T.CreateChecked(6), T.CreateChecked(3))}");
        Console.WriteLine($"2 ^ 3 = {calculator.Pow(T.CreateChecked(2), 3)}");
    }

    public static void UseFractionalCalculator<T>(Calculator<T> calculator)
        where T : IFloatingPoint<T>
    {
        Console.WriteLine("\nFractional calculator:");
        Console.WriteLine($"5.5 + 2.5 = {calculator.Add(T.CreateChecked(5.5), T.CreateChecked(2.5))}");
        Console.WriteLine($"5.5 - 2.5 = {calculator.Subtract(T.CreateChecked(5.5), T.CreateChecked(2.5))}");
        Console.WriteLine($"5.5 * 2.0 = {calculator.Multiply(T.CreateChecked(5.5), T.CreateChecked(2.0))}");
        Console.WriteLine($"5.0 / 2.0 = {calculator.Divide(T.CreateChecked(5.0), T.CreateChecked(2.0))}");
        Console.WriteLine($"2.0 ^ 3 = {calculator.Pow(T.CreateChecked(2.0), 3)}");
    }
}