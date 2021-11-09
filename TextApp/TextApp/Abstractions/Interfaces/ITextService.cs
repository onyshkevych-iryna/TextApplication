using System.Collections.Generic;
using System.IO;

namespace TextApp.Abstractions.Interfaces
{
    public interface ITextService
    {
        void WordsFrequency(string text, ref Dictionary<string, int> collectionOfWords);
        void WordsPosition(StreamReader sr, string inputWord);
    }
}
