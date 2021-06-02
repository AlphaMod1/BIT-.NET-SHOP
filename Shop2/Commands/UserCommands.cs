using Shop2.Interfaces;
using Shop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Commands
{
    class UserCommands
    {
        public static User Login(String[] req, List<User> users, User currentUser, ILogger logger)
        {
            if (currentUser != null)
            {
                logger.Write("Invalid command");
                return currentUser;
            }
            User user = null;
            if (req.Length < 2)
            {
                logger.Write("Missing name");
            }
            else
            {
                user = users.Where(i => i.Name == req[1]).FirstOrDefault();
                if (user == null)
                {
                    logger.Write("User not found");
                }
            }
            return user;
        }

        public static void Balance(Session session, ILogger logger)
        {
            if (session.CurrentUser != null)
            {
                logger.Write(session.CurrentUser.Balance + "$");
            }
            else
            {
                logger.Write("Invalid command");
            }
        }

        public static void AddBalance(Session session, List<User> users, String[] req, ILogger logger)
        {
            if (session.CurrentUser != null && session.CurrentUser.IsAdmin &&
                session.CurrentUser.currentShop != null && req.Length <= 3)
            {
                int amount;
                if (int.TryParse(req[2], out amount))
                {
                    User user = users.Where(i => i.Name == req[1]).FirstOrDefault();
                    if (user != null)
                    {
                        user.Balance += amount;
                    }
                    else
                    {
                        logger.Write("Product not found");
                    }
                }
                else
                {
                    logger.Write("Invalid amount");
                }
            }
            else
            {
                logger.Write("Invalid command");
            }

        }

        public static void Help(Session session, ILogger logger)
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
                "listProducts - lists items in the shop",
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
                "addBalance {name} {amount} - adds balance to a user",
                "-------------------------------------------------"
            };

            if (session.CurrentUser == null)
            {
                foreach (string command in commandsDefault)
                {
                    logger.Write(command);
                }
            }
            else if (!session.CurrentUser.IsAdmin)
            {
                foreach (string command in commandsUser)
                {
                    logger.Write(command);
                }
            }
            else if (session.CurrentUser.IsAdmin)
            {
                foreach (string command in commandsAdmin)
                {
                    logger.Write(command);
                }
            }
        }
    }
}
