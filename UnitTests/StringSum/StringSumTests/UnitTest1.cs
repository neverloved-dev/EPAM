using StringSumUtility;
namespace StringSumTests
{
    public class UnitTest1
    {
        [Fact]
        public void Sum_WhenBothInputsAreEmpty_ReturnsZero()
        {
            // Arrange
            string num1 = "";
            string num2 = "";

            // Act
            string result = StringSumUtility.StringSumUtility.Sum(num1, num2);

            // Assert
            Assert.Equal("0", result);
        }

        [Theory]
        [InlineData("123", "456", "579")] // Regular case
        [InlineData("999", "1", "1000")] // Addition leading to a carry-over
        [InlineData("0", "0", "0")] // Both inputs are zero
        public void Sum_AddsTwoNaturalNumbers(string num1, string num2, string expected)
        {
            // Act
            string result = StringSumUtility.StringSumUtility.Sum(num1, num2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", "123", "123")] // Invalid first number
        [InlineData("123", "def", "123")] // Invalid second number
        [InlineData("", "123", "123")] // Empty first number
        [InlineData("123", "", "123")] // Empty second number
        [InlineData("-123", "456", "456")] // Negative first number
        [InlineData("123", "-456", "123")] // Negative second number
        public void Sum_InvalidInputs_ReturnsZero(string num1, string num2, string expected)
        {
            // Act
            string result = StringSumUtility.StringSumUtility.Sum(num1, num2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Sum_LargeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            string num1 = "12345678901234567890";
            string num2 = "98765432109876543210";
            string expected = "111111111011111111100";

            // Act
            string result = StringSumUtility.StringSumUtility.Sum(num1, num2);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}