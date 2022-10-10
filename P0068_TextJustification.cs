using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NUnitTests
{
    internal class P0068_TextJustification
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            IList<string> result = new List<string>();
            int start = 0;
            while (start < words.Length)
            {
                int i = start;
                int width = words[i].Length;
                while (i + 1 < words.Length && width + 1 + words[i + 1].Length <= maxWidth)
                {
                    i++;
                    width += words[i].Length + 1;
                }

                if (i + 1 < words.Length)
                {
                    result.Add(GetLine(words, maxWidth - width, start, i, false));
                }
                else
                {
                    result.Add(GetLine(words, maxWidth - width, start, i, true));
                    break;
                }
                start = i + 1;
            }
            return result;
        }

        public string GetLine(string[] words, int totalExtraSpace, int start, int i, bool isLastLIne)
        {
            StringBuilder sb = new(words[start]);
            int gaps = i - start;
            if (gaps > 0)
            {
                int averageSpace = totalExtraSpace / gaps;
                int remainSpace = totalExtraSpace % gaps;
                for (int j = start + 1; j <= i; j++)
                {
                    sb.Append(' ');
                    if (!isLastLIne)
                    {
                        for (int k = 0; k < averageSpace; k++)
                        {
                            sb.Append(' ');
                        }
                        if (remainSpace > 0)
                        {
                            sb.Append(' ');
                            remainSpace--;
                        }
                    }
                    sb.Append(words[j]);
                }
            }
            if (isLastLIne || gaps == 0)
            {
                for (int k = 0; k < totalExtraSpace; k++)
                {
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }
    }
}
