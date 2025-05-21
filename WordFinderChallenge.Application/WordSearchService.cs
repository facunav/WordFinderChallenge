using WordFinderChallenge.Domain;

namespace WordFinderChallenge.Application
{
    public class WordSearchService : IWordSearchService
    {
        private readonly WordFinder _wordFinder;

        public WordSearchService(IEnumerable<string> matrix)
        {
            _wordFinder = new WordFinder(matrix);
        }

        public (IDictionary<string, int> Results, long ElapsedMilliseconds) SearchWords(IEnumerable<string> words)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var results = _wordFinder.Find(words);
            sw.Stop();
            return (results, sw.ElapsedMilliseconds);
        }
    }
}
