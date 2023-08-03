namespace Practice;

public class UserWriter
{
    public static string AskString()
    {
        Console.WriteLine("Input string:");
        return Console.ReadLine().Trim();
    }
    
    public static void WriteResult(string processedString, Dictionary<char, int> charsCount, string maxSubstring)
    {
        Console.WriteLine("\nResult:");
        Console.WriteLine(processedString);
        
        Console.WriteLine("Number of repetitions of the symbol:");
        foreach (var (symbol, count) in charsCount)
        {
            Console.WriteLine($"{symbol}: {count}");
        }
        
        Console.WriteLine($"The longest line starting and ending with a vowel: {maxSubstring}");
    }
    
    public static void WriteExceptionMessage(string message)
    {
        Console.WriteLine(message);
    }
}