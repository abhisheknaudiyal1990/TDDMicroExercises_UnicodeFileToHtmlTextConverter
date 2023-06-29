using System.IO;

namespace UnicodeFileToHtmlTextConverter.Contracts
{
    public class FileReader : IFileReader
    {
        public string ReadFile(string fullFilenameWithPath)
        {
            using (TextReader unicodeFileStream = File.OpenText(fullFilenameWithPath))
            {
                return unicodeFileStream.ReadToEnd();
            }
        }
    }
}
