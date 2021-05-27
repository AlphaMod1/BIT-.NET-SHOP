using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Commands
{
    class Login
    {
        public static User LoginTo(String[] req, List<User> users, User currentUser)
        {
            if(currentUser != null)
            {
                Console.WriteLine("Invalid command");
                return currentUser;
            }
            User user = null;
            if (req.Length < 2)
            {
                Console.WriteLine("Missing name");
            }
            else
            {
                user = users.Where(i => i.Name == req[1]).FirstOrDefault();
                if (user == null)
                {
                    Console.WriteLine("User not found");
                }
            }
            return user;
        }
    }
}
