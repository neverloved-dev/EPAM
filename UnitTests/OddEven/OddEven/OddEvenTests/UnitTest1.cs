namespace OddEvenTests;
using OddEvenClasses;
public class UnitTest1
{
    [Theory]
    [InlineData(2, true)]  // Even number
    [InlineData(4, true)]  // Even number
    [InlineData(6, true)]  // Even number
    [InlineData(7, false)] // Odd number
    [InlineData(9, false)] // Odd number
    [InlineData(11, false)]// Prime number (odd)
    public void IsEven_ShouldReturnCorrectly(int number, bool expectedResult)
    {
        // Arrange
        var kata = new Class1();

        // Act
        var result = kata.IsEven(number);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(2, false)]  // Even number
    [InlineData(4, false)]  // Even number
    [InlineData(6, false)]  // Even number
    [InlineData(7, true)]   // Odd number
    [InlineData(9, true)]   // Odd number
    [InlineData(11, true)]  // Prime number (odd)
    public void IsOdd_ShouldReturnCorrectly(int number, bool expectedResult)
    {
        // Arrange
        var kata = new Class1();

        // Act
        var result = kata.IsOdd(number);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(2, true)]   // Prime number
    [InlineData(4, false)]  // Even number
    [InlineData(6, false)]  // Even number
    [InlineData(7, true)]   // Prime number (odd)
    [InlineData(9, false)]  // Odd number
    [InlineData(11, true)]  // Prime number (odd)
    public void IsPrime_ShouldReturnCorrectly(int number, bool expectedResult)
    {
        // Arrange
        var kata = new Class1();

        // Act
        var result = kata.IsPrime(number);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
