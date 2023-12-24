using System;
using System.Collections.Generic;

namespace HarryPotterClasses
{
    public class HarryPotterPricing
    {
        private readonly decimal BookPrice = 8.0m;
        private readonly decimal[] Discounts = { 0m, 0.05m, 0.1m, 0.2m, 0.25m };

        public decimal CalculateTotalPrice(List<int> books)
        {
            var bookCounts = new int[5];
            foreach (var book in books)
            {
                bookCounts[book - 1]++;
            }

            Array.Sort(bookCounts);
            Array.Reverse(bookCounts);

            decimal totalPrice = 0;
            while (Array.Exists(bookCounts, count => count > 0))
            {
                var differentBooks = Array.FindAll(bookCounts, count => count > 0).Length;
                var discount = Discounts[differentBooks - 1];

                for (int i = 0; i < differentBooks; i++)
                {
                    if (bookCounts[i] > 0)
                    {
                        totalPrice += BookPrice * (1 - discount);
                        bookCounts[i]--;
                    }
                }
            }

            return Math.Round(totalPrice, 2);
        }
    }
}
