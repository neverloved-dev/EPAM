using StringCalculatorClass;
namespace StringCalculator
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            string input = "";

            // Act
            int result = StringCalculatorClass.StringCalculator.Add(input);

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("//;\n1;2;3", 6)]
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//[|||][???]\n1|||2???3", 6)]
        public void Add_SingleOrMultipleNumbers_ReturnsSum(string input, int expectedResult)
        {
            // Act
            int result = StringCalculatorClass.StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_NegativeNumbers_ThrowsException()
        {
            // Arrange
            string input = "-1,2,-3";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => StringCalculatorClass.StringCalculator.Add(input));
        }

        [Fact]
        public void Add_NumbersLargerThan1000_IgnoresNumbers()
        {
            // Arrange
            string input = "2,1001,6";

            // Act
            int result = StringCalculatorClass.StringCalculator.Add(input);

            // Assert
            Assert.Equal(8, result);
        }
    }
}