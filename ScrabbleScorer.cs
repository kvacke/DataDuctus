using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDuctusChallenge
{
    class ScrabbleScorer
    {
        private readonly Dictionary<string,string> _legalWords;
        private readonly List<string> _wordsToScore;
        private readonly int[] letterScores = {
            // a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p,  q, r, s, t, u, v, w, x, y,  z?
               1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10
        };
        private readonly int[] scrabbleLetterDistribution = {9, 2, 2, 1, 12, 2, 3, 2, 9, 1, 1, 4, 2, 6, 8, 2, 1, 6, 4, 6, 4, 2, 2, 1, 2, 1};
        List<(string, int)> _scoredWords;


        public ScrabbleScorer(Dictionary<string,string> legalWords, List<string> wordsToScore)
        {
            _legalWords = legalWords;
            _wordsToScore = wordsToScore;
            _scoredWords = new List<(string, int)>();
        }

        public void PrintScoredList()
        {
            var sorted = _scoredWords.Select(value => value).OrderByDescending(value => value.Item2).ToList();
            foreach (var wordAndScorePair in sorted)
            {
                Console.WriteLine(wordAndScorePair.Item1 + " : " + wordAndScorePair.Item2);
            }
        }


        public void FindLegalWordsAndCalculateScores()
        {
            foreach(var word in _wordsToScore)
            {
                if (_legalWords.ContainsKey(word))
                {
                    _scoredWords.Add((word,GetWordScore(word)));
                }
            }
          
        }

        public int GetWordScore(string word)
        {
                                                 // a, b, c, d,  e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
            List<int> bagOfTiles = new List<int>(){ 9, 2, 2, 1, 12, 2, 3, 2, 9, 1, 1, 4, 2, 6, 8, 2, 1, 6, 4, 6, 4, 2, 2, 1, 2, 1 };
            int sum = 0;
            int alphabetIndex; 
            for (int i = 0; i < word.Length; i++)
            {
                alphabetIndex = word[i] - 97;
                if (bagOfTiles[alphabetIndex] > 0)
                {
                    sum += letterScores[alphabetIndex];
                    bagOfTiles[alphabetIndex] = bagOfTiles[alphabetIndex] - 1;
                }
            }
            return sum;
        }

        private List<(string,int)> SortListByScoreAndOrderByDescending(List<(string,int)> ls)
        {
            var sortedAndDescending = ls.Select(value => value).OrderByDescending(value => value.Item2).ToList();
            return sortedAndDescending;
        }

    }
}
