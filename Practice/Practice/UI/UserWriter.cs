namespace Practice;

public class UserWriter
{
    public static string AskString()
    {
        Console.WriteLine("Input string:");
        return Console.ReadLine().Trim();
    }
    
    public static string AskSortedType()
    {
        Console.WriteLine("Choice sort type:\n1 - Quick Sort | 2 - Tree sort | Any other symbol - Quick Sort");
        return Console.ReadLine().Trim();
    }
    
    public static void WriteResult(string processedString, Dictionary<char, int> charsCount,
        string maxSubstring, string sortedString)
    {
        WriteProcessedString(processedString);
        WriteSymbolRepetitionsNumber(charsCount);
        WriteMaxVowelSubstring(maxSubstring);
        WriteSortedString(sortedString);
    }

    private static void WriteProcessedString(string processedString)
    {
        Console.WriteLine("\nResult:");
        Console.WriteLine(processedString);
    }

    private static void WriteSymbolRepetitionsNumber(Dictionary<char, int> charsCount)
    {
        Console.WriteLine("Number of repetitions of the symbol:");
        foreach (var (symbol, count) in charsCount)
        {
            Console.WriteLine($"{symbol}: {count}");
        }
    }

    private static void WriteMaxVowelSubstring(string maxSubstring)
    {
        Console.WriteLine($"The longest line starting and ending with a vowel: {maxSubstring}");
    }
    
    private static void WriteSortedString(string sortedString)
    {
        Console.WriteLine($"Sorted string: {sortedString}");
    }

    public static void WriteExceptionMessage(string message)
    {
        Console.WriteLine(message);
    }


}