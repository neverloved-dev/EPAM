using System;
using System.Collections.Generic;
using System.Linq;

namespace PockerHandNamespace
{
    public class PockerHand
    {
        private readonly string valuesOrder = "23456789TJQKA";

        public string CompareHands(List<string> blackHand, List<string> whiteHand)
        {
            var (blackRank, blackHighCard) = GetHandRank(blackHand);
            var (whiteRank, whiteHighCard) = GetHandRank(whiteHand);

            if (valuesOrder.IndexOf(blackHighCard) > valuesOrder.IndexOf(whiteHighCard))
                return $"Black wins - {blackRank} high card: {blackHighCard}";
            else if (valuesOrder.IndexOf(blackHighCard) < valuesOrder.IndexOf(whiteHighCard))
                return $"White wins - {whiteRank} high card: {whiteHighCard}";
            else
                return "Tie";
        }

        public (string, char) GetHandRank(List<string> hand)
        {
            var values = hand.Select(card => card.Substring(0, card.Length - 1)).ToList();
            var suits = hand.Select(card => card.Last()).ToList();

            // Check for flush
            var isFlush = suits.Distinct().Count() == 1;

            // Check for straight
            var sortedValues = values.OrderBy(value => valuesOrder.IndexOf(value)).ToList();
            var isStraight = IsSequential(sortedValues.Select(value => valuesOrder.IndexOf(value)));
            
            // Count occurrences of each value
            var valueCounts = values.Distinct().ToDictionary(value => value, value => values.Count(v => v == value));

            if (isStraight && isFlush)
                return ("Straight Flush", sortedValues.Last().Last());
            else if (valueCounts.ContainsValue(4))
                return ("Four of a Kind", valueCounts.FirstOrDefault(pair => pair.Value == 4).Key.Last());
            else if (valueCounts.ContainsValue(3) && valueCounts.ContainsValue(2))
                return ("Full House", valueCounts.FirstOrDefault(pair => pair.Value == 3).Key.Last());
            else if (isFlush)
                return ("Flush", sortedValues.Last().Last());
            else if (isStraight)
                return ("Straight", sortedValues.Last().Last());
            else if (valueCounts.ContainsValue(3))
                return ("Three of a Kind", valueCounts.FirstOrDefault(pair => pair.Value == 3).Key.Last());
            else if (valueCounts.Count(pair => pair.Value == 2) == 2)
                return ("Two Pairs", valueCounts.Where(pair => pair.Value == 2).OrderByDescending(pair => pair.Key.Last()).Select(pair => pair.Key.Last()).First());
            else if (valueCounts.ContainsValue(2))
                return ("Pair", valueCounts.FirstOrDefault(pair => pair.Value == 2).Key.Last());
            else
                return ("High Card", sortedValues.Last().Last());
        }

        private bool IsSequential(IEnumerable<int> values)
        {
            var sortedValues = values.OrderBy(v => v).ToList();
            var min = sortedValues.Min();
            var max = sortedValues.Max();
            var expectedSum = (max - min + 1) * (min + max) / 2;
            var actualSum = sortedValues.Sum();
            return expectedSum == actualSum;
        }
    }
}
