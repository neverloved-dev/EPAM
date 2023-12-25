using System;

namespace MineFieldNamespace
{
    public class MineField
    {
        private readonly int[,] mineField;
        private readonly int rows;
        private readonly int columns;

        public MineField(int[,] field)
        {
            mineField = field;
            rows = field.GetLength(0);
            columns = field.GetLength(1);
        }

        public string GenerateHintField()
        {
            string hintField = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (mineField[i, j] == 1)
                    {
                        hintField += "*";
                    }
                    else
                    {
                        int adjacentMines = CountAdjacentMines(i, j);
                        hintField += adjacentMines.ToString();
                    }
                }
                hintField += "\n";
            }

            return hintField.Trim();
        }

        private int CountAdjacentMines(int x, int y)
        {
            int count = 0;
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (IsValidCoordinate(newX, newY) && mineField[newX, newY] == 1)
                {
                    count++;
                }
            }

            return count;
        }

        private bool IsValidCoordinate(int x, int y)
        {
            return x >= 0 && x < rows && y >= 0 && y < columns;
        }
    }
}
