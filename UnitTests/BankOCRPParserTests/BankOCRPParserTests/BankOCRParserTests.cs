using System.Collections.Generic;
using Xunit;
using BankOCRParserNamespace;
public class BankOCRParserTests
{
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
