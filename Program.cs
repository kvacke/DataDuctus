using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace DataDuctusChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> scrabbleDictionary = new Dictionary<string, string>();
            
            var scrabbleWords = new List<string>(Regex.Split(File.ReadAllText(@"TextFiles/ospd.txt"), @"[\s,;:.!?-]+"));
            var shakespeareWords = new List<string>(Regex.Split(File.ReadAllText(@"TextFiles/words.shakespeare.txt"), @"[\s,;:.!?-]+"));

            foreach (var word in scrabbleWords)
            {
                if (!scrabbleDictionary.ContainsKey(word))
                    scrabbleDictionary.Add(word.ToLower(), "");
            }



            ScrabbleScorer ss = new ScrabbleScorer(scrabbleDictionary, shakespeareWords);

            ss.FindLegalWordsAndCalculateScores();
            ss.PrintScoredList();

          
        }

        
    }
}
