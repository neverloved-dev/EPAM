using System.Collections.Generic;

namespace SudokuValidator
{


    public class SudokuValidator
    {
        public static bool IsValidSolution(int[,] board)
        {
            const int Size = 9;

            // Check rows and columns
            for (int i = 0; i < Size; i++)
            {
                HashSet<int> rowSet = new HashSet<int>();
                HashSet<int> colSet = new HashSet<int>();

                for (int j = 0; j < Size; j++)
                {
                    if (rowSet.Contains(board[i, j]) || colSet.Contains(board[j, i]) || board[i, j] < 1 ||
                        board[i, j] > 9)
                    {
                        return false;
                    }

                    rowSet.Add(board[i, j]);
                    colSet.Add(board[j, i]);
                }
            }

            // Check subgrids
            for (int startRow = 0; startRow < Size; startRow += 3)
            {
                for (int startCol = 0; startCol < Size; startCol += 3)
                {
                    if (!IsValidSubgrid(board, startRow, startCol))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsValidSubgrid(int[,] board, int startRow, int startCol)
        {
            HashSet<int> subgridSet = new HashSet<int>();
            const int SubgridSize = 3;

            for (int i = startRow; i < startRow + SubgridSize; i++)
            {
                for (int j = startCol; j < startCol + SubgridSize; j++)
                {
                    int currentValue = board[i, j];

                    if (currentValue < 1 || currentValue > 9 || subgridSet.Contains(currentValue))
                    {
                        return false;
                    }

                    subgridSet.Add(currentValue);
                }
            }

            return true; // Return true if all unique numbers from 1 to 9 are present
        }

    }
}