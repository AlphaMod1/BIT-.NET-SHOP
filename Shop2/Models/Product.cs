using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Models
{
    public class Product
    {

        public Product()
        {

        }

        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public void AddItem(int amount)
        {
            Stock += amount;
        }

        public void RemoveItem(int amount)
        {
            if (this.Stock >= amount)
            {
                this.Stock -= amount;
            }
            else
            {
                Console.WriteLine("Requesting more items then available");
            }
        }
    }
}
