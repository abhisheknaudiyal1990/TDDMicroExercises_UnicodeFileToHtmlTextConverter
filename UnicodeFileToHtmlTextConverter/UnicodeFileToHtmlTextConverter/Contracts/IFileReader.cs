namespace UnicodeFileToHtmlTextConverter.Contracts
{
    public interface IFileReader
    {
        string ReadFile(string fullFilenameWithPath);
    }
}
