using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Practice;

namespace TestStringProcessor;

public class AlphabetCheckStringTests
{
    private Regex alphabet;

    [SetUp]
    public void Setup()
    {
        var stringProcessor = new StringProcessor(null, null);
        var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
        var field = typeof(StringProcessor).GetField("Alphabet", bindFlags);
        alphabet = field.GetValue(stringProcessor) as Regex;
    }
    
    [Test]
    public void EmptyStringTest()
    {
        var testString = "";
        
        CollectionAssert.AreEqual(Array.Empty<char>(), testString.FindOutsideAlphabetChars(alphabet));
    }
    
    [Test]
    public void NullStringTest()
    {
        string testString = null;

        Assert.Throws<ArgumentNullException>(() => testString.FindOutsideAlphabetChars(alphabet));
    }

    [Test]
    public void UpperCaseTest()
    {
        var testString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var outsideAlphabetChars = testString.FindOutsideAlphabetChars(alphabet);
        CollectionAssert.AreEqual(testString.ToCharArray(),outsideAlphabetChars);
    }

    [Test]
    public void LowerCaseTest()
    {
        var testString = "abcdefghijklmnopqrstuvwxyz";
        var outsideAlphabetChars = testString.FindOutsideAlphabetChars(alphabet);
        CollectionAssert.AreEqual(Array.Empty<char>(),outsideAlphabetChars);
    }

    [Test]
    public void NumbersTest()
    {
        var testString = "1234567890";
        var outsideAlphabetChars = testString.FindOutsideAlphabetChars(alphabet);
        CollectionAssert.AreEqual(testString.ToCharArray(),outsideAlphabetChars);
    }

    [Test]
    public void SymbolsTest()
    {
        var testString = "!@#$%^&*()~`-_=+<>,./?\\\"':;]}[{|";
        var outsideAlphabetChars = testString.FindOutsideAlphabetChars(alphabet);
        CollectionAssert.AreEqual(testString.ToCharArray(),outsideAlphabetChars);
    }

    [TestCase("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ")]
    [TestCase("абвгдеёжзийклмнопрстуфхцчшщъыьэюя")]
    public void OtherAlphabetTest(string testString)
    {
        var outsideAlphabetChars = testString.FindOutsideAlphabetChars(alphabet);
        CollectionAssert.AreEqual(testString.ToCharArray(),outsideAlphabetChars);
    }
}