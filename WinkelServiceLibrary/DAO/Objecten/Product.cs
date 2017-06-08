using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO
{
    public class Product
    {
        private static int s_id = 0;

        public int Id { get; private set; }
        public string naam { get; set; }
        public double prijs { get; set; }
        public int aantal { get; set; }

        public Product(string naam, double prijs, int aantal)
        {
            this.Id = s_id++;
            this.naam = naam;
            this.prijs = prijs;
            this.aantal = aantal;
        }

        // Als de identifiers vanuit de database komen, overschrijf de statische waarden
        public Product(int id, string naam, double prijs, int aantal) : this(naam, prijs, aantal)
        {
            this.Id = id;

            // Alleen verhogen als de identifier groter of gelijk is aan de huidige, anders kunnen er dubbele identifiers optreden
            if(id >= s_id)
                s_id = id += 1;
        }
    }
}
