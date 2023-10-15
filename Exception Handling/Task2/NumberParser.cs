using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int num = 0;
            int iterationLen = stringValue.Length;
            try
            {
                for (int i = 0; i < iterationLen; i++)
                {
                    num = num * 10 + (stringValue[i] - 48);
                }

            }
            catch(ArgumentNullException exception)
            {
                Console.WriteLine(exception.Message);
                num = 0;
            }
            catch(OverflowException exception)
            {
                Console.WriteLine($"The {exception.Data} is too big to handle");
                num = 0;
            }
            catch(FormatException exception)
            {
                Console.WriteLine($"{exception.Message} for {exception.Data}");
                num = 0;
            }
            return num;
        }
    }
}