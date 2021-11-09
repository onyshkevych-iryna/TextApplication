using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextApp
{
    class Program
    {
        //C:\Users\iryna.onyshkevych\OneDrive - Valtech\Bureau\programs\TextApp\TextApp\fileToRead.txt
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write the file address");
            string path = Console.ReadLine();
            StreamReader sr = new StreamReader(path);
            string text = File.ReadAllText(path);
            Console.WriteLine("Text from a file:");
            Console.WriteLine(text);
            Dictionary<string, int> collectionOfWords = new Dictionary<string, int>();

            #region FirstTask
            Regex reg_exp = new Regex("[^a-zA-Z0-9']"); 
            text = reg_exp.Replace(text, " ");
            //Console.WriteLine(text);
            string[] words = text.Split(new char[] {
                ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            var distinctWords = words.Select(i => i).OrderByDescending(i=>i).Distinct();
            string[] result = distinctWords.ToArray();
            Console.WriteLine();
            Console.WriteLine("Statistics:");
            foreach (string word in result)
            {
                CountStringOccurrences(text, word, collectionOfWords);
            }

            foreach (KeyValuePair<string, int> keyValue in collectionOfWords)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            #endregion
            #region SecondTask
            string line = null;
            Console.WriteLine("Please, input the word you're looking for");
            string inputWord = Console.ReadLine();
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
            #endregion
        }
        public static void CountStringOccurrences(string text, string word, Dictionary<string,int> dictionary)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(word, i)) != -1)
            {
                i += word.Length;
                count++;
            }

            dictionary.Add(word, count);
            //Console.WriteLine("word \"{1}\" frequency: {0}", count, word);
        }
    }
}
