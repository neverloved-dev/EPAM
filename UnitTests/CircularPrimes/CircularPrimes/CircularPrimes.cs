using System;
using System.Collections.Generic;

namespace CircularPrimesNamespace
{
    public class CircularPrimes
    {
        // Function to check if a number is prime
        private static bool IsPrime(int num)
        {
            if (num <= 1)
                return false;

            if (num == 2)
                return true;

            if (num % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(num); i += 2)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }

        // Function to generate all rotations of a number
        private static List<int> GenerateRotations(int num)
        {
            List<int> rotations = new List<int>();
            string numStr = num.ToString();

            for (int i = 0; i < numStr.Length; i++)
            {
                rotations.Add(int.Parse(numStr));
                numStr = numStr[numStr.Length - 1] + numStr.Substring(0, numStr.Length - 1);
            }

            return rotations;
        }

        // Function to count circular primes below N
        public static int CountCircularPrimesBelowN(int N)
        {
            int count = 0;

            for (int i = 2; i < N; i++)
            {
                List<int> rotations = GenerateRotations(i);
                bool isCircularPrime = true;

                foreach (int rotation in rotations)
                {
                    if (!IsPrime(rotation))
                    {
                        isCircularPrime = false;
                        break;
                    }
                }

                if (isCircularPrime)
                    count++;
            }

            return count;
        }
    }
}

