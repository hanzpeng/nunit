using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class P0030
    {
        public class Solution1 {
            private Dictionary<string, int> wordCount = new Dictionary<string, int>();
            private int wordLength;
            private int substringSize;
            private int k;

            private bool Check(int i, string s) {
                // Copy the original dictionary to use for this index
                var remaining = new Dictionary<string, int>(wordCount);
                int wordsUsed = 0;
                // Each iteration will check for a match in words
                for (int j = i; j < i + substringSize; j += wordLength) {
                    string sub = s.Substring(j, wordLength);
                    if (remaining.ContainsKey(sub) && remaining[sub] != 0) {
                        remaining[sub] = remaining[sub] - 1;
                        wordsUsed++;
                    } else {
                        break;
                    }
                }

                return wordsUsed == k;
            }

            public IList<int> FindSubstring(string s, string[] words) {
                int n = s.Length;
                k = words.Length;
                wordLength = words[0].Length;
                substringSize = wordLength * k;
                foreach (var word in words)
                    wordCount[word] =
                        wordCount.ContainsKey(word) ? wordCount[word] + 1 : 1;
                IList<int> answer = new List<int>();
                for (int i = 0; i < n - substringSize + 1; i++) {
                    if (Check(i, s)) {
                        answer.Add(i);
                    }
                }

                return answer;
            }
        }
        public class Solution2_SlidingWindow {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            int n;
            int wordLength;
            int substringSize;
            int k;

            void slidingWindow(int left, string s, List<int> answer) {
                Dictionary<string, int> wordsFound = new Dictionary<string, int>();
                int wordsUsed = 0;
                bool excessWord = false;
                for (int right = left; right <= n - wordLength; right += wordLength) {
                    string sub = s.Substring(right, wordLength);
                    if (!wordCount.ContainsKey(sub)) {
                        // Mismatched word - reset the window
                        wordsFound.Clear();
                        wordsUsed = 0;
                        excessWord = false;
                        left = right + wordLength;
                    } else {
                        // If we reached max window size or have an excess word
                        while (right - left == substringSize || excessWord) {
                            string leftmostWord = s.Substring(left, wordLength);
                            left += wordLength;
                            wordsFound[leftmostWord]--;
                            if (wordsFound[leftmostWord] >= wordCount[leftmostWord]) {
                                // This word was an excess word
                                excessWord = false;
                            } else {
                                // Otherwise we actually needed it
                                wordsUsed--;
                            }
                        }

                        // Keep track of how many times this word occurs in the window
                        if (!wordsFound.ContainsKey(sub)) {
                            wordsFound[sub] = 0;
                        }

                        wordsFound[sub]++;
                        if (wordsFound[sub] <= wordCount[sub]) {
                            wordsUsed++;
                        } else {
                            // Found too many instances already
                            excessWord = true;
                        }

                        if (wordsUsed == k && !excessWord) {
                            // Found a valid substring
                            answer.Add(left);
                        }
                    }
                }
            }

            public IList<int> FindSubstring(string s, string[] words) {
                n = s.Length;
                k = words.Length;
                wordLength = words[0].Length;
                substringSize = wordLength * k;
                foreach (string word in words) {
                    if (!wordCount.ContainsKey(word))
                        wordCount[word] = 0;
                    wordCount[word]++;
                }

                List<int> answer = new List<int>();
                for (int i = 0; i < wordLength; i++) {
                    slidingWindow(i, s, answer);
                }

                return answer;
            }
        }


    }
}
