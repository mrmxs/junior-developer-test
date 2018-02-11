using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using static System.IO.File;

namespace HTTPServer.Page
{
    public class ViewPage : AbstractPage
    {
        protected string _url = @"/view";

        public ViewPage(HttpListenerContext context)
        {
            _context = context;

            var query = HttpUtility
                .UrlDecode(_context.Request.Url.Query)
                .Replace("?", "")
                .Split('&')
                .Select(param => param.Split('='))
                .ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]);

            _responseText = ReadAllText(@"view\view.html")
                .Replace("%NAME%", query["name"])
                .Replace("%COLOR%", query["color"])
                .Replace("%18-YEARS%", query["years18"] == "false" ? "not" : "")
                .Replace("%DAYTIME%", query["daytime"]);
        }
    }
}