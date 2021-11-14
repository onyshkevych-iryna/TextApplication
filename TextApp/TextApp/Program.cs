using System;
using System.Collections.Generic;
using System.IO;
using TextApp.Services;

namespace TextApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write the file address:");
            string path = Console.ReadLine();
            TextService textService = new TextService(path);
            try
            {
                string text = null;
                text = File.ReadAllText(path);
                Console.WriteLine("\nText from a file:");
                Console.WriteLine(text);
                Dictionary<string, int> collectionOfWords = textService.WordsFrequency(text);
                Console.WriteLine("\nStatistics:");
                foreach (KeyValuePair<string, int> keyValue in collectionOfWords)
                {
                    Console.WriteLine(keyValue.Key + ":" + keyValue.Value);
                }
                while (true)
                {
                    Console.WriteLine("\nPlease, input the word you're looking for");
                    string inputWord = Console.ReadLine();
                    textService.WordsPosition(inputWord);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
