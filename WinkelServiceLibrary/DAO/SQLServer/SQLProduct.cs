using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO.SQLServer
{
    class SQLProduct : IProduct
    {
        public List<Product> GetProducten()
        {
            List<Product> producten = new List<Product>();
            using (WinkelModel db = new WinkelModel())
            {
                var products = from p in db.tbProductSet
                               select p;

                if (products == null)
                    return null;

                foreach (var p in products)
                    producten.Add(new Product(p.Id, p.naam, p.prijs, p.aantal));
            }

            return producten;
        }

        public bool VerkoopProduct(int productId, int aantal)
        {
            using (WinkelModel db = new WinkelModel())
            {
                tbProduct product = db.tbProductSet.Single(p => p.Id == productId);
                if (product == null)
                    return false;

                if (product.aantal < aantal)
                    return false;

                product.aantal -= aantal;

                return true;
            }
        }

        public int VerkrijgAantal(int productId)
        {
            using (WinkelModel db = new WinkelModel())
            {
                tbProduct product = db.tbProductSet.Single(p => p.Id == productId);
                return product.aantal;
            }
        }

        public double VerkrijgPrijs(int productId)
        {
            using (WinkelModel db = new WinkelModel())
            {
                tbProduct product = db.tbProductSet.Single(p => p.Id == productId);
                return product.prijs;
            }
        }
    }
}
