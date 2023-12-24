using AStarNamespace;
namespace AStarTests
{
    public class AStarTests
    {
        [Fact]
        public void FindPath_SimpleGrid_SuccessfulPath()
        {
            int[,] grid = {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },
        };

            AStar aStar = new AStar(grid);

            var path = aStar.FindPath((0, 0), (3, 4));

            Assert.Equal(7, path.Count);
            Assert.Equal((0, 0), path[0]);
            Assert.Equal((0, 1), path[1]);
            Assert.Equal((0, 2), path[2]);
            Assert.Equal((1, 2), path[3]);
            Assert.Equal((2, 2), path[4]);
            Assert.Equal((2, 3), path[5]);
            Assert.Equal((3, 4), path[6]);
        }

        [Fact]
        public void FindPath_NoPathAvailable_ReturnsNull()
        {
            int[,] grid = {
            { 0, 0, 0 },
            { 0, 1, 0 },
            { 0, 1, 0 },
        };

            AStar aStar = new AStar(grid);

            var path = aStar.FindPath((0, 0), (2, 2));

            Assert.Null(path);
        }

        [Fact]
        public void FindPath_StartEqualsEnd_ReturnsSinglePointPath()
        {
            int[,] grid = {
            { 0, 0 },
            { 0, 0 },
        };

            AStar aStar = new AStar(grid);

            var path = aStar.FindPath((0, 0), (0, 0));

            Assert.NotNull(path);
            Assert.Single(path);
            Assert.Equal((0, 0), path[0]);
        }

        [Fact]
        public void FindPath_LargeGrid_SuccessfulPath()
        {
            int[,] grid = new int[100, 100]; // 100x100 grid with all cells as 0 (empty)

            AStar aStar = new AStar(grid);

            var path = aStar.FindPath((0, 0), (99, 99));

            Assert.NotNull(path);
            Assert.True(path.Count > 0);
            Assert.Equal((99, 99), path[path.Count - 1]);
        }
    }
}