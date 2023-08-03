using System.Text.RegularExpressions;

namespace Practice;

public class Program
{
    private static readonly Regex alphabet = new Regex(@"[a-z]");
    private static readonly Regex substringRegex = new Regex("[aeiouy].*[aeiouy]");

    public static void Main()
    {
        var str = UserWriter.AskString();
        var incorrectChars = str.FindOutsideAlphabetChars(alphabet);

        if (incorrectChars.Length != 0)
        {
            UserWriter.WriteExceptionMessage("The string contains invalid characters: " +
                                             string.Join(", ", incorrectChars));
            return;
        }

        var processedString = StringProcessor.StringProcessing(str);
        var charsCount = processedString.CharCounter();
        var maxSubstring = processedString.FindMaxSubstring(substringRegex);

        UserWriter.WriteResult(processedString, charsCount, maxSubstring);
    }
}