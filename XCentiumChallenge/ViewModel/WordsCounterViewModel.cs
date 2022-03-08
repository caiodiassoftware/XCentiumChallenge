using System.Collections.Generic;
using System.Linq;

namespace XCentiumChallenge.ViewModel
{
    public class WordsCounterViewModel
    {
        public int Total { get; private set; }

        public Dictionary<string, int> WordOccurency { get; private set; }

        public WordsCounterViewModel() { }

        public WordsCounterViewModel(IEnumerable<string> words)
        {
            if (words != null)
            {
                Total = words.Distinct().Count();
                WordOccurency = words.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            }
        }

        public bool HasWords()
        {
            return WordOccurency != null && WordOccurency.Any();
        }

        public Dictionary<string, int> GetRanking(int rank = 7)
        {
            return HasWords() ? WordOccurency.OrderByDescending(x => x.Value).Take(rank).ToDictionary(pair => pair.Key, pair => pair.Value) : new Dictionary<string, int>();
        }
    }
}