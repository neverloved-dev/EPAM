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
            int[,] grid = {
            {0, 0, 0},
            {0, 1, 0},
            {0, 1, 1}
        };

            int liveNeighbors = GameOfLife.CountLiveNeighbors(grid, 1, 1);

            Assert.Equal(4, liveNeighbors);
        }
    }
}