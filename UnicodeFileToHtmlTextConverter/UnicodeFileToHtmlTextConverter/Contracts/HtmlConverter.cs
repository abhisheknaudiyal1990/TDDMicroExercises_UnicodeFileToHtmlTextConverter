using System.Web;

namespace UnicodeFileToHtmlTextConverter.Contracts
{
    public class HtmlConverter : IHtmlConverter
    {
        public string ConvertToHtml(string text)
        {
            return HttpUtility.HtmlEncode(text).Replace("\n", "<br />");
        }
    }
}