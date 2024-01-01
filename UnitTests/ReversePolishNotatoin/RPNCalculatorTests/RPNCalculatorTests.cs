using System;
using Xunit;

public class RPNCalculatorTests
{
    [Theory]
    [InlineData("2 3 +", 5)]
    [InlineData("5 5 *", 25)]
    [InlineData("10 4 -", 6)]
    [InlineData("20 5 /", 4)]
    [InlineData("4 2 / 3 *", 6)]
    [InlineData("3 5 + 7 *", 56)]
    [InlineData("4 2 / 0 *", 0)]
    public void EvaluateRPN_ValidExpressions_ReturnsExpectedResult(string expression, double expectedResult)
    {
        // Arrange & Act
        var result = RPNCalculator.EvaluateRPN(expression);

        // Assert
        Assert.Equal(expectedResult, result);
    }




    [Fact]
    public void EvaluateRPN_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        string expression = "5 0 /";

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => RPNCalculator.EvaluateRPN(expression));
    }
    
    [Fact]
    public void EvaluateRPN_EmptyStack_ThrowsInvalidOperationException()
    {
        // Arrange
        string expression = "5 /";

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => RPNCalculator.EvaluateRPN(expression));
        Assert.Equal("Stack empty.", exception.Message);
    }
   
}