using FizzBuzzClass;
namespace FizzBuzzTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(7, "7")]
        public void Test_GetFizzBuzz(int number, string expected)
        {
            string result = FizzBuzz.GetFizzBuzz(number);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGetFizzBuzzNumberOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzz.GetFizzBuzz(101));
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(11)]
        [InlineData(14)]
        public void Test_GetFizzBuzz_ReturnsNumber(int number)
        {
            string result = FizzBuzz.GetFizzBuzz(number);
            Assert.Equal(number.ToString(), result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        [InlineData(-5)]
        [InlineData(-15)]
        [InlineData(-25)]
        public void Test_GetFizzBuzz_NumberOutOfRange(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzz.GetFizzBuzz(number));
        }
    }
}