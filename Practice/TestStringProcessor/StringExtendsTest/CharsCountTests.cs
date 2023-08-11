using System.Reflection;
using System.Text.RegularExpressions;
using Practice;

namespace TestStringProcessor;

public class CharsCountTests
{
    [Test]
    public void EmptyStringTest()
    {
        var testString = "";
        var expectedDictionary = new Dictionary<char, int>();
        
        CollectionAssert.AreEqual(expectedDictionary, testString.CharCounter());
    }
    
    [Test]
    public void NullStringTest()
    {
        string testString = null;

        Assert.Throws<ArgumentNullException>(() => testString.CharCounter());
    }
    
    [Test]
    public void CountAllCharsTest()
    {
        for (var symbol = 'a'; symbol <= 'z'; symbol++)
        {
            var testString = $"{symbol}";
            var expectedDictionary = new Dictionary<char, int> {{symbol, 1}};

            CollectionAssert.AreEqual(expectedDictionary, testString.CharCounter());
        }
    }

    [Test]
    public void CountDifferentCharsInStringTest()
    {
        var testString = "abcd";
        var expectedDictionary = new Dictionary<char, int> {{'a', 1}, {'b', 1}, {'c', 1}, {'d', 1}};
        
        CollectionAssert.AreEqual(expectedDictionary, testString.CharCounter());
    }

    [Test]
    public void CountOneCharsInStringTest()
    {
        var testString = "aaaa";
        var expectedDictionary = new Dictionary<char, int> {{'a', 4}};

        CollectionAssert.AreEqual(expectedDictionary, testString.CharCounter());
    }
}