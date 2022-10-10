using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P0051_NQueens
{
    internal class P0051_NQueens
    {
        List<IList<string>> res = new List<IList<string>>();
        public IList<IList<string>> SolveNQueens(int n)
        {
            int[,] board = new int[n, n];
            PlaceRow(0, board, n);
            return (IList<IList<string>>)res;
        }
        public void PlaceRow(int r, int[,] board, int n)
        {
            for(int c=0; c< n; c++)
            {
                board[r, c] = 1;
                if(IsValid(r, c, board, n))
                {
                    if (r == n-1)
                    {
                        CopyResult(board, n);
                    }
                    else
                    {
                        PlaceRow(r + 1, board, n);
                    }
                }
                board[r, c] = 0;
            }
        }
        public Boolean IsValid(int r, int c, int[,]board, int n)
        {
            for(int i=0; i<n; i++)
            {
                if (board[i, c] == 1 && i != r) return false;
                if (board[r, i] == 1 && i != c) return false;
                if (r + c - i >= 0 && r + c - i < n && board[i, r+c-i] == 1 && i != r) return false;
                if (i + c - r >=0 && i + c - r < n && board[i, i+c-r] == 1 && i != r) return false;
            }
            return true;
        }

        public void CopyResult(int[,] board, int n)
        {
            List<string> temp = new List<string>();
            for(int r=0; r<n; r++)
            {
                string str = "";
                for(int c=0; c<n; c++)
                {
                    str += board[r, c] == 0 ? '.' : 'Q';
                }
                temp.Add(str);
            }
            IList<string> temp1 = (IList<string>) temp;
            res.Add(temp1);
        }
    }

}
