using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Practice.Random;

namespace Practice;

public class ProcessedString
{
    public string originalString { get; }
    public string processedString { get; private set; }

    public Dictionary<char, int> charsCount { get; private set; }
    public string maxSubstring { get; private set; }
    public string sortedProcessedString { get; private set; }
    public string truncateLine { get; private set; }

    public ProcessedString(string originalString, SortType sortType = SortType.Quicksort, Regex substringRegex = null,
        IRandomNumber random = null)
    {
        this.originalString = originalString;

        processedString = StringProcessing(originalString);
        
        charsCount = processedString.CharCounter();
        sortedProcessedString = processedString.Sort(sortType);
        maxSubstring = GetMaxSubstring(substringRegex);
        truncateLine = GetTruncateString(random);
    }

    private string GetMaxSubstring(Regex substringRegex)
    {
        if (substringRegex != null)
            return processedString.FindMaxSubstring(substringRegex);

        return processedString;
    }
    private string GetTruncateString(IRandomNumber random)
    {
        if (processedString == "")
            return processedString;
        
        var truncateIndex = 0;
        
        if (random != null)
        {
            truncateIndex = random.GetHttpRandomNumber(0, processedString.Length - 1);
            if (truncateIndex == -1)
                truncateIndex = random.GetNetRandomNumber(0, processedString.Length-1);
        }
        

        return processedString.Remove(truncateIndex, 1);;
    }

    public static string StringProcessing([NotNull] string str)
    {
        if (str == null)
            throw new ArgumentNullException();
        

        if (str.Length % 2 == 0)
        {
            var headReverse = str.Substring(0, str.Length / 2).Reverse();
            var tailReverse = str.Substring(str.Length / 2, str.Length / 2).Reverse();
            return string.Join("", headReverse) + string.Join("", tailReverse);
        }
        else
        {
            var strReverse =str.Reverse();
            return string.Join("", strReverse) + str;
        }
    }
}