using System.Collections.Generic;
using System.Linq;

namespace TextApp.Abstractions.Interfaces
{
    public interface ITextService
    {
        public IOrderedEnumerable<KeyValuePair<string, int>> WordsFrequency(string text);
        public void WordsPosition(string inputWord);
    }
}
