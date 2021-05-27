using Shop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop2
{
    public class User
    {
        public String Name { get; set; }
        public double Balance { get; set; }
        public bool IsAdmin { get; set; }
        public Shop currentShop { get; set; }
    }
}
