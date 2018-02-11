using System.Net;
using System.Text;
using static System.IO.File;

namespace HTTPServer.Page
{
    public class IndexPage : AbstractPage
    {
        protected string _url = @"/";

        public IndexPage(HttpListenerContext context)
        {
            _context = context;
            _responseText = ReadAllText(@"view\index.html");
        }
    }
}