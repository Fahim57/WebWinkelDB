using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO.Hardcoded
{
    public class HCProduct : IProduct
    {
        private List<Product> producten;

        public HCProduct()
        {
            producten = new List<Product>();
            producten.Add(new Product("iPad Pro", 159.6, 15));
            producten.Add(new Product("iPad Mini", 35.70, 12));
            producten.Add(new Product("Galaxy S8", 3.2, 7));
        }

        // Local
        private Product ZoekProduct(int id)
        {
            foreach (Product p in producten)
            {
                if(id == p.Id)
                    return p;
            }

            return null;
        }

        public List<Product> GetProducten()
        {
            return producten;
        }

        public int VerkrijgAantal(int productId)
        {
            Product p = ZoekProduct(productId);
            if (p == null)
                return 0;

            return p.aantal;
        }

        public double VerkrijgPrijs(int productId)
        {
            Product p = ZoekProduct(productId);
            if (p == null)
                return -1;

            return p.prijs;
        }

        public bool VerkoopProduct(int productId, int aantal)
        {
            Product p = ZoekProduct(productId);
            if (p == null)
                return false;

            if (p.aantal < aantal)
                return false;

            p.aantal -= aantal;

            return true;
        }
    }
}
