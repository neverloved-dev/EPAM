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

        private Tuple<string, char> GetHandRank(List<string> hand)
        {
            var values = hand.Select(card => card.Substring(0, card.Length - 1)).ToList();
            var suits = hand.Select(card => card.Last()).ToList();

            // Check for flush
            var isFlush = suits.Distinct().Count() == 1;

            // Check for straight
            var sortedValues = values.OrderBy(value => valuesOrder.IndexOf(value));
            var isStraight = sortedValues.SequenceEqual(sortedValues.Select((value, index) => valuesOrder.IndexOf(value) + index));

            // Count occurrences of each value
            var valueCounts = values.Distinct().ToDictionary(value => value, value => values.Count(v => v == value));

            if (isStraight && isFlush)
                return Tuple.Create("Straight Flush", sortedValues.Max());
            else if (valueCounts.ContainsValue(4))
                return Tuple.Create("Four of a Kind", valueCounts.FirstOrDefault(pair => pair.Value == 4).Key);
            else if (valueCounts.ContainsValue(3) && valueCounts.ContainsValue(2))
                return Tuple.Create("Full House", valueCounts.FirstOrDefault(pair => pair.Value == 3).Key);
            else if (isFlush)
                return Tuple.Create("Flush", sortedValues.Max());
            else if (isStraight)
                return Tuple.Create("Straight", sortedValues.Max());
            else if (valueCounts.ContainsValue(3))
                return Tuple.Create("Three of a Kind", valueCounts.FirstOrDefault(pair => pair.Value == 3).Key);
            else if (valueCounts.Count(pair => pair.Value == 2) == 2)
                return Tuple.Create("Two Pairs", valueCounts.Where(pair => pair.Value == 2).OrderByDescending(pair => pair.Key).Select(pair => pair.Key).First());
            else if (valueCounts.ContainsValue(2))
                return Tuple.Create("Pair", valueCounts.FirstOrDefault(pair => pair.Value == 2).Key);
            else
                return Tuple.Create("High Card", sortedValues.Max());
        }
    }
}
}
