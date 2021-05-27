using Shop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Commands
{
    class ProductCommands
    {
        public static void ListProducts(Session session)
        {
            if (session.CurrentUser != null && session.CurrentUser.currentShop != null)
            {
                Console.WriteLine("Products:");
                Console.WriteLine("Name\t|Price\t|Stock");
                Console.WriteLine("=========================");
                foreach (Product product in session.CurrentUser.currentShop.Items)
                {
                    Console.WriteLine($"{product.Name}\t|{product.Price}$\t|{product.Stock}");
                }
            }
            else
            {
                Console.WriteLine("Invalid command");
            }
        }
        public static void Buy(Session session, String[] req)
        {
            if (session.CurrentUser != null && !session.CurrentUser.IsAdmin &&
                session.CurrentUser.currentShop != null && req.Length <= 3)
            {
                int amount;
                if (int.TryParse(req[2], out amount))
                {
                    Product product = session.CurrentUser.currentShop.Items.Where(i => i.Name == req[1]).FirstOrDefault();
                    if (product != null)
                    {
                        if (session.CurrentUser.Balance >= product.Price * amount)
                        {
                            session.CurrentUser.Balance -= product.Price * amount;
                            product.RemoveItem(amount);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount");
                }
            }
            else
            {
                Console.WriteLine("Invalid command");
            }

        }
        public static void Restock(Session session, String[] req)
        {
            if (session.CurrentUser != null && session.CurrentUser.IsAdmin &&
                session.CurrentUser.currentShop != null && req.Length <= 3)
            {
                int amount;
                if (int.TryParse(req[2], out amount))
                {
                    Product product = session.CurrentUser.currentShop.Items.Where(i => i.Name == req[1]).FirstOrDefault();
                    if (product != null)
                    {
                        product.AddItem(amount);
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount");
                }
            }
            else
            {
                Console.WriteLine("Invalid command");
            }
        }

    }
}
