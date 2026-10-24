using System.Globalization;
using System.Net.Security;

namespace lab10;

public class StringCalculator
{
    public string Add(string numbers)
    {
        var result = Execute(numbers, (a, b) => a + b, 0);
        return FormatResult(result);
    }

    public string Multiply(string numbers)
    {
        var result = Execute(numbers, (a, b) => a * b, 1);
        return FormatResult(result);
    }
    
    private string FormatResult((decimal Result, List<string> Errors) result)
        {
            if (result.Errors.Any())
            {
                return string.Join("\n", result.Errors);
            }
        
            return result.Result.ToString(CultureInfo.InvariantCulture);
        }

    private (decimal Result, List<string> Errors) Execute(string numbers, Func<decimal, decimal, decimal> operation,
        decimal indentity)
    {
        var parsedNumbers = ParseAndValidate(numbers);
        if (parsedNumbers.Errors.Any())
            return (0, parsedNumbers.Errors);
        decimal result = parsedNumbers.Numbers.Aggregate(indentity, operation);
        return (result, parsedNumbers.Errors);
    }
    private (List<decimal> Numbers, List<string> Errors) ParseAndValidate(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return (new List<decimal>(), new List<string>());
        var separators = new List<string> { ",", "\n" };
        var errors = new List<string>();
        int offset = 0;


        if (numbers.StartsWith("//"))
        {
            int newlineIdx = numbers.IndexOf('\n');
            if (newlineIdx == -1)
            {
                errors.Add("Invalid delimiter.");
                return (new List<decimal>(), errors);
            }
            separators = new List<string>
            {
                numbers.Substring(2, newlineIdx - 2)
            };
            offset = newlineIdx + 1;
            numbers = numbers.Substring(offset);
        }

        if (separators.Any(s => numbers.EndsWith(s)))
        {
            errors.Add("Number expected but EOF found.");
        }

        if (offset > 0 && (numbers.Contains(",") || numbers.Contains("\n")))
        {
            char wrongChar = numbers.Contains(",") ? ',' : '\n';
            string visibleChar = wrongChar == '\n' ? "\\n" : wrongChar.ToString();
            int wrongIdx = numbers.IndexOf(wrongChar);
            errors.Add($"'{separators[0]}' expected but '{visibleChar}' found at position {wrongIdx}.");
        }

        if (numbers.Contains(",\n"))
        {
            int idx = numbers.IndexOf(",\n") + 1;
            errors.Add($"Number expected but '\\n' found at position {idx}.");
        }
        else if (numbers.Contains(",,"))
        {
            int idx = numbers.IndexOf(",,") + 1;
            errors.Add($"Number expected but ',' found at position {idx}.");
        }

        var parsedNumbers = numbers
            .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(n => decimal.Parse(n, CultureInfo.InvariantCulture))
            .ToList();

        var negatives = parsedNumbers
            .Where(n => n < 0)
            .ToList();

        if (negatives.Any())
        {
            errors.Insert(0, $"Negative not allowed : {string.Join(", ", negatives)}");
        }
        
        return (parsedNumbers, errors);
    }
}