using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO
{
    public interface IProduct
    {
        List<Product> GetProducten();
        double VerkrijgPrijs(int productId);
        int VerkrijgAantal(int productId);
        bool VerkoopProduct(int productId, int aantal);
    }
}
