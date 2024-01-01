namespace SudokuTests;
using SudokuValidator;
public class SudokuValidatorTests
{
    [Fact]
    public void IsValidSolution_ValidSolution_ReturnsTrue()
    {
        // Arrange
        int[,] validBoard = {
            {5, 3, 4, 6, 7, 8, 9, 1, 2},
            {6, 7, 2, 1, 9, 5, 3, 4, 8},
            {1, 9, 8, 3, 4, 2, 5, 6, 7},
            {8, 5, 9, 7, 6, 1, 4, 2, 3},
            {4, 2, 6, 8, 5, 3, 7, 9, 1},
            {7, 1, 3, 9, 2, 4, 8, 5, 6},
            {9, 6, 1, 5, 3, 7, 2, 8, 4},
            {2, 8, 7, 4, 1, 9, 6, 3, 5},
            {3, 4, 5, 2, 8, 6, 1, 7, 9}
        };

        // Act
        bool isValid = SudokuValidator.IsValidSolution(validBoard);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void IsValidSolution_InvalidSolution_ReturnsFalse()
    {
        // Arrange
        int[,] invalidBoard = {
            {5, 3, 4, 6, 7, 8, 9, 1, 2},
            {6, 7, 2, 1, 9, 0, 3, 4, 8},
            {1, 0, 0, 3, 4, 2, 5, 6, 0},
            {8, 5, 9, 7, 6, 1, 0, 2, 0},
            {4, 2, 6, 8, 5, 3, 7, 9, 1},
            {7, 1, 3, 9, 2, 4, 8, 5, 6},
            {9, 0, 1, 5, 3, 7, 2, 1, 4},
            {2, 8, 7, 4, 1, 9, 6, 3, 5},
            {3, 0, 0, 4, 8, 1, 1, 7, 9}
        };

        // Act
        bool isValid = SudokuValidator.IsValidSolution(invalidBoard);

        // Assert
        Assert.False(isValid);
    }

    [Theory]
    [InlineData(0, 0, true)] 
    [InlineData(3, 3, true)] 
    [InlineData(6, 6, true)] 
    [InlineData(6, 3, true)] 
    public void IsValidSubgrid_ValidateSubgrid_ReturnsExpectedResult(int startRow, int startCol, bool expectedResult)
    {
        // Arrange
        int[,] board = {
            {5, 3, 4, 6, 7, 8, 9, 1, 2},
            {6, 7, 2, 1, 9, 5, 3, 4, 8},
            {1, 9, 8, 3, 4, 2, 5, 6, 7},
            {8, 5, 9, 7, 6, 1, 4, 2, 3},
            {4, 2, 6, 8, 5, 3, 7, 9, 1},
            {7, 1, 3, 9, 2, 4, 8, 5, 6},
            {9, 6, 1, 5, 3, 7, 2, 8, 4},
            {2, 8, 7, 4, 1, 9, 6, 3, 5},
            {3, 4, 5, 2, 8, 6, 1, 7, 9}
        };

        // Act
        bool isValidSubgrid = SudokuValidator.IsValidSubgrid(board, startRow, startCol);

        // Assert
        Assert.Equal(expectedResult, isValidSubgrid);
    }
}