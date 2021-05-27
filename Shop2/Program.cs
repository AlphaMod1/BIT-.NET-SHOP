using Shop2.Commands;
using Shop2.Models.Items;
using Shop2.Models.Shops;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop2
{
    class Program
    {
        public static List<User> users = new List<User>();
        public static List<Shop> shops = new List<Shop>();
        public static Session session = new Session()
        {
            CurrentUser = null
        };

        static void Main(string[] args)
        {
            Init();
            string command = "";
            

            while (command != "exit")
            {
                command = Console.ReadLine();
                String[] req = command.Split(" ");

                switch (req[0])
                {
                    case "help":
                        Help.Print(session);
                        break;

                    case "login":
                        session.CurrentUser = Login.LoginTo(req, users, session.CurrentUser);
                        break;

                    case "logout":
                        session.CurrentUser = null;
                        break;

                    case "buy":

                        break;

                    case "list":

                        break;

                    case "bal":

                        break;

                    case "addbal":

                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
        private static void Init()
        {
            users.Add(
                new User()
                {
                    Name = "Vardenis",
                    Bal = 500,
                    IsAdmin = false
                });
            users.Add(
                new User()
                {
                    Name = "Admin",
                    Bal = 999,
                    IsAdmin = true
                });

            List<Item> candies = new List<Item>() { };
            List<Item> books = new List<Item>() { };
            List<Item> products = new List<Item>() { };

            shops.Add(
                new Shop()
                {
                    Name = "Iki",
                    Items = products
                });
        }
    }
}
