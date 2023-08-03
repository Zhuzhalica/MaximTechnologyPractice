using System.Text.RegularExpressions;

namespace Practice;

public class Program
{
    private static Regex alphabet = new Regex(@"[a-z]");

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
        var charsCount = StringProcessor.CharCounter(processedString);

        UserWriter.WriteResult(processedString, charsCount);
    }
}