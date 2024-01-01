using System;
using System.Collections.Generic;
using Xunit;
using PockerHandNamespace;

namespace PockerHandTests
{
    public class PockerHandTests
    {
        [Fact]
        public void CompareHands_BlackWinsWithHighCard_ReturnsBlackWins()
        {
            // Arrange
            var pokerHand = new PockerHand();
            var blackHand = new List<string> { "2H", "4S", "6C", "8D", "QH" };
            var whiteHand = new List<string> { "3D", "5S", "7H", "9C", "KD" };

            // Act
            var result = pokerHand.CompareHands(blackHand, whiteHand);

            // Assert
            Assert.Equal("White wins - High Card high card: K", result);
        }

        [Fact]
        public void CompareHands_WhiteWinsWithFlush_ReturnsWhiteWins()
        {
            // Arrange
            var pokerHand = new PockerHand();
            var blackHand = new List<string> { "2H", "4H", "6H", "8H", "QH" };
            var whiteHand = new List<string> { "3D", "5D", "7D", "9D", "KD" };

            // Act
            var result = pokerHand.CompareHands(blackHand, whiteHand);

            // Assert
            Assert.Equal("White wins - Flush high card: K", result);
        }

        [Fact]
        public void CompareHands_Tie_ReturnsTie()
        {
            // Arrange
            var pokerHand = new PockerHand();
            var blackHand = new List<string> { "2H", "4S", "6C", "8D", "QH" };
            var whiteHand = new List<string> { "2D", "4C", "6H", "8S", "QD" };

            // Act
            var result = pokerHand.CompareHands(blackHand, whiteHand);

            // Assert
            Assert.Equal("Tie", result);
        }

        // Add more tests for different hand combinations as needed...
    }
}