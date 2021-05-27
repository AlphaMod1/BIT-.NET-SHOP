using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Models.Items
{
    public class Item
    {
        public string Name { get; set; }
        private int Stock { get; set; }
        public double Price { get; set; }
        
        public void AddItem(int amount)
        {
            this.Stock += amount;
        }

        public void RemoveItem(int amount)
        {
            if(this.Stock >= amount)
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
