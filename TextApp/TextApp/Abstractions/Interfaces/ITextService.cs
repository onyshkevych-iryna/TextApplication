using System.Collections.Generic;
using System.IO;

namespace TextApp.Abstractions.Interfaces
{
    public interface ITextService
    {
        public void WordsFrequency(string text, ref Dictionary<string, int> collectionOfWords);
        public void WordsPosition(string path, string inputWord);
    }
}
