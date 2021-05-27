using Shop2.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Models.Shops
{
    public class Shop
    {
        public String Name { get; set; }

        public List<Item> Items { get; set; }
    }
}
