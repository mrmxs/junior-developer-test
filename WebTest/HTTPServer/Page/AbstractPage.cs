using System.Net;
using System.Text;

namespace HTTPServer.Page
{
    public abstract class AbstractPage
    {
        protected HttpListenerContext _context;
        protected string _url = @"/";
        protected string _responseText;
        
        public void SendResponse()
        {
            var buffer = Encoding.UTF8.GetBytes(_responseText);

            var response = _context.Response;
            response.ContentType = "text/html; charset=UTF-8";
            response.ContentLength64 = buffer.Length;
            using (var output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}