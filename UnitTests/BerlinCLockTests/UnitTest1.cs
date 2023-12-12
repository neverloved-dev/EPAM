using System.Text.RegularExpressions;
using System;
using Xunit;
using BerlinClockClass;
namespace BerlinCLockTests
{
  
public class BerlinClockTests
    {
        [Theory]
        [InlineData(0, 0, 0, "Y\nOOOO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [InlineData(13, 37, 5, "O\nRROO\nRRRO\nYYRYYRYOOOO\nYYOO")]
        [InlineData(23, 59, 59, "O\nRROO\nRRRO\nYYRYYRYYRYY\nYYYY")]
        [InlineData(24, 0, 0, "Y\nRROO\nRRRR\nOOOOOOOOOOO\nOOOO")]
        [InlineData(12, 0, 0, "Y\nRROO\nRROO\nOOOOOOOOOOO\nOOOO")]
        [InlineData(6, 30, 0, "Y\nRROO\nROOO\nYYRYYROOOOO\nOOOO")]
        [InlineData(7, 15, 30, "Y\nRROO\nRROO\nYYROOOOOOOO\nOOOO")]
        public void BerlinClock_ShouldReturnExpectedString(int hour, int minute, int second, string expected)
        {
            // Arrange
            var berlinClock = new BerlinClock(); 

            // Act
            string result = berlinClock.GetBerlinClock(hour, minute, second);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
          [InlineData(25, 0, 0)]
          [InlineData(-1, 0, 0)]
          [InlineData(0, 60, 0)]
          [InlineData(0, -1, 0)]
          [InlineData(0, 0, 60)]
          [InlineData(0, 0, -1)]
          public void BerlinClock_InvalidInput_ShouldThrowException(int hour, int minute, int second)
          {
              // Arrange
              var berlinClock = new BerlinClock(); 

              // Act & Assert
              Assert.Throws<ArgumentException>(() => berlinClock.GetBerlinClock(hour, minute, second));
          }

        [Fact]
        public void BerlinClock_InvalidInput_ShouldThrowException_ForNegativeSecond()
        {
            // Arrange
            var berlinClock = new BerlinClock(); 

            // Act & Assert
            Assert.Throws<ArgumentException>(() => berlinClock.GetBerlinClock(0, 0, -1));
        }
    }
}