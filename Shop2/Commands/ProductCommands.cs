using Shop2.Interfaces;
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
        public static void ListProducts(Session session, ILogger logger)
        {
            if (session.CurrentUser != null && session.CurrentUser.currentShop != null)
            {
                logger.Write("Products:");
                logger.Write("Name\t|Price\t|Stock");
                logger.Write("=========================");
                foreach (Product product in session.CurrentUser.currentShop.Items)
                {
                    logger.Write($"{product.Name}\t|{product.Price}$\t|{product.Stock}");
                }
            }
            else
            {
                logger.Write("Invalid command");
            }
        }
        public static void Buy(Session session, String[] req, ILogger logger)
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
                            logger.Write("Insufficient balance");
                        }
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
        public static void Restock(Session session, String[] req, ILogger logger)
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

    }
}
