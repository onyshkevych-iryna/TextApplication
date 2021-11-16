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
            string path = null;
            CheckIfFileIsValid(ref path);
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
                    Console.WriteLine(
                        "\nPlease, input the word you're looking for or enter \"1\" to quit the program:\n");
                    userInput = Console.ReadLine();
                    if (userInput != "1")
                    {
                        textService.WordsPosition(userInput);
                    }
                    else
                        Console.WriteLine("\nYou have quit the program.");
                } while (userInput != "1");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void CheckIfFileIsValid(ref string path)
        {
            var fileIsValid = false;
            do 
            { 
                Console.WriteLine("Please, write the file address:");
                path = Console.ReadLine();
                fileIsValid = (!File.Exists(path) || Path.GetExtension(path) != ".txt");
                if (fileIsValid)
                    Console.WriteLine("There is no such path or file's extension is not \".txt\". Please, try again:");
            } 
            while (fileIsValid);
        }
    }
}
