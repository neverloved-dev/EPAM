using System;
using System.Collections.Generic;
using System.IO;

namespace BankOCRParserNamespace
{
    public class BankOCRParser
    {
        public List<string> ParseAccountNumbers(string input)
        {
            List<string> accountNumbers = new List<string>();
            string[] lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            const int digitsPerSet = 4; // Number of lines per digit set
            const int charsPerLine = 27; // Assuming 27 characters per line

            for (int i = 0; i < lines.Length; i += digitsPerSet)
            {
                if (i + digitsPerSet > lines.Length)
                {
                    // Incomplete data for a digit set
                    throw new FormatException("Incomplete data for a digit set.");
                }

                string[] digits = new string[9];

                for (int j = 0; j < charsPerLine; j += 3)
                {
                    string digit = $"{lines[i].Substring(j, 3)}{lines[i + 1].Substring(j, 3)}{lines[i + 2].Substring(j, 3)}";

                    if (digit.Length != 9)
                    {
                        // Invalid length for extracted digit
                        throw new FormatException("Invalid length for extracted digit.");
                    }

                    digits[j / 3] += digit;
                }

                accountNumbers.Add(string.Join("", digits));
            }

            return accountNumbers;
        }




        public bool ValidateChecksum(string accountNumber)
        {
            int[] multipliers = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int sum = 0;

            for (int i = 0; i < accountNumber.Length; i++)
            {
                if (!int.TryParse(accountNumber[i].ToString(), out int digit))
                {
                    return false; // Invalid character
                }

                sum += digit * multipliers[i];
            }

            return sum % 11 == 0;
        }

        public string GetStatus(string accountNumber)
        {
            if (accountNumber.Contains("?"))
            {
                return "ILL";
            }
            else if (!ValidateChecksum(accountNumber))
            {
                return "ERR";
            }
            else
            {
                return "";
            }
        }

        public string CorrectNumber(string accountNumber)
        {
            // Logic to correct illegible or erroneous numbers
            // For simplicity, this example provides limited correction logic

            if (accountNumber.Contains("?"))
            {
                // Replace '?' with '0'
                return accountNumber.Replace('?', '0');
            }

            return accountNumber;
        }

        public void GenerateOutputFile(List<string> parsedNumbers, string outputPath)
        {
            using StreamWriter writer = new StreamWriter(outputPath);

            foreach (var number in parsedNumbers)
            {
                string status = GetStatus(number);
                if (status == "")
                {
                    writer.WriteLine(number);
                }
                else if (status == "ERR")
                {
                    writer.WriteLine($"{number} {status}");
                }
                else if (status == "ILL")
                {
                    // Attempt correction
                    string correctedNumber = CorrectNumber(number);
                    string newStatus = GetStatus(correctedNumber);

                    if (newStatus == "ILL")
                    {
                        writer.WriteLine($"{number} {status}");
                    }
                    else if (newStatus == "")
                    {
                        writer.WriteLine($"{correctedNumber} AMB [{number}, {correctedNumber}]");
                    }
                }
            }
        }
    }
}
