using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TextApp.Abstractions.Interfaces;

namespace TextApp.Abstractions.Services
{
    public class TextService:ITextService
    {
        public StreamReader sr;

        public void WordsFrequency(string text, ref Dictionary<string, int> collectionOfWords)
        {
            Regex exRegex = new Regex("[^a-zA-Z0-9']");
            text = exRegex.Replace(text, " ");
            string[] words = text.Split(new char[] {
                ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            var distinctWords = words.Select(i => i).OrderByDescending(i => i).Distinct();
            string[] result = distinctWords.ToArray();
            Console.WriteLine();
            Console.WriteLine("Statistics:");
            foreach (string word in result)
            {
                FrequencyOfWord(text, word, collectionOfWords);
            }
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

        public void WordsPosition(string path, string inputWord)
        {
            sr = new StreamReader(path);
            string line = null;
            List<string> listStrLineElements = null;
            int lineNumber = 1;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                listStrLineElements = line.Split(' ').ToList();
                var result1 = Enumerable.Range(0, listStrLineElements.Count)
                    .Where(i => listStrLineElements[i] == inputWord)
                    .ToList();
                foreach (var item in result1)
                    Console.WriteLine(String.Format($"line: {lineNumber} number of a word: {item + 1}"));
                lineNumber++;
            }
        }
    }
}
