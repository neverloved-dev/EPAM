using System;

namespace GameOfLifeNamespace
{
    public class GameOfLife
    {
        static int[,] NextGeneration(int[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int[,] newGrid = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int liveNeighbors = CountLiveNeighbors(grid, i, j);

                    if (grid[i, j] == 1)
                    {
                        if (liveNeighbors < 2 || liveNeighbors > 3)
                        {
                            newGrid[i, j] = 0;
                        }
                        else
                        {
                            newGrid[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (liveNeighbors == 3)
                        {
                            newGrid[i, j] = 1;
                        }
                    }
                }
            }

            return newGrid;
        }

        static int CountLiveNeighbors(int[,] grid, int row, int col)
        {
            int count = 0;
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if ((i != row || j != col) && i >= 0 && i < rows && j >= 0 && j < cols)
                    {
                        count += grid[i, j];
                    }
                }
            }

            return count;
        }

        static void PrintGrid(int[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(grid[i, j] == 1 ? '*' : '.');
                }
                Console.WriteLine();
            }
        }
    }
}
