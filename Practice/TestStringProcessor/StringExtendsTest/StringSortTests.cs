using System.Text;
using Practice;

namespace TestStringProcessor;

public class StringSortTests
{
    [TestCase(SortType.TreeSort)]
    [TestCase(SortType.Quicksort)]
    public void EmptyStringTest(SortType sortType)
    {
        var testString = "";
        Assert.That(testString.Sort(sortType), Is.EqualTo(""));
    }
    
    [TestCase(SortType.TreeSort)]
    [TestCase(SortType.Quicksort)]
    public void NullStringTest(SortType sortType)
    {
        string testString = null;
        Assert.Throws<ArgumentNullException>(() => testString.Sort(sortType));
    }

    [Test]
    public void IncorrectSortTypeTest()
    {
        var testString = "abc";
        Assert.Throws<ArgumentOutOfRangeException>(() => testString.Sort((SortType) 3));
    }

    [TestCase(SortType.TreeSort)]
    [TestCase(SortType.Quicksort)]
    public void DirectOrderStringTest(SortType sortType)
    {
        var testString = "abcde";
        Assert.That(testString.Sort(sortType), Is.EqualTo("abcde"));
    }

    [TestCase(SortType.TreeSort)]
    [TestCase(SortType.Quicksort)]
    public void ReverseOrderStringTest(SortType sortType)
    {
        var testString = "edcba";
        Assert.That(testString.Sort(sortType), Is.EqualTo("abcde"));
    }

    [TestCase(SortType.TreeSort)]
    [TestCase(SortType.Quicksort)]
    public void RandomStringTest(SortType sortType)
    {
        var random = new Random();
        var length = random.Next(20, 50);

        var charArray = new List<char>(length);
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < length; i++)
        {
            var symbol = (char) random.Next('a', 'z');
            stringBuilder.Append(symbol);
            charArray.Add(symbol);
        }

        charArray.Sort();
        Assert.That(stringBuilder.ToString().Sort(sortType), Is.EqualTo(new string(charArray.ToArray())));
    }
}