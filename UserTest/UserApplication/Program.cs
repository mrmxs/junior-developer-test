using System;
using System.Threading.Tasks;

namespace UserApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ur = new UserRepository();

            var circles = 100;
            var rnd = new Random();
            while (circles > 0)
            {
                Task.Run(() => ur.AddUser(new User((int) Task.CurrentId, "u" + Task.CurrentId)));
                Task.Run(() => ur.GetUser(rnd.Next(0, 16)*5));
                Task.Run(() => ur.GetOrderedUsers());
                Task.Run(() => ur.GetUser(rnd.Next(0, 16)*5));
                Task.Run(() => ur.GetOrderedUsers());
                circles--;
            }

            Task.WaitAll();
            Console.ReadLine();
        }
    }
}