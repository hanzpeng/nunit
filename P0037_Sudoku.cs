using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;

namespace NUnitTestProject1
{
    public class P0037_Sudoku
    {
        public void SolveSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        var res = Solve(board, i, j);
                        return;
                    }
                }
            }
        }

        public bool Solve(char[][] board, int r, int c)
        {
            for (char x = '1'; x <= '9'; x++)
            {
                if (ShouldTry(board, r, c, x))
                {
                    board[r][c] = x;

                    var next = getNextPoint(board, r, c);
                    if (next.Item1 == -1)
                    {
                        return true;
                    }
                    else
                    {
                        var res = Solve(board, next.Item1, next.Item2);
                        if (res == true) return true;
                        board[r][c] = '.';
                    }
                }

            }
            return false;
        }

        bool ShouldTry(char[][] board, int r, int c, char x)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i][c] == x)
                {
                    return false;
                }
                if (board[r][i] == x)
                {
                    return false;
                }
            }

            int rStart = r - r % 3;
            int cStart = c - c % 3;
            for (int i = rStart; i < rStart + 3; i++)
            {
                for (int j = cStart; j < cStart + 3; j++)
                {
                    if (board[i][j] == x)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        (int, int) getNextPoint(char[][] board, int r, int c)
        {
            int cNext = ++c;
            int rNext = r;
            if (cNext == 9)
            {
                rNext++;
                cNext = 0;
            }
            if (rNext == 9) return (-1, -1);
            if (board[rNext][cNext] == '.')
            {
                return (rNext, cNext);
            }
            return getNextPoint(board, rNext, cNext);
        }
    }
}
