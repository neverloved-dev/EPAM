using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException("Input string is null.");
            }

           string stringValueTrimmed = stringValue.Trim();
            
            int num = 0;
            int startIndex = 0;
            int length = stringValueTrimmed.Length;
            
            while (startIndex < length && char.IsWhiteSpace(stringValueTrimmed[startIndex]))
            {
                startIndex++;
            }

            if (startIndex == length)
            {
                throw new FormatException("Input string does not represent a valid integer.");
            }

            char firstChar = stringValueTrimmed[startIndex];

            if (firstChar == '+' || firstChar == '-')
            {
                startIndex++;
            }

            if (startIndex == length)
            {
                throw new FormatException("Input string does not represent a valid integer.");
            }

            bool isNegative = (firstChar == '-');

            for (int i = startIndex; i < length; i++)
            {
                char c = stringValueTrimmed[i];
                
                if (c == ' ' &&  i == length - 1)
                {
                    continue;
                }

                if (c >= '0' && c <= '9')
                {
                    int digit = c - '0';
                    try
                    {
                        if (isNegative)
                        {
                            if (num < (int.MinValue + digit) / 10)
                            {
                                throw new OverflowException($"Input value {stringValue} is out of Int32 range.");
                            }
                        }
                        else
                        {
                            if (num > (int.MaxValue - digit) / 10)
                            {
                                throw new OverflowException($"Input value {stringValue} is out of Int32 range.");
                            }
                        }
                        // Check for potential overflow before performing the multiplication operation
                        if ((!isNegative && num > (int.MaxValue - digit) / 10) || (isNegative && -num < (int.MinValue + digit) / 10))
                        {
                            throw new OverflowException($"Input value {stringValue} is out of Int32 range.");
                        }

                            num = num * 10 + digit;
                    }
                    catch (OverflowException)
                    {
                        throw new OverflowException($"Input value {stringValue} is out of Int32 range.");
                    }
                }
                else
                {
                    throw new FormatException($"Input string contains non-numeric character '{c}'.");
                }
            }

            if (isNegative)
            {
                num = -num;
            }

            return num;
        }
    }
}