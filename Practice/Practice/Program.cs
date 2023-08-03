namespace Practice;

public class Program
{
    public static void Main()
    {
        var str = Console.ReadLine().Trim();
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