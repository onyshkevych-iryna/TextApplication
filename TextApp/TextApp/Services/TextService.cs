﻿using System;
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

        public Dictionary<string, int> WordsFrequency(string text)
        {
            Dictionary<string, int> collectionOfWords = new Dictionary<string, int>();
            try
            {
                Regex exRegex = new Regex("[^a-zA-Z0-9']");
                text = exRegex.Replace(text, " ");
                string[] words = text.Split(new char[]
                {
                    ' '
                }, StringSplitOptions.RemoveEmptyEntries);
                var distinctWords = words.Select(i => i).OrderByDescending(i => i).Distinct();
                string[] result = distinctWords.ToArray();
                foreach (string word in result)
                {
                    FrequencyOfWord(text, word, collectionOfWords);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return collectionOfWords;
        }

        public void FrequencyOfWord(string text, string word, Dictionary<string, int> dictionary)
        {
            try
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void WordsPosition(string inputWord)
        {
            try
            {
                StreamReader sr = new StreamReader(Path);
                string line = null;
                List<string> listStrLineElements = null;
                int lineNumber = 0;
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
