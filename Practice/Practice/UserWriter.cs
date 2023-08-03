namespace Practice;

public class UserWriter
{
    public static string AskString()
    {
        Console.WriteLine("Input string:");
        return Console.ReadLine().Trim();
    }
    
    public static void WriteResult(string processedString, Dictionary<char, int> charsCount)
    {
        Console.WriteLine("\nResult:");
        Console.WriteLine(processedString);
        
        Console.WriteLine("Number of repetitions of the symbol:");
        foreach (var (symbol, count) in charsCount)
        {
            Console.WriteLine($"{symbol}: {count}");
        }
    }
    
    public static void WriteExceptionMessage(string message)
    {
        Console.WriteLine(message);
    }
}