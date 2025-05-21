using WordFinderChallenge.Application;

namespace WordFinderChallenge.Tests
{
    public class WordSearchServiceTests
    {
        [Fact]
        public void SearchWords_Returns_Correct_Words_And_Counts()
        {
            var matrix = new List<string>
            {
                "COLD",
                "WIND",
                "HEAT",
                "SNOW"
            };

            var service = new WordSearchService(matrix);

            var wordsToFind = new List<string> { "cold", "wind", "heat", "storm", "snow", "rain" };

            var (results, elapsed) = service.SearchWords(wordsToFind);

            Assert.Contains(results, r => r.Key == "COLD" && r.Value == 1);
            Assert.Contains(results, r => r.Key == "WIND" && r.Value == 1);
            Assert.Contains(results, r => r.Key == "HEAT" && r.Value == 1);
            Assert.Contains(results, r => r.Key == "SNOW" && r.Value == 1);

            Assert.DoesNotContain(results, r => r.Key == "STORM");
            Assert.DoesNotContain(results, r => r.Key == "RAIN");
        }
    }
}
