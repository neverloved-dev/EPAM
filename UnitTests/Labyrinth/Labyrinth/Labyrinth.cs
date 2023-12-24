using System;
using System.Collections.Generic;

namespace LabyrinthNamespace
{
    public class Labyrinth
    {
        private readonly char[,] labyrinth;
        private readonly int rows;
        private readonly int cols;
        private readonly HashSet<string> visited;

        public Labyrinth(char[,] labyrinth)
        {
            this.labyrinth = labyrinth;
            this.rows = labyrinth.GetLength(0);
            this.cols = labyrinth.GetLength(1);
            this.visited = new HashSet<string>();
        }

        public bool FindExit()
        {
            int startRow = -1, startCol = -1;

            // Find the start point 's'
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (labyrinth[i, j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                        break;
                    }
                }
            }

            if (startRow == -1 || startCol == -1)
            {
                Console.WriteLine("Start point 's' not found!");
                return false;
            }

            return DFS(startRow, startCol, "");
        }

        private bool IsValid(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols && labyrinth[row, col] != '*' && !visited.Contains($"{row}-{col}");
        }

        private bool DFS(int row, int col, string path)
        {
            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine("Path found: " + path);
                return true;
            }

            visited.Add($"{row}-{col}");

            int[] dRow = { -1, 0, 1, 0 };
            int[] dCol = { 0, 1, 0, -1 };
            char[] directions = { 'U', 'R', 'D', 'L' };

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dRow[i];
                int newCol = col + dCol[i];

                if (IsValid(newRow, newCol))
                {
                    if (DFS(newRow, newCol, path + " " + directions[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
