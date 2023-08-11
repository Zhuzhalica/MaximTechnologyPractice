using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Practice.Random;

namespace Practice;

public class StringProcessor
{
    private static readonly Regex Alphabet = new Regex(@"[a-z]");
    private static readonly Regex SubstringRegex = new Regex("[aeiouy].*[aeiouy]|[aeiouy]");
    private readonly IRandomNumber _random;
    private readonly StringProcessorConfig _config;

    public StringProcessor(IRandomNumber randomNumber, StringProcessorConfig config)
    {
        _random = randomNumber;
        _config = config;
    }

    public ProcessedString Processing([NotNull] string str, SortType sortType)
    {
        if (str == null)
            throw new ArgumentNullException();

        // Thread.Sleep(10000);
        CheckCorrectInputString(str);

        return new ProcessedString(str, sortType, SubstringRegex, _random);
    }

    private void CheckCorrectInputString(string str)
    {
        var incorrectChars = str.FindOutsideAlphabetChars(Alphabet);
        if (incorrectChars.Length != 0)
        {
            throw new ArgumentException($"The string contains invalid characters: {string.Join(", ", incorrectChars)}");
        }

        if (_config.BlackList.Any(forbiddenWord => str == forbiddenWord))
            throw new ArgumentException($"The word {str} is forbidden");
    }
}