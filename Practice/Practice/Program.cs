using System.Text.RegularExpressions;

namespace Practice;

public class Program
{
    private static Regex alphabet = new Regex(@"[a-z]");

    public static void Main()
    {
        Console.WriteLine("Input string:");
        var str = Console.ReadLine().Trim();

        var incorrectChars = str.FindOutsideAlphabetChars(alphabet);

        if (incorrectChars.Length != 0)
        {
            Console.WriteLine("The string contains invalid characters: " + string.Join(", ", incorrectChars));
            return;
        }

        Console.WriteLine("Result:");
        Console.WriteLine(PracticeOneSolution(str));
    }

    public static string PracticeOneSolution(string str)
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