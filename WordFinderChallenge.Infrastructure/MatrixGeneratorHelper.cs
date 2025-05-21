using System.Text;

namespace WordFinderChallenge.Infrastructure
{
    public static class MatrixGeneratorHelper
    {
        private static Random _random = new();

        public static List<string> GenerateMatrix(int size, List<string> possibleWords, int maxWords = 10)
        {
            var matrix = new char[size, size];

            for (int r = 0; r < size; r++)
                for (int c = 0; c < size; c++)
                    matrix[r, c] = ' ';

            int insertedWordsCount = 0;
            int attempts = 0;

            while (insertedWordsCount < maxWords && attempts < 100)
            {
                var word = possibleWords[_random.Next(possibleWords.Count)].ToUpper();
                if (word.Length > size)
                {
                    attempts++;
                    continue;
                }

                bool horizontal = _random.Next(2) == 0;
                int row = _random.Next(size);
                int col = _random.Next(size - word.Length + 1);

                if (CanInsert(matrix, word, row, col, horizontal))
                {
                    InsertWord(matrix, word, row, col, horizontal);
                    insertedWordsCount++;
                }

                attempts++;
            }

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (matrix[r, c] == ' ')
                        matrix[r, c] = (char)('A' + _random.Next(26));
                }
            }

            var result = new List<string>();
            for (int r = 0; r < size; r++)
            {
                var sb = new StringBuilder();
                for (int c = 0; c < size; c++)
                    sb.Append(matrix[r, c]);
                result.Add(sb.ToString());
            }

            return result;
        }


        private static bool CanInsert(char[,] matrix, string word, int row, int col, bool horizontal)
        {
            for (int i = 0; i < word.Length; i++)
            {
                int r = horizontal ? row : row + i;
                int c = horizontal ? col + i : col;

                if (r >= matrix.GetLength(0) || c >= matrix.GetLength(1))
                    return false;

                if (matrix[r, c] != ' ' && matrix[r, c] != word[i])
                    return false;
            }
            return true;
        }

        private static void InsertWord(char[,] matrix, string word, int row, int col, bool horizontal)
        {
            for (int i = 0; i < word.Length; i++)
            {
                int r = horizontal ? row : row + i;
                int c = horizontal ? col + i : col;
                matrix[r, c] = word[i];
            }
        }
    }
}
