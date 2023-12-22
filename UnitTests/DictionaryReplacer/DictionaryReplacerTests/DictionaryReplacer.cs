using DictionaryReplacerNamespace;
namespace DictionaryReplacerTests
{
    public class DictionaryReplacerTests
    {
        [Theory]
        [InlineData("", new string[0], "")]
        [InlineData("$temp$", new string[] { "temp", "temporary" }, "temporary")]
        [InlineData("$temp$ here comes the name $name$", new string[] { "temp", "temporary", "name", "John Doe" }, "temporary here comes the name John Doe")]
        public void ReplaceVariables_WithDictionary_ReplacesVariablesCorrectly(string input, string[] dictValues, string expectedOutput)
        {
            // Arrange
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < dictValues.Length; i += 2)
            {
                dict[dictValues[i]] = dictValues[i + 1];
            }

            // Act
            var result = DictionaryReplacer.ReplaceVariables(input, dict);

            // Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}