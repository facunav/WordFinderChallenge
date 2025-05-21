using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordFinderChallenge.Application;
using WordFinderChallenge.Infrastructure;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var wordList = new List<string> { "cold", "wind", "heat", "storm", "snow", "rain", "cloud", "sun", "fog", "freeze" };

        var matrix = MatrixGeneratorHelper.GenerateMatrix(64, wordList, maxWords: 10);

        services.AddSingleton<IWordSearchService>(new WordSearchService(matrix));
    });

var host = builder.Build();

var wordSearchService = host.Services.GetRequiredService<IWordSearchService>();

var wordsToFind = new List<string> { "cold", "wind", "heat", "storm", "snow", "rain", "cloud", "sun", "fog", "freeze" };

var (results, elapsed) = wordSearchService.SearchWords(wordsToFind);

Console.WriteLine($"Found words in {elapsed} ms:");
foreach (var (word, count) in results)
{
    Console.WriteLine($"{word}: {count}");
}
