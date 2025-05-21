namespace WordFinderChallenge.Domain
{
    public class WordFinder
    {
        private readonly string[] _matrix;
        private readonly int _rows;
        private readonly int _cols;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix.Select(r => r.ToUpper()).ToArray();
            _rows = _matrix.Length;
            _cols = _matrix.Length > 0 ? _matrix[0].Length : 0;
        }

        public IDictionary<string, int> Find(IEnumerable<string> wordStream)
        {
            var uniqueWords = new HashSet<string>(wordStream.Select(w => w.ToUpper()));
            var foundWords = new Dictionary<string, int>();

            foreach (var word in uniqueWords)
            {
                int count = CountWordOccurrences(word);
                if (count > 0)
                {
                    foundWords[word] = count;
                }
            }

            return foundWords.OrderByDescending(kvp => kvp.Value)
                             .ThenBy(kv => kv.Key)
                             .Take(10)
                             .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        private int CountWordOccurrences(string word)
        {
            int count = 0;
            int len = word.Length;

            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c <= _cols - len; c++)
                {
                    var slice = _matrix[r].Substring(c, len);
                    if (slice == word) count++;
                }
            }

            for (int c = 0; c < _cols; c++)
            {
                for (int r = 0; r <= _rows - len; r++)
                {
                    bool match = true;
                    for (int i = 0; i < len; i++)
                    {
                        if (_matrix[r + i][c] != word[i])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match) count++;
                }
            }

            return count;
        }
    }
}
