using System.Net;
using System.Text.RegularExpressions;
using static System.Console;

namespace HTTPServer
{
    public class Server
    {
        private string _uri;
        private HttpListener _server;
        private bool _flag = false;

        public Server(string uri)
        {
            _uri = uri;
            _server = new HttpListener();
        }

        public void Start()
        {
            _server.Prefixes.Add(_uri);
            WriteLine("Start server on http://127.0.0.1:8080/");
            _server.Start();
            WriteLine("Listen...");

            while (_server.IsListening)
            {
                var context = _server.GetContext();
                var request = context.Request;
                var action = context.Request.Url.AbsolutePath;

                if (request.HttpMethod == "GET" && action == "/")
                {
                    (new Page.IndexPage(context)).SendResponse();
                }
                else if (request.HttpMethod == "GET" && action == "/view" &&
                         Regex.IsMatch(context.Request.Url.Query, @"\?name=.+&color=.+&years18=.+&daytime=.+"))
                {
                    (new Page.ViewPage(context)).SendResponse();
                }

                else if (request.HttpMethod == "POST" && action == "/post" && request.HasEntityBody)
                {
                    (new Page.PostPage(context)).SendResponse();
                }
                else
                {
                    context.Response.Redirect("/");
                    context.Response.Close();
                }
            }
        }
    }
}