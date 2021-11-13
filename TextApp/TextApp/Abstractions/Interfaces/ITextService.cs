using System.Collections.Generic;
using System.IO;

namespace TextApp.Abstractions.Interfaces
{
    public interface ITextService
    {
        public Dictionary<string, int> WordsFrequency(string text);
        public void WordsPosition(string inputWord);
    }
}
