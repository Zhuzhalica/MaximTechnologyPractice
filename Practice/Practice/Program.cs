using System.Globalization;
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
        
        var sortType = GetSortType();
        var sortedProcessedString = processedString.Sort(sortType);

        UserWriter.WriteResult(processedString, charsCount, maxSubstring, sortedProcessedString);
    }

    private static SortType GetSortType()
    {
        var sortTypeAnswer = UserWriter.AskSortedType();
        var result = int.TryParse(sortTypeAnswer, out var number);
        return ConvertNumberSortType(result ? number : -1);
    }

    private static SortType ConvertNumberSortType(int n)
    {
        return n switch
        {
            1 => SortType.Quicksort,
            2 => SortType.TreeSort,
            _ => SortType.Quicksort
        };
    }
}