using System.Text.RegularExpressions;
using Practice.Random;

namespace Practice;

public class StringProcessor
{
    private static readonly Regex Alphabet = new Regex(@"[a-z]");
    private static readonly Regex SubstringRegex = new Regex("[aeiouy].*[aeiouy]");
    private  readonly IRandomNumber _random;
    private readonly StringProcessorConfig _config;

    public StringProcessor(IRandomNumber randomNumber, StringProcessorConfig config)
    {
        _random = randomNumber;
        _config = config;
    }

    public string Run(string str, SortType sortType)
    {
        Thread.Sleep(10000);
        CheckCorrectInputString(str);
        
        var processedString = StringProcessing(str);
        var charsCount = processedString.CharCounter();
        var maxSubstring = processedString.FindMaxSubstring(SubstringRegex);
        var sortedProcessedString = processedString.Sort(sortType);

        var number = _random.GetHttpRandomNumber(0, processedString.Length - 1);
        var truncateLine = processedString.Remove(number, 1);

        return DataWriter.WriteResult(processedString, charsCount, maxSubstring, sortedProcessedString, truncateLine);
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

    public static string StringProcessing(string str)
    {
        if (str.Length % 2 == 0)
        {
            var headReverse = str.Substring(0, str.Length / 2).Reverse();
            var tailReverse = str.Substring(str.Length / 2, str.Length / 2).Reverse();
            return string.Join("", headReverse) + string.Join("", tailReverse);
        }
        else
        {
            var strReverse = str.Reverse();
            return string.Join("", strReverse) + str;
        }
    }
}