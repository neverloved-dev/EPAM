using System;
using System.Collections.Generic;
using System.IO;

namespace BankOCRParser
{
    public class BankOCRPParser
    {
        public List<string> ParseAccountNumbers(string input)
        {
            List<string> accountNumbers = new List<string>();
            string[] lines = input.Split("\n");

            for (int i = 0; i < lines.Length; i += 4)
            {
                if (i + 3 >= lines.Length)
                    break;

                string[] digits = new string[9];

                for (int j = 0; j < 3; j++)
                {
                    string line = lines[i + j];
                    for (int k = 0; k < 9; k++)
                    {
                        int startIndex = k * 3;
                        digits[k] += line.Substring(startIndex, 3);
                    }
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
