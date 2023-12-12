using System;

namespace BinaryNumbers
{
    public class BinaryNumber
    {
        public static int CountBinaryWithoutAdjacentOnes(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException("n must be a positive integer.");
            }

            int endingWithZero = 1;
            int endingWithOne = 1;

            for (int i = 2; i <= n; i++)
            {
                int temp = endingWithOne;
                endingWithOne = endingWithZero;
                endingWithZero += temp;
            }

            return endingWithZero + endingWithOne;
        }
    }
}
