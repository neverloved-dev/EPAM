using CircularPrimesNamespace;
namespace CircularPrimesTests
{
    public class CircularPrimeTests
    {
        [Theory]
        [InlineData(1, 0)] // There are 0 circular primes below 1
        [InlineData(10, 4)] // There are 4 circular primes below 10
        [InlineData(100, 13)] // There are 13 circular primes below 100
        [InlineData(1000, 25)] // There are 25 circular primes below 1000
        [InlineData(10000, 33)] // There are 33 circular primes below 10000
        [InlineData(100000, 43)] // There are 43 circular primes below 100000
        [InlineData(1000000, 55)] // There are 55 circular primes below 1000000
        public void CountCircularPrimesBelowN_ReturnsCorrectCount(int N, int expectedCount)
        {
            // Act
            int circularPrimesCount = CircularPrimes.CountCircularPrimesBelowN(N);

            // Assert
            Assert.Equal(expectedCount, circularPrimesCount);
        }
    }
}
