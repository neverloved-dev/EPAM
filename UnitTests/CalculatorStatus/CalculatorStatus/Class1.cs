using System;
using System.Collections.Generic;

namespace CalculatorStatus
{
    public class StatsCalculator
    {
        public Dictionary<string, object> CalculateStats(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return new Dictionary<string, object>
            {
                { "minimum", null },
                { "maximum", null },
                { "count", 0 },
                { "average", null }
            };
            }

            int minimum = int.MaxValue;
            int maximum = int.MinValue;
            int sum = 0;

            foreach (int num in numbers)
            {
                if (num < minimum)
                    minimum = num;

                if (num > maximum)
                    maximum = num;

                sum += num;
            }

            double average = (double)sum / numbers.Count;

            return new Dictionary<string, object>
        {
            { "minimum", minimum },
            { "maximum", maximum },
            { "count", numbers.Count },
            { "average", average }
        };
        }
    }
}
