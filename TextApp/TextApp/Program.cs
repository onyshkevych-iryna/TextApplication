using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TextApp.Abstractions.Services;

namespace TextApp
{
    class Program
    {
        //C:\Users\iryna.onyshkevych\OneDrive - Valtech\Bureau\programs\TextApp\TextApp\fileToRead.txt
        static void Main(string[] args)
        {
            TextService textService = new TextService();
            Console.WriteLine("Please, write the file address");
            string path = Console.ReadLine();
            string text = File.ReadAllText(path);
            Console.WriteLine("Text from a file:");
            Console.WriteLine(text);
            WordsFrequency(text, textService);
            WordsPosition(path, textService);
        }

        public static void WordsFrequency(string text, TextService textService)
        {
            Dictionary<string, int> collectionOfWords = new Dictionary<string, int>();
            textService.WordsFrequency(text, ref collectionOfWords);
            foreach (KeyValuePair<string, int> keyValue in collectionOfWords)
            {
                Console.WriteLine(keyValue.Key + ":" + keyValue.Value);
            }
        }

        public static void WordsPosition(string path, TextService textService)
        {
            while (true)
            {
                Console.WriteLine("Please, input the word you're looking for");
                string inputWord = Console.ReadLine();
                textService.WordsPosition(path, inputWord);
            }
        }
    }
}
