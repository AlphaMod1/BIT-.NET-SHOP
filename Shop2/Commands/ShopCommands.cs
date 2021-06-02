using Shop2.Interfaces;
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
        public static void ListShops(List<Shop> shops, Session session, ILogger logger)
        {
            if (session.CurrentUser != null)
            {
                logger.Write("Shops:");
                foreach (Shop shop in shops)
                {
                    logger.Write(shop.Name);
                }
            }
            else
            {
                logger.Write("Invalid command");
            }
        }

        public static Shop SelectShop(List<Shop> shops, Session session, String[] req, ILogger logger)
        {
            Shop shop = null;
            if (req.Length < 2)
            {
                logger.Write("Missing name");
                return null;
            }
            if (session.CurrentUser != null)
            {
                shop = shops.Where(i => i.Name == req[1]).FirstOrDefault();
                if (shop == null)
                {
                    logger.Write("User not found");
                }
            }
            else
            {
                logger.Write("Invalid command");
            }
            return shop;
        }
    }
}
