using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextApp
{
    class Program
    {
        //C:\Users\iryna.onyshkevych\OneDrive - Valtech\Bureau\programs\TextApp\fileToRead.txt
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write the file address");
            string path = Console.ReadLine();
            StreamReader sr = new StreamReader(@path);
            string text = System.IO.File.ReadAllText(path);
            Console.WriteLine("Text from a file:");

            Console.WriteLine(text);
            string line = null;
            string word = Console.ReadLine();
            List<string> listStrLineElements = null;
            int c = 1;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                listStrLineElements = line.Split(' ').ToList();
                var result = Enumerable.Range(0, listStrLineElements.Count)
                    .Where(i => listStrLineElements[i] == word)
                    .ToList();
                foreach (var item in result)
                    Console.WriteLine(item + 1);
            }
        }
    }
}
