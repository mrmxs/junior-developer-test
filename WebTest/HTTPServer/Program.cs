namespace HTTPServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string uri = @"http://127.0.0.1:8080/";

            var server = new Server(uri);
            server.Start();
        }
    }
}