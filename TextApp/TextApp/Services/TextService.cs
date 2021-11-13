using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TextApp.Abstractions.Interfaces;

namespace TextApp.Services
{
    public class TextService:ITextService
    {
        public StreamReader sr;
        private string Path { get; set; }
        public TextService(string path)
        {
            Path = path;
        }

        public Dictionary<string, int> WordsFrequency(string text)
        {
            Dictionary<string, int> collectionOfWords = new Dictionary<string, int>();
            Regex exRegex = new Regex("[^a-zA-Z0-9']");
            text = exRegex.Replace(text, " ");
            string[] words = text.Split(new char[] {
                ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            var distinctWords = words.Select(i => i).OrderByDescending(i => i).Distinct();
            string[] result = distinctWords.ToArray();
            foreach (string word in result)
            {
                FrequencyOfWord(text, word, collectionOfWords);
            }
            return collectionOfWords;
        }

        public void FrequencyOfWord(string text, string word, Dictionary<string, int> dictionary)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(word, i)) != -1)
            {
                i += word.Length;
                count++;
            }
            dictionary.Add(word, count);
        }

        public void WordsPosition(string inputWord)
        {
            sr = new StreamReader(Path);
            string line = null;
            List<string> listStrLineElements = null;
            int lineNumber = 0;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                listStrLineElements = line.Split(' ').ToList();
                var result1 = Enumerable.Range(0, listStrLineElements.Count)
                    .Where(i => listStrLineElements[i] == inputWord)
                    .ToList();
                foreach (var item in result1)
                    Console.WriteLine(String.Format($"line: {lineNumber+1} number of a word: {item + 1}"));
                lineNumber++;
            }
        }
    }
}
