using Shop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Commands
{
    class ShopCommands
    {
        public static void ListShops(List<Shop> shops, Session session)
        {
            if (session.CurrentUser != null)
            {
                Console.WriteLine("Shops:");
                foreach (Shop shop in shops)
                {
                    Console.WriteLine(shop.Name);
                }
            }
            else
            {
                Console.WriteLine("Invalid command");
            }
        }

        public static Shop SelectShop(List<Shop> shops, Session session, String[] req)
        {
            Shop shop = null;
            if (req.Length < 2)
            {
                Console.WriteLine("Missing name");
                return null;
            }
            if (session.CurrentUser != null)
            {
                shop = shops.Where(i => i.Name == req[1]).FirstOrDefault();
                if (shop == null)
                {
                    Console.WriteLine("User not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid command");
            }
            return shop;
        }
    }
}
