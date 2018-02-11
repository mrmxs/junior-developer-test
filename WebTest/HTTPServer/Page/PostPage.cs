using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HTTPServer.Page
{
    public class PostPage : AbstractPage
    {
        protected string _url = @"/post";

        public PostPage(HttpListenerContext context)
        {
            _context = context;

            using (var body = _context.Request.InputStream)
            {
                using (var reader = new StreamReader(body))
                {
                    var query = reader.ReadToEnd();
                    var form = new Helper.FormValidator(query);

                    _responseText = form.IsValid
                        ? "{ \"redirect\": \"/view?" + query + "\" }"
                        : "[\"" + string.Join("\",\"", form.Errors.Values.ToArray()) + "\"]";
                }
            }
        }
    }
}