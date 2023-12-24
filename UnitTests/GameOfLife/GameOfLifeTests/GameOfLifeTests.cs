using GameOfLifeNamespace;
using GameOfLifeNamespace;
namespace GameOfLifeTests
{
    public class GameOfLifeTests
    {
        [Fact]
        public void TestNextGeneration()
        {
            int[,] inputGrid = {
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 1, 0, 0, 0},
            {0, 0, 0, 1, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0}
        };

            int[,] expectedOutputGrid = {
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 1, 1, 0, 0, 0},
            {0, 0, 0, 1, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0}
        };

            int[,] outputGrid = GameOfLife.NextGeneration(inputGrid);

            Assert.Equal(expectedOutputGrid, outputGrid);
        }

        [Fact]
        public void TestCountLiveNeighbors()
        {
            // Test for CountLiveNeighbors method
            int[,] grid = {
            {0, 0, 0},
            {0, 1, 0},
            {0, 1, 1}
        };

            int liveNeighbors = GameOfLife.CountLiveNeighbors(grid, 1, 1);

            // The correct count of live neighbors for the provided grid should be 2
            Assert.Equal(2, liveNeighbors);
        }
    }
}