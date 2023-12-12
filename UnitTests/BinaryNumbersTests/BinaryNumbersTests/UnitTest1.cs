using System;
using Xunit;
using BinaryNumbers;

namespace BinaryNumbersTests;
public class BinaryNumbersTests
{
   
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 5)]
    [InlineData(4, 8)]
    [InlineData(5, 13)]
    [InlineData(10, 144)]
    // Add more test cases as needed
    public void Test_CountBinaryWithoutAdjacentOnes(int n, int expectedCount)
    {
        int result = BinaryNumber.CountBinaryWithoutAdjacentOnes(n);
        Assert.Equal(expectedCount, result);
    }

    [Fact]
    public void Test_CountBinaryWithoutAdjacentOnes_InvalidInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => BinaryNumber.CountBinaryWithoutAdjacentOnes(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => BinaryNumber.CountBinaryWithoutAdjacentOnes(-1));
    }
}
