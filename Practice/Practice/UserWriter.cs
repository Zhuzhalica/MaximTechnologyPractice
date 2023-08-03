namespace Practice;

public class UserWriter
{
    public static string AskString()
    {
        Console.WriteLine("Input string:");
        return Console.ReadLine().Trim();
    }
    
    public static void WriteResult(string processedString)
    {
        Console.WriteLine("\nResult:");
        Console.WriteLine(processedString);
    }
    
    public static void WriteExceptionMessage(string message)
    {
        Console.WriteLine(message);
    }
}