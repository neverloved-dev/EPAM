using LabyrinthNamespace;

namespace LabyrinthTests
{
    public class LabyrinthTests
    {
        [Fact]
        public void TestFindExit_PathFound()
        {
            char[,] labyrinth = {
            {'*', '*', '*', '*', '*', '*'},
            {'_', '*', '_', '_', '_', '*'},
            {'*', 's', '_', '*', '_', '*'},
            {'*', '*', '*', '*', '_', '*'},
            {'_', '_', 'e', '_', '_', '*'},
            {'_', '*', '*', '*', '_', '*'}
        };

            Labyrinth solver = new Labyrinth(labyrinth);
            bool pathFound = solver.FindExit();

            Assert.True(pathFound);
        }

        [Fact]
        public void TestFindExit_NoPathFound()
        {
            char[,] labyrinth = {
            {'*', '*', '*', '*', '*', '*'},
            {'_', '*', '_', '_', '_', '*'},
            {'*', 's', '*', '*', '*', '*'},
            {'*', '*', '*', '*', '_', '*'},
            {'_', '_', 'e', '_', '_', '*'},
            {'_', '*', '*', '*', '_', '*'}
        };

            Labyrinth solver = new Labyrinth(labyrinth);
            bool pathFound = solver.FindExit();

            Assert.False(pathFound);
        }

        [Fact]
        public void TestFindExit_StartPointNotFound()
        {
            char[,] labyrinth = {
            {'*', '*', '*', '*', '*', '*'},
            {'_', '*', '_', '_', '_', '*'},
            {'*', '*', '*', '*', '*', '*'},
            {'*', '*', '*', '*', '_', '*'},
            {'_', '_', 'e', '_', '_', '*'},
            {'_', '*', '*', '*', '_', '*'}
        };

            Labyrinth solver = new Labyrinth(labyrinth);
            bool pathFound = solver.FindExit();

            Assert.False(pathFound);
        }

        [Fact]
        public void TestFindExit_EmptyLabyrinth()
        {
            char[,] labyrinth = {
            {'*', '*', '*', '*', '*', '*'},
            {'*', '*', '*', '*', '*', '*'},
            {'*', '*', '*', '*', '*', '*'},
            {'*', '*', '*', '*', '*', '*'},
            {'*', '*', '*', '*', '*', '*'},
            {'*', '*', '*', '*', '*', '*'}
        };

            Labyrinth solver = new Labyrinth(labyrinth);
            bool pathFound = solver.FindExit();

            Assert.False(pathFound);
        }
    }
}