using NaturalOrderStringSortingClass;
namespace NaturalOrderStringSorting
{
    public class NaturalOrderStringSortingTests
    {
        [Fact]
        public void NaturalStringComparer_SortsNumericalStringsCorrectly()
        {
            // Arrange
            List<string> stringList = new List<string>
            {
                "1", "10", "2", "3", "20"
            };
            NaturalStringComparer comparer = new NaturalStringComparer();

            // Act
            stringList.Sort(comparer);

            // Assert
            List<string> expected = new List<string>
            {
                "1", "2", "3", "10", "20"
            };
            Assert.Equal(expected, stringList);
        }

        [Fact]
        public void NaturalStringComparer_SortsMixedStringsCorrectly()
        {
            // Arrange
            List<string> stringList = new List<string>
            {
                "1A", "2S", "10Z", "2B", "20C", "3D"
            };
            NaturalStringComparer comparer = new NaturalStringComparer();

            // Act
            stringList.Sort(comparer);

            // Assert
            List<string> expected = new List<string>
            {
                "1A", "2B", "2S", "3D", "10Z", "20C"
            };
            Assert.Equal(expected, stringList);
        }
    }
}
}