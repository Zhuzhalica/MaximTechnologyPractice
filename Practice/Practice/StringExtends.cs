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

    public static Dictionary<char, int> CharCounter(this string str)
    {
        var counter = str
            .GroupBy(x => x, (symbol, chars) => new {symbol, count = chars.Count()})
            .ToDictionary(x => x.symbol, x => x.count);
        return counter;
    }

    public static string FindMaxSubstring(this string str, Regex substringRegex)
    {
        var matches = substringRegex.Matches(str);

        var maxString = "";
        foreach (var match in matches)
        {
            var m = match as Match;
            if (m.Length > maxString.Length)
                maxString = m.Value;
        }


        return maxString;
    }

    public static string Sort(this string str, SortType sortType)
    {
        var chars = str.ToCharArray();

        switch (sortType)
        {
            case SortType.Quicksort:
            {
                var sortedChars = chars.QuickSort(0, chars.Length-1);
                return new string(sortedChars);
            };
            case SortType.TreeSort:
            {
                var sortedChars = chars.TreeSort();
                return new string(sortedChars);
            };
        }

        throw new ArgumentException("Uncorrect sort type");
    }
}