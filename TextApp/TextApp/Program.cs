using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Threading.Channels;
using TextApp.Services;

namespace TextApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write the file address:");
            var path = Console.ReadLine();
            if (!File.Exists(path))
            {
                while (!File.Exists(path))
                {
                    Console.WriteLine("There is no such path! Please, try again");
                    path = Console.ReadLine();
                }
            }
            try
            {
                string text = null;
                text = File.ReadAllText(path);
                Console.WriteLine("\nText from a file:");
                Console.WriteLine(text);
                var textService = new TextService(path);
                var collectionOfWords = textService.WordsFrequency(text);
                Console.WriteLine("\nStatistics:");
                foreach (KeyValuePair<string, int> keyValue in collectionOfWords)
                {
                    Console.WriteLine(keyValue.Key + ":" + keyValue.Value);
                }

                string userInput = null;
                do
                {
                    Console.WriteLine("\nPlease, input the word you're looking for or enter \"1\" to quit the program\n");
                    userInput = Console.ReadLine();
                    if (userInput != "1")
                    {
                        textService.WordsPosition(userInput);
                    }
                    Console.WriteLine("\nYou have quit the program");
                } while (userInput != "1");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
    
}
