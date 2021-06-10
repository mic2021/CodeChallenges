using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace ParsedSentence
{
    /// <summary>
    /// Parser Sentence Class
    /// </summary>
    public  static class SentenceParser
    {
        public static string Parsed(string sentence)
        {
            var parse = GetParsedSentence(sentence);
            return parse;
        }
        /// <summary>
        /// Method to parsed a sentence
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private static string GetParsedSentence(string sentence)
        {
            string parsed = string.Empty;

            if (!string.IsNullOrEmpty(sentence))
            {
                var words = sentence.Split(" ");
                foreach (var item in words)
                {
                    if (!string.IsNullOrEmpty(parsed))
                    {
                        parsed = parsed + " " + GetParsedWord(item);
                    }
                    else
                    {
                        parsed = GetParsedWord(item);
                    }
                }
            }
            return parsed;
        }
        /// <summary>
        /// Method to parse a word
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private static string GetParsedWord(string sentence)
        {
            var firstLetter = string.Empty;
            var lastLetter = string.Empty;
            List<string> notrepeat = new List<string>();
            var parsed = string.Empty;

            firstLetter = sentence.Substring(0, 1);
            lastLetter = sentence.Substring(sentence.Length - 1, 1);
            sentence = sentence.Substring(1, sentence.Length - 1);
            for (int index = 1; index < sentence.Length; index++)
            {
                if (index >= 1 && index < sentence.Length - 1)
                {
                    if (Regex.IsMatch(sentence.Substring(index, 1), @"^[a-zA-Z]+$"))
                    {
                        if (!notrepeat.Contains(sentence.Substring(index)))
                        {
                            notrepeat.Add(sentence.Substring(index));
                        }
                    }
                }
            }
            parsed = firstLetter + notrepeat.Count + lastLetter;
            return parsed;
        }
    }
}
