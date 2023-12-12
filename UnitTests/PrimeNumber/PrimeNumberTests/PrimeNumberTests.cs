namespace PrimeNumberTests;
using PrimeNumber;
public class PrimeNumberTests
{
    [Theory]
    [InlineData(2, true)]  // Prime number
    [InlineData(4, false)] // Composite number
    [InlineData(6, false)] // Composite number
    [InlineData(7, true)]  // Prime number
    [InlineData(10, false)] // Composite number
    [InlineData(13, true)] // Prime number
    public void IsPrime_ShouldReturnCorrectly(int number, bool expectedResult)
    {
        // Arrange
        var kata = new PrimeNumber();

        // Act
        var result = kata.IsPrime(number);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(2, false)]  // Prime number
    [InlineData(4, true)] // Composite number
    [InlineData(6, true)] // Composite number
    [InlineData(7, false)]  // Prime number
    [InlineData(10, true)] // Composite number
    [InlineData(13, false)] // Prime number
    public void IsComposite_ShouldReturnCorrectly(int number, bool expectedResult)
    {
        // Arrange
        var kata = new PrimeNumber();

        // Act
        var result = kata.IsComposite(number);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(2, true)]  // Prime number
    [InlineData(4, true)] // Even number
    [InlineData(6, true)] // Even number
    [InlineData(7, false)]  // Prime number
    [InlineData(10, true)] // Even number
    [InlineData(13, false)] // Prime number
    public void IsEven_ShouldReturnCorrectly(int number, bool expectedResult)
    {
        // Arrange
        var kata = new PrimeNumber();

        // Act
        var result = kata.IsEven(number);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}