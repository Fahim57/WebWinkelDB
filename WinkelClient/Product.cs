using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelClient
{
    public class Product
    {
        public int id { get; set; }
        public string naam { get; set; }
        public double prijs { get; set; }
        public int aantal { get; set; }

        public Product()
        {
        }
    }
}
