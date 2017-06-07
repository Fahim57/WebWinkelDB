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
                var products = from p in db.ProductSet
                               select p;
                //foreach (Product p in products)
                //{
                //    Product x = new 
                //}
            }
            return producten;
        }

        public bool VerkoopProduct(int productId, int aantal)
        {
            using (WinkelModel db = new WinkelModel())
            {
            }
                throw new NotImplementedException();
        }

        public int VerkrijgAantal(int productId)
        {
            using (WinkelModel db = new WinkelModel())
            {
                WinkelServiceLibrary.Product product = db.ProductSet.Single(p => p.Id == productId);
                return product.aantal;
            }
        }

        public double VerkrijgPrijs(int productId)
        {
            using (WinkelModel db = new WinkelModel())
            {
                WinkelServiceLibrary.Product product = db.ProductSet.Single(p => p.Id == productId);
                return product.prijs;
            }
        }
    }
}
