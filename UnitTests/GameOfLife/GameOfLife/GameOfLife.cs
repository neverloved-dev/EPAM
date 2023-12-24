using System;

namespace GameOfLifeNamespace
{
    public class GameOfLife
    {
       public static int[,] NextGeneration(int[,] grid)
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

        public static int CountLiveNeighbors(int[,] grid, int row, int col)
        {
            int count = 0;
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            // Define the neighbor positions relative to the current cell
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + dx[i];
                int newCol = col + dy[i];

                // Check if the neighbor is within the grid boundaries
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    count += grid[newRow, newCol];
                }
            }

            return count;
        }

        public static void PrintGrid(int[,] grid)
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
