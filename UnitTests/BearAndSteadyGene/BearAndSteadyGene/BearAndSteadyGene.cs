using System;
using System.Collections.Generic;

namespace BearAndSteadyGeneNamespace
{
    public class BearAndSteadyGene
    {
        public static int SteadyGeneSubstring(string s)
        {
            // Store the count of each character in the string
            Dictionary<char, int> charCount = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'T', 0 },
            { 'G', 0 }
        };

            foreach (char c in s)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
            }

            // Calculate the required count for each character to be steady
            int steadyCount = s.Length / 4;
            foreach (char c in charCount.Keys)
            {
                charCount[c] = Math.Max(0, charCount[c] - steadyCount);
            }

            foreach (char c in s)
            {
                if (!charCount.ContainsKey(c))
                    charCount[c] = 0;
                charCount[c]++;
            }


            foreach (char c in charCount.Keys)
            {
                charCount[c] = Math.Max(0, charCount[c] - steadyCount);
            }

            // Check if the current substring is valid
            Func<bool> isValid = () => charCount['A'] == 0 && charCount['C'] == 0 && charCount['T'] == 0 && charCount['G'] == 0;

            int minSubStringLength = int.MaxValue;
            int left = 0, right = 0;

            while (right < s.Length)
            {
                // Reduce the count of the character in the sliding window
                char rightChar = s[right];
                if (charCount.ContainsKey(rightChar))
                    charCount[rightChar]--;

                // Move the right pointer until the current substring is valid
                while (isValid() && left <= right)
                {
                    minSubStringLength = Math.Min(minSubStringLength, right - left + 1);

                    char leftChar = s[left];
                    if (charCount.ContainsKey(leftChar))
                        charCount[leftChar]++;

                    left++;
                }

                right++;
            }

            return minSubStringLength == int.MaxValue ? 0 : minSubStringLength;
        }
    }
}
