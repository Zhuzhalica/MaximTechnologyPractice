using System.Text;
using Microsoft.Extensions.Primitives;

namespace Practice;

public class UserWriter
{
    public static string WriteResult(string processedString, Dictionary<char, int> charsCount,
        string maxSubstring, string sortedString, string truncateString)
    {
        var sb = new StringBuilder();
        
        sb.Append(WriteProcessedString(processedString));
        sb.Append(WriteSymbolRepetitionsNumber(charsCount));
        sb.Append(WriteMaxVowelSubstring(maxSubstring));
        sb.Append(WriteSortedString(sortedString));
        sb.Append(WriteTruncateString(truncateString));

        return sb.ToString();
    }

    private static string WriteTruncateString(string truncateString)
    {
       return $"Truncate string: {truncateString}";
    }

    private static string WriteProcessedString(string processedString)
    {
        return $"Result: {processedString}\n";
    }

    private static string WriteSymbolRepetitionsNumber(Dictionary<char, int> charsCount)
    {
        var sb = new StringBuilder();
        sb.Append("Number of repetitions of the symbol:\n");
        foreach (var (symbol, count) in charsCount)
        {
           sb.Append($"{symbol}: {count}\n");
        }

        return sb.ToString();
    }

    private static string WriteMaxVowelSubstring(string maxSubstring)
    {
        return $"The longest line starting and ending with a vowel: {maxSubstring}\n";
    }

    private static string WriteSortedString(string sortedString)
    {
        return $"Sorted string: {sortedString}\n";
    }
}