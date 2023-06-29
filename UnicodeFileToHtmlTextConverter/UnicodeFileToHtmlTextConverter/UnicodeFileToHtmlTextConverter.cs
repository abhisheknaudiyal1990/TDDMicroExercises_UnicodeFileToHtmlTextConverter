using System.IO;
using System.Web;
using UnicodeFileToHtmlTextConverter.Contracts;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly IFileReader _fileReader;
        private readonly IHtmlConverter _htmlConverter;
        private readonly string _fullFilenameWithPath;

        public UnicodeFileToHtmlTextConverter(IFileReader fileReader, IHtmlConverter htmlConverter, string fullFilenameWithPath)
        {
            _fileReader = fileReader;
            _htmlConverter = htmlConverter;
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public string ConvertToHtml()
        {
            string fileContent = _fileReader.ReadFile(_fullFilenameWithPath);
            return _htmlConverter.ConvertToHtml(fileContent);
        }
    }
}
