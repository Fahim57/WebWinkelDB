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
              //  var products = from p in db.Producten
              //                 select p;
                //foreach (Product p in products)
                //{
                //    Product x = new 
                //}
            }
            throw new NotImplementedException();
        }

        public bool VerkoopProduct(int productId, int aantal)
        {
            throw new NotImplementedException();
        }

        public int VerkrijgAantal(int productId)
        {
            throw new NotImplementedException();
        }

        public double VerkrijgPrijs(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
