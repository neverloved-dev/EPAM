using LeapYearCheckerNamespace;

namespace LeapYear
{
    public class LeapYearCheckerTests
    {
        [Theory]
        [InlineData(1996)]
        [InlineData(2000)]
        [InlineData(2004)]
        public void TestIsLeapYear_True(int year)
        {
            LeapYearChecker checker = new LeapYearChecker();
            bool isLeapYear = checker.IsLeapYear(year);
            Assert.True(isLeapYear);
        }

        [Theory]
        [InlineData(1900)]
        [InlineData(2001)]
        [InlineData(2003)]
        public void TestIsLeapYear_False(int year)
        {
            LeapYearChecker checker = new LeapYearChecker();
            bool isLeapYear = checker.IsLeapYear(year);
            Assert.False(isLeapYear);
        }

        [Theory]
        [InlineData(1600)]
        [InlineData(2008)]
        [InlineData(2400)]
        public void TestIsLeapYear_True_Atypical(int year)
        {
            LeapYearChecker checker = new LeapYearChecker();
            bool isLeapYear = checker.IsLeapYear(year);
            Assert.True(isLeapYear);
        }

        [Theory]
        [InlineData(1700)]
        [InlineData(1800)]
        [InlineData(1900)]
        [InlineData(2100)]
        public void TestIsLeapYear_False_Atypical(int year)
        {
            LeapYearChecker checker = new LeapYearChecker();
            bool isLeapYear = checker.IsLeapYear(year);
            Assert.False(isLeapYear);
        }
    }
}