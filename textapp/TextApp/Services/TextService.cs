using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TextApp.Abstractions.Interfaces;

namespace TextApp.Services
{
    public class TextService:ITextService
    {
        private string Path { get; set; }
        public TextService(string path)
        {
            Path = path;
        }

        public string[] AllWords()
        {
            var text = File.ReadAllText(Path);
            var exRegex = new Regex("[^a-zA-Z0-9']");
            text = exRegex.Replace(text, " ");
            string[] words = text.Split(new char[]
            {
                ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> WordsFrequency(string text)
        {
            var collectionOfWords = new Dictionary<string, int>();
            IOrderedEnumerable<KeyValuePair<string, int>> sortedDict = null;
            try
            {
                var result = AllWords().Select(i => i).OrderByDescending(i => i).Distinct().ToArray();
                foreach (var word in result)
                {
                    var wordOccurrence = AllWords().Select(w => w).Where(w => w == word);
                    var wordCount = wordOccurrence.Count();
                    collectionOfWords.Add(word, wordCount);
                }
                sortedDict = collectionOfWords.Select(w=>w).OrderByDescending(e=>e.Value);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return sortedDict;
        }

    public void WordsPosition(string inputWord)
        {
            try
            {
                var sr = new StreamReader(Path);
                string line = null;
                List<string> listStrLineElements = null;
                var lineNumber = 0;
                if (!AllWords().Contains(inputWord))
                    Console.WriteLine("There is no such word! Please, try again");
                else{
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        listStrLineElements = line.Split(' ').ToList();
                        var result = Enumerable.Range(0, listStrLineElements.Count)
                            .Where(i => listStrLineElements[i] == inputWord)
                            .ToList();
                        foreach (var item in result)
                            Console.WriteLine(String.Format($"line: {lineNumber + 1}  word number: {item + 1}"));
                        lineNumber++;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
