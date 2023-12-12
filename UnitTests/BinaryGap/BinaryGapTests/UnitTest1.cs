using BinaryGapClass;
namespace BinaryGapTests
{
    public class BinaryGapTests
    {
        [Theory]
        [InlineData(9,2)]
        [InlineData(1041,5)]
        [InlineData(529,4)]
        [InlineData(20,1)]
        [InlineData (15,0)]
        public void ShouldReturnCorrectLongestGap(int N, int result)
        {
            BinaryGap binaryGap = new BinaryGap();

            int longestGap = binaryGap.GetLongestGap(N);

            Assert.Equal(result, longestGap);
        }
    }
}