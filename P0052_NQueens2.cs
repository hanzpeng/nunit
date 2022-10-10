using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P0051_NQueens
{
    internal class P0052_NQueens2
    {
        public int TotalNQueens(int n)
        {
            int count = 0;
            int[,] board = new int[n, n];
            PlaceRow(0, board, n, ref count);
            return count;
        }
        public void PlaceRow(int r, int[,] board, int n, ref int count)
        {
            for (int c = 0; c < n; c++)
            {
                board[r, c] = 1;
                if (IsValid(r, c, board, n))
                {
                    if (r == n - 1)
                    {
                        count++;
                    }
                    else
                    {
                        PlaceRow(r + 1, board, n, ref count);
                    }
                }
                board[r, c] = 0;
            }
        }
        public Boolean IsValid(int r, int c, int[,] board, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (board[i, c] == 1 && i != r) return false;
                if (board[r, i] == 1 && i != c) return false;
                if (r + c - i >= 0 && r + c - i < n && board[i, r + c - i] == 1 && i != r) return false;
                if (i + c - r >= 0 && i + c - r < n && board[i, i + c - r] == 1 && i != r) return false;
            }
            return true;
        }
    }

}
