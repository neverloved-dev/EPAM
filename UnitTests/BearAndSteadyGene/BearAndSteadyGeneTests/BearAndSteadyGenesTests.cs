using BearAndSteadyGeneNamespace;
namespace BearAndSteadyGeneTests
{
    public class BearAndSteadyGenesTests
    {
        [Fact]
        public void SteadyGeneSubstring_ValidInput_ReturnsMinimumLength()
        {
            // Arrange
            string gene3 = "TTTTCCGG";

            // Act
            int result3 = BearAndSteadyGene.SteadyGeneSubstring(gene3);

            // Assert
            Assert.Equal(4, result3); // Expected minimum length: 4
        }

        [Fact]
        public void SteadyGeneSubstring_EmptyInput_ReturnsZero()
        {
            // Arrange
            string gene = "";

            // Act
            int result = BearAndSteadyGene.SteadyGeneSubstring(gene);

            // Assert
            Assert.Equal(0, result); // Expected minimum length: 0 for an empty string
        }

        [Fact]
        public void SteadyGeneSubstring_AllCharactersEqual_ReturnsZero()
        {
            // Arrange
            string gene = "AAAA";

            // Act
            int result = BearAndSteadyGene.SteadyGeneSubstring(gene);

            // Assert
            Assert.Equal(0, result); // Expected minimum length: 0 for a gene already steady
        }

        [Fact]
        public void SteadyGeneSubstring_LargeInput_ReturnsMinimumLength()
        {
            // Arrange
            string gene = "AGTCCGATCGGAGTCCGATCGGAGTCCGATCGGAGTCCGATCGGAGTCCGATCGGAGTCCGATCGGAGTCCGATCGGAGTCCGATCGGAGTCCGATCGGAGTCCGATCGG";

            // Act
            int result = BearAndSteadyGene.SteadyGeneSubstring(gene);

            // Assert
            Assert.Equal(64, result); // Expected minimum length for large input
        }
    }
}