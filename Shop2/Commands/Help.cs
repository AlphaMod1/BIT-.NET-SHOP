using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Commands
{
    public class Help
    {
        public static void Print(Session session)
        {
            List<String> commandsDefault = new List<String>
            {
                "-------------------------------------------------",
                "exit - Exits app",
                "login {name} - to login",
                "-------------------------------------------------"
            };

            List<String> commandsUser = new List<String>
            {
                "-------------------------------------------------",
                "exit - Exits app",
                "logout - to logout",
                "listShops - lists all shops",
                "selectShop {shop} - selects a shop",
                "listItems - lists items in the shop",
                "buy {itemName} {amount} - buys an item",
                "balance - displays users balance",
                "-------------------------------------------------"
            };

            List<String> commandsAdmin = new List<String>
            {
                "-------------------------------------------------",
                "exit - Exits app",
                "logout - to logout",
                "listShops - lists all shops",
                "selectShop {shop} - selects a shop",
                "listItems - lists items in the shop",
                "restock {item} {amount}",
                "listUsers - lists all users",
                "addBalance {name} {amount} - adds balance to a user",
                "-------------------------------------------------"
            };

            if (session.CurrentUser == null)
            {
                foreach (string command in commandsDefault)
                {
                    Console.WriteLine(command);
                }
            }
            else if (!session.CurrentUser.IsAdmin)
            {
                foreach (string command in commandsUser)
                {
                    Console.WriteLine(command);
                }
            }
            else if (session.CurrentUser.IsAdmin)
            {
                foreach (string command in commandsAdmin)
                {
                    Console.WriteLine(command);
                }
            }



        }
    }
}
