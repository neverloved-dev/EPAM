using System;
using System.Collections.Generic;

namespace ReversiLibrary
{
    public class ReversiBoard
    {
        private char[,] board;

        public ReversiBoard(string[] initialState)
        {
            if (initialState.Length != 8 || initialState[0].Length != 8)
            {
                throw new ArgumentException("Invalid board dimensions. Board should be 8x8.");
            }

            board = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = initialState[i][j];
                }
            }
        }

        public List<(int, int)> GetLegalMoves(char player)
        {
            List<(int, int)> legalMoves = new List<(int, int)>();
            char opponent = (player == 'B') ? 'W' : 'B';

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == '.')
                    {
                        if (IsValidMove(i, j, player, opponent))
                        {
                            legalMoves.Add((i, j));
                        }
                    }
                }
            }

            return legalMoves;
        }

        private bool IsValidMove(int row, int col, char player, char opponent)
        {
            int[][] directions = { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 }, new[] { 1, 1 }, new[] { 1, -1 }, new[] { -1, 1 }, new[] { -1, -1 } };

            foreach (var direction in directions)
            {
                int dr = direction[0];
                int dc = direction[1];

                int r = row + dr;
                int c = col + dc;
                int flippedCount = 0;

                while (0 <= r && r < 8 && 0 <= c && c < 8 && board[r, c] == opponent)
                {
                    r += dr;
                    c += dc;
                    flippedCount++;
                }

                if (flippedCount > 0 && 0 <= r && r < 8 && 0 <= c && c < 8 && board[r, c] == player)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
