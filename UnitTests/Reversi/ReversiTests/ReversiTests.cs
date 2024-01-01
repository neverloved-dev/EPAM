namespace ReversiTests;
using ReversiLibrary;
public class ReversiTests
{
    [Fact]
    public void Constructor_WithValidInitialState_CreatesBoard()
    {
        // Arrange
        string[] initialState = new[]
        {
            "........",
            "........",
            "........",
            "...BW...",
            "...WB...",
            "........",
            "........",
            "........"
        };

        // Act
        var board = new ReversiBoard(initialState);

        // Assert
        Assert.NotNull(board);
    }

    [Fact]
    public void Constructor_WithInvalidInitialState_ThrowsArgumentException()
    {
        // Arrange
        string[] initialState = new[]
        {
            "........",
            "........",
            "........",
            "...BW...",
            "...WB..."
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new ReversiBoard(initialState));
    }

    [Theory]
    [InlineData('B', 4)] // Black player has 4 legal moves in the initial state
    [InlineData('W', 4)] // White player has 4 legal moves in the initial state
    public void GetLegalMoves_ReturnsCorrectNumberOfMoves(char player, int expectedCount)
    {
        // Arrange
        string[] initialState = new[]
        {
            "........",
            "........",
            "........",
            "...BW...",
            "...WB...",
            "........",
            "........",
            "........"
        };

        var board = new ReversiBoard(initialState);

        // Act
        var legalMoves = board.GetLegalMoves(player);

        // Assert
        Assert.Equal(expectedCount, legalMoves.Count);
    }

}