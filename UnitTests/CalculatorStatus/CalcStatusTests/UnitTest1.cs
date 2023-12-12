using CalculatorStatus;
namespace CalcStatusTests
{
    public class CalculatorStatsTests
    {
        [Fact]
        public void CalculateStats_ValidSequence_ReturnsCorrectStats()
        {
            // Arrange
            List<int> sequence = new List<int> { 6, 9, 15, -2, 92, 11 };
            StatsCalculator calculator = new StatsCalculator();

            // Act
            var result = calculator.CalculateStats(sequence);

            // Assert
            Assert.Equal(-2, result["minimum"]);
            Assert.Equal(92, result["maximum"]);
            Assert.Equal(6, result["count"]);

            double expectedAverage = 21.833333;
            double actualAverage = (double)result["average"];

            int decimalPlaces = 6; // Define the number of decimal places for comparison

            double roundedExpected = Math.Round(expectedAverage, decimalPlaces);
            double roundedActual = Math.Round(actualAverage, decimalPlaces);

            Assert.Equal(roundedExpected, roundedActual);
        }


        [Fact]
        public void CalculateStats_EmptySequence_ReturnsDefaultValues()
        {
            // Arrange
            List<int> emptySequence = new List<int>();
            StatsCalculator calculator = new StatsCalculator();

            // Act
            var result = calculator.CalculateStats(emptySequence);

            // Assert
            Assert.Null(result["minimum"]);
            Assert.Null(result["maximum"]);
            Assert.Equal(0, result["count"]);
            Assert.Null(result["average"]);
        }
    }
}