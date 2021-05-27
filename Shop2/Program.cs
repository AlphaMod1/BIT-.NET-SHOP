using Shop2.Commands;
using Shop2.Models;
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
                        UserCommands.Help(session);
                        break;

                    case "login":
                        session.CurrentUser = UserCommands.Login(req, users, session.CurrentUser);
                        break;

                    case "logout":
                        session.CurrentUser = null;
                        break;

                    case "listShops":
                        ShopCommands.ListShops(shops, session);
                        break;

                    case "selectShop":
                        session.CurrentUser.currentShop = ShopCommands.SelectShop(shops, session, req);
                        break;

                    case "balance":
                        UserCommands.Balance(session);
                        break;

                    case "listProducts":
                        ProductCommands.ListProducts(session);
                        break;

                    case "buy":
                        ProductCommands.Buy(session, req);
                        break;

                    case "restock":
                        ProductCommands.Restock(session, req);
                        break;

                    case "addBalance":
                        UserCommands.AddBalance(session, users, req);
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
                    Balance = 500,
                    IsAdmin = false
                });
            users.Add(
                new User()
                {
                    Name = "Admin",
                    Balance = 999,
                    IsAdmin = true
                });

            List<Product> products1 = new List<Product>() {
                new Product()
                {
                    Name = "Candies",
                    Price = 5.5D,
                    Stock = 50
                },
                new Product()
                {
                    Name = "Books",
                    Price = 80D,
                    Stock = 10
                },
                new Product()
                {
                    Name = "Apples",
                    Price = 3.20D,
                    Stock = 50
                }
            };

            List<Product> products2 = new List<Product>() {
                new Product()
                {
                    Name = "Meats",
                    Price = 80D,
                    Stock = 50
                },
                new Product()
                {
                    Name = "Pens",
                    Price = 1.10D,
                    Stock = 150
                },
                new Product()
                {
                    Name = "Rice",
                    Price = 0.02D,
                    Stock = 8000
                }
            };


            shops.Add(
                new Shop()
                {
                    Name = "Iki",
                    Items = products1
                });

            shops.Add(
                new Shop()
                {
                    Name = "Maxima",
                    Items = products2
                });
        }
    }
}
