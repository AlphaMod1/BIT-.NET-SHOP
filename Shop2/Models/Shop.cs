using Shop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2.Models
{
    public class Shop
    {
        public Shop()
        {

        }
        public String Name { get; set; }

        public List<Product> Items { get; set; }

    }
}
