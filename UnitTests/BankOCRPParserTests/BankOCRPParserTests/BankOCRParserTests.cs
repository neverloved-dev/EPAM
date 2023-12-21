using System.Collections.Generic;
using Xunit;

public class BankOCRParserTests
{
    [Fact]
    public void ParseAccountNumbers_ValidInput_ReturnsParsedNumbers()
    {
        // Arrange
        string input = " ... (sample input data) ... ";
        BankOCRParser parser = new BankOCRParser();

        // Act
        var accountNumbers = parser.ParseAccountNumbers(input);

        // Assert
        Assert.Equal(12, accountNumbers.Count); // Assuming 12 entries in the input
        Assert.Equal("000000000", accountNumbers[0]); // Test the first parsed account number
        // Add more assertions for other parsed account numbers
    }

    [Fact]
    public void ValidateChecksum_ValidAccountNumber_ReturnsTrue()
    {
        // Arrange
        string validAccountNumber = "123456789";
        BankOCRParser parser = new BankOCRParser();

        // Act
        bool isValid = parser.ValidateChecksum(validAccountNumber);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void GetStatus_ValidAccountNumber_ReturnsEmptyString()
    {
        // Arrange
        string validAccountNumber = "123456789";
        BankOCRParser parser = new BankOCRParser();

        // Act
        string status = parser.GetStatus(validAccountNumber);

        // Assert
        Assert.Equal("", status);
    }

    // Add more test methods to cover other scenarios as per user stories

    [Fact]
    public void GenerateOutputFile_CorrectedNumbers_OutputFileCreated()
    {
        // Arrange
        List<string> parsedNumbers = new List<string> { "000000051", "49006771?", "1234?678?" }; // Sample parsed numbers
        string outputPath = "output.txt";
        BankOCRParser parser = new BankOCRParser();

        // Act
        parser.GenerateOutputFile(parsedNumbers, outputPath);

        // Assert
        Assert.True(File.Exists(outputPath));
        // Additional assertions to verify the content of the output file can be added
    }
}
