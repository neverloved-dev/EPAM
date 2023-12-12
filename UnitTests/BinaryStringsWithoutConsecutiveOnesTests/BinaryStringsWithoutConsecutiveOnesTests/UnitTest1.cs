using BinaryString;
namespace BinaryStringsWithoutConsecutiveOnesTests
{
    public class BinaryStringsWithoutConsecutiveOnesTests
    {
        [Theory]
        [InlineData(1, 2)]  // Test for n = 1
        [InlineData(2, 3)]  // Test for n = 2
        [InlineData(3, 5)]  // Test for n = 3
        [InlineData(4, 8)]  // Test for n = 4
        [InlineData(5, 13)] // Test for n = 5
        [InlineData(10, 144)] // Test for n = 10
        [InlineData(20, 17711)] // Test for n = 20
        public void CountBinaryStrings_ReturnsCorrectCount(int n, int expected)
        {
            // Arrange
            BinaryStringsWithoutConsecutiveOnes binaryStrings = new BinaryStringsWithoutConsecutiveOnes();

            // Act
            int count = binaryStrings.CountBinaryStrings(n);

            // Assert
            Assert.Equal(expected, count);
        }

        [Fact]
        public void CountBinaryStrings_InvalidInput_ReturnsZero()
        {
            // Arrange
            BinaryStringsWithoutConsecutiveOnes binaryStrings = new BinaryStringsWithoutConsecutiveOnes();

            // Act
            int count = binaryStrings.CountBinaryStrings(-5); // Negative input

            // Assert
            Assert.Equal(0, count);
        }
    }
}