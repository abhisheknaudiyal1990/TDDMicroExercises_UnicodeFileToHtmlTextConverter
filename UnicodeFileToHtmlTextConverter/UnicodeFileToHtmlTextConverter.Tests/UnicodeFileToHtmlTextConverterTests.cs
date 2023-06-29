using Moq;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using UnicodeFileToHtmlTextConverter.Contracts;

namespace UnicodeFileToHtmlTextConverter.Tests
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTests
    {
        private TDDMicroExercises.UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter _converter;
        private Mock<IFileReader> _mockFileReader;
        private Mock<IHtmlConverter> _mockHtmlConverter;
        private string _testFilePath;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockHtmlConverter = new Mock<IHtmlConverter>();
            _testFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestFile.txt");

            _converter = new TDDMicroExercises.UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter(
                _mockFileReader.Object,
                _mockHtmlConverter.Object,
                _testFilePath);
        }


        [Test]
        public void ConvertToHtml_WhenFileContainsText_CallsFileReaderAndHtmlConverter()
        {
            string fileContent = "This is a test file.";
            string htmlContent = "This is a test file.";

            string expected = string.Empty;
            File.WriteAllText(_testFilePath, string.Empty);

            _mockFileReader.Setup(f => f.ReadFile(It.IsAny<string>())).Returns(fileContent);
            _mockHtmlConverter.Setup(h => h.ConvertToHtml(It.IsAny<string>())).Returns(htmlContent);

            string result = _converter.ConvertToHtml();

            Assert.AreEqual(htmlContent, result);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_testFilePath);
        }
    }
}