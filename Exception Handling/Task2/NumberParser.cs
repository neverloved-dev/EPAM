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

            int num = 0;
            int startIndex = 0;
            int length = stringValue.Length;
            
            while (startIndex < length && char.IsWhiteSpace(stringValue[startIndex]))
            {
                startIndex++;
            }

            if (startIndex == length)
            {
                throw new FormatException("Input string does not represent a valid integer.");
            }

            char firstChar = stringValue[startIndex];

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
                char c = stringValue[i];
                
                if (c == ' ' &&  i == length - 1)
                {
                    continue;
                }

                if (c >= '0' && c <= '9')
                {
                    int digit = c - '0';
                    try
                    {
                        checked
                        {
                            num = num * 10 + digit;
                        }
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