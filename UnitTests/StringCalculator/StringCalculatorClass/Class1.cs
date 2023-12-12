using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace StringCalculatorClass
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            string[] delimiters = GetDelimiters(ref numbers);

            var numberList = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(n => ParseNumber(n))
                                    .Where(n => n <= 1000);

            return numberList.Sum();
        }

        private static string[] GetDelimiters(ref string numbers)
        {
            string[] delimiters = { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                var delimiterMatch = Regex.Match(numbers, @"(?<=//\[?)([^]\n]+)(?=\]\n)");
                var customDelimiter = delimiterMatch.Success ? Regex.Escape(delimiterMatch.Value) : numbers.Substring(2, 1);
                numbers = numbers.Substring(numbers.IndexOf('\n') + 1);
                delimiters = new[] { customDelimiter };
            }

            return delimiters;
        }


        private static int ParseNumber(string numberStr)
        {
            string[] delimiters = { "*", "%", "|||", "???" };
            string[] numberParts = numberStr.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            foreach (var part in numberParts)
            {
                int number;
                if (!int.TryParse(part, out number))
                {
                    throw new FormatException($"The input string '{numberStr}' was not in a correct format.");
                }
                if (number < 0)
                {
                    throw new ArgumentException($"Negatives not allowed: {number}");
                }
                sum += number;
            }

            return sum;
        }



    }
}

