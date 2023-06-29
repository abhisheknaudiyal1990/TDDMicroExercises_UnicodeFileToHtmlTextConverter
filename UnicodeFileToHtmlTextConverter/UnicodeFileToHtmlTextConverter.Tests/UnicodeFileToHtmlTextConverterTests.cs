using NUnit.Framework;
using System.IO;
using System.Reflection;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter;
namespace UnicodeFileToHtmlTextConverter.Tests
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTests
    {
        private TDDMicroExercises.UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter _converter;
        private string _testFilePath;
        [SetUp]
        public void Setup()
        {
            _testFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestFile.txt");
            _converter = new TDDMicroExercises.UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter(_testFilePath);
        }


        [Test]
        public void ConvertToHtml_WhenFileIsEmpty_ReturnsEmptyString()
        {
            string expected = string.Empty;
            File.WriteAllText(_testFilePath, string.Empty);

            string result = _converter.ConvertToHtml();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ConvertToHtml_WhenFileContainsSingleLine_ReturnsHtmlEncodedLineWithBreakTag()
        {
            string line = "This is a test.";
            string expected = $"This is a test.<br />";
            File.WriteAllText(_testFilePath, line);

            string result = _converter.ConvertToHtml();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ConvertToHtml_WhenFileContainsMultipleLines_ReturnsHtmlEncodedLinesWithBreakTags()
        {
            string line1 = "Line 1";
            string line2 = "Line 2";
            string line3 = "Line 3";
            string expected = $"Line 1<br />Line 2<br />Line 3<br />";
            File.WriteAllLines(_testFilePath, new[] { line1, line2, line3 });

            string result = _converter.ConvertToHtml();

            Assert.AreEqual(expected, result);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_testFilePath);
        }
    }
}