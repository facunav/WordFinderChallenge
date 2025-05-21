namespace WordFinderChallenge.Application
{
    public interface IWordSearchService
    {
        (IDictionary<string, int> Results, long ElapsedMilliseconds) SearchWords(IEnumerable<string> words);
    }
}
