using System;
using System.Numerics;

namespace StringSumUtility
{
    public class StringSumUtility
    {
        public static string Sum(string num1, string num2)
        {
            if (!IsNaturalNumber(num1))
                num1 = "0";

            if (!IsNaturalNumber(num2))
                num2 = "0";

            BigInteger number1 = BigInteger.Parse(num1);
            BigInteger number2 = BigInteger.Parse(num2);

            return (number1 + number2).ToString();
        }

        private static bool IsNaturalNumber(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}