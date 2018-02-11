using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApplication
{
    public class UserRepository
    {
        private volatile ConcurrentBag<User> _users = new ConcurrentBag<User>();
        private readonly object _locker = new object();

        public void AddUser(User user)
        {
            lock (_locker)
            {
                _users.Add(user);
            }
            Console.WriteLine("T{0}[ADD]: {1}", Task.CurrentId, user.Name);
        }

        public User GetUser(int id)
        {
            User result;
            lock (_locker)
            {
                try
                {
                    result = _users.First(user => user.Id == id);
                    Console.WriteLine("T{0}[GET]: id{1} - {2}", Task.CurrentId, id, result.Name);
                    
                    return result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("T{0}[GET]: id{1} not found", Task.CurrentId, id);

                    return null;
                }
            }
        }

        public List<User> GetOrderedUsers()
        {
            lock (_locker)
            {
                var list = _users.ToList();
                list.Sort((u1, u2) => u1.Id.CompareTo(u2.Id));
                Console.WriteLine("T{0}[SORT]:{1}",
                    Task.CurrentId, list.Aggregate("", (agg, user) => (agg + " " + user.Name)));

                return list;
            }
        }
    }
}