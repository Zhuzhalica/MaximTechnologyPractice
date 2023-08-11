using NUnit.Framework;
using Practice;

namespace TestStringProcessor;

public class StringProcessingTests
{
    [Test]
    public void EmptyStringTest()
    {
        var resultString = ProcessedString.StringProcessing("");
        Assert.That(resultString, Is.EqualTo(""));
    }
    
    [Test]
    public void NullStringTest()
    {
        Assert.Throws<ArgumentNullException>(() => ProcessedString.StringProcessing(null));
    }
    
    [TestCase("ab", "ab")]
    [TestCase("abcd", "badc")]
    [TestCase("abcdef", "cbafed")]
    public void EvenLengthTest(string inputString, string expectedString)
    {
        var resultString = ProcessedString.StringProcessing(inputString);
        Assert.That(resultString, Is.EqualTo(expectedString));
    }
    
    [TestCase("a", "aa")]
    [TestCase("abc", "cbaabc")]
    [TestCase("abcde", "edcbaabcde")]
    public void OddLengthTest(string inputString, string expectedString)
    {
        var resultString = ProcessedString.StringProcessing(inputString);
        Assert.That(resultString, Is.EqualTo(expectedString));
    }
}