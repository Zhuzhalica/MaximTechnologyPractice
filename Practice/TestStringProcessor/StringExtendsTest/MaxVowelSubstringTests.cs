using System.Reflection;
using System.Text.RegularExpressions;
using Practice;

namespace TestStringProcessor;

public class MaxVowelSubstringTests
{
    private Regex _substringRegex;
    private string[] vowels = new string[] {"a", "o", "e", "i", "u", "y"};

    private string[] consonants = new string[]
        {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z",};

    [SetUp]
    public void Setup()
    {
        var stringProcessor = new StringProcessor(null, null);
        var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        var field = typeof(StringProcessor).GetField("SubstringRegex", bindFlags);
        _substringRegex = field.GetValue(stringProcessor) as Regex;
    }

    [Test]
    public void EmptyStringTest()
    {
        var testString = "";
        Assert.That("", Is.EqualTo(testString.FindMaxSubstring(_substringRegex)));
    }

    [Test]
    public void NullStringTest()
    {
        string testString = null;

        Assert.Throws<ArgumentNullException>(() => testString.FindMaxSubstring(_substringRegex));
    }

    [Test]
    public void OneVowelTest()
    {
        foreach (var vowel in vowels)
        {
            var substring = vowel.FindMaxSubstring(_substringRegex);
            Assert.That(substring, Is.EqualTo(vowel));
        }
    }

    [Test]
    public void OneConsonantTest()
    {
        foreach (var consonant in consonants)
        {
            var substring = consonant.FindMaxSubstring(_substringRegex);
            Assert.That(substring, Is.EqualTo(""));
        }
    }

    [Test]
    public void VowelsPairTest()
    {
        foreach (var firstChar in vowels)
        {
            foreach (var secondChar in vowels)
            {
                var testString = firstChar + secondChar;
                var substring = testString.FindMaxSubstring(_substringRegex);
                Assert.That(substring, Is.EqualTo(testString));
            }
        }
    }

    [TestCase("ab", "a")]
    [TestCase("ba", "a")]
    public void ConsonantVowelTest(string testString, string expectedSubstring)
    {
        var substring = testString.FindMaxSubstring(_substringRegex);
        Assert.That(substring, Is.EqualTo(expectedSubstring));
    }

    [TestCase("aba", "aba")]
    [TestCase("ubtpli", "ubtpli")]
    [TestCase("obhgtrbnky", "obhgtrbnky")]
    public void VowelConsonantVowelTest(string testString, string expectedSubstring)
    {
        var substring = testString.FindMaxSubstring(_substringRegex);
        Assert.That(substring, Is.EqualTo(expectedSubstring));
    }

    [TestCase("bab", "a")]
    [TestCase("buiob", "uio")]
    [TestCase("baoieyub", "aoieyu")]
    public void ConsonantVowelConsonantTest(string testString, string expectedSubstring)
    {
        var substring = testString.FindMaxSubstring(_substringRegex);
        Assert.That(substring, Is.EqualTo(expectedSubstring));
    }

    [Test]
    public void FindMaxSubstringTest()
    {
        var testString = "abababa";
        var substring = testString.FindMaxSubstring(_substringRegex);
        Assert.That(substring, Is.EqualTo("abababa"));
    }
}