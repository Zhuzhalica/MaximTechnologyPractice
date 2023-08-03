using System.Text.RegularExpressions;

namespace Practice;

public static class StringExtends
{
    private static Regex defaultAlphabet = new Regex(@"[a-zA-Z0-9]\s");

    public static char[] FindOutsideAlphabetChars(this string str, Regex? alphabet = null)
    {
        alphabet ??= defaultAlphabet;

        var incorrectChars = alphabet
            .Replace(str, "")
            .ToCharArray();

        return incorrectChars;
    }
}