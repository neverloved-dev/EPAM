using System;

namespace BinaryString
{
    public class BinaryStringsWithoutConsecutiveOnes
    {
        public int CountBinaryStrings(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            int a = 1, b = 2; // Fibonacci numbers F(1) and F(2)
            if (n == 1)
            {
                return b;
            }

            for (int i = 3; i <= n + 1; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }

            return b;
        }
    }
}
