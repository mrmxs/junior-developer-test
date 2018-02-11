using System;

namespace UserApplication
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static User RandomUser()
        { 
            var r = new Random();  
            var id = r.Next(0, 100);

            return new User(id, "user" + id);
        }
    }
}