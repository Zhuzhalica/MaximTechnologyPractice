namespace Practice;

public class StringProcessor
{
    public static string StringProcessing(string str)
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

    public static Dictionary<char, int> CharCounter(string str)
    {
        var counter = str
            .GroupBy(x => x, (symbol, chars) => new {symbol, count = chars.Count()})
            .ToDictionary(x => x.symbol, x => x.count);
        return counter;
    }
}