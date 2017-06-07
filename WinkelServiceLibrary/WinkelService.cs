using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WinkelServiceLibrary.DAO;
using WinkelServiceLibrary.DAO.Hardcoded;
using WinkelServiceLibrary.DAO.SQLServer;

namespace WinkelServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WinkelService" in both code and config file together.
    public class WinkelService : IWinkelService
    {
        public enum dataSet
        {
            HARDCODED,
            MSSQL
        }

        static JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

        static private IProduct productDao;
        static private IGebruiker gebruikerDao;
        static private bool bInitializedDao = false;
        public WinkelService()
        {
            if (bInitializedDao)
                return;

            var dataSource = dataSet.HARDCODED;

            if (dataSource == dataSet.HARDCODED)
            {
                productDao = new HCProduct();
                gebruikerDao = new HCGebruiker();
            }
            else if (dataSource == dataSet.MSSQL)
            {
                productDao = new SQLProduct();
                gebruikerDao = new SQLGebruiker();
            }
            else
                throw new NotImplementedException();

            bInitializedDao = true;
        }

        public bool Registreren(string gebruikersnaam, string wachtwoord)
        {
            return gebruikerDao.Registreer(gebruikersnaam, wachtwoord);
        }

        public bool Inloggen(string gebruikersnaam, string wachtwoord)
        {
            return gebruikerDao.ControleerCredentials(gebruikersnaam, wachtwoord);
        }

        public double SaldoInformatie(string gebruikersnaam, string wachtwoord)
        {
            // Alleen mogelijk met geldige credentials
            if (!Inloggen(gebruikersnaam, wachtwoord))
                return 0;

            return gebruikerDao.VerkrijgSaldo(gebruikersnaam);
        }

        public string ProductenVerkijgen()
        {
            return jsonSerializer.Serialize(productDao.GetProducten());
        }

        public bool Koop(string gebruikersnaam, string wachtwoord, int productid, int aantal)
        {
            // Alleen mogelijk met geldige credentials
            if (!Inloggen(gebruikersnaam, wachtwoord))
                return false;

            if (aantal <= 0)
                return false;

            var productPrijs = productDao.VerkrijgPrijs(productid);
            if (productPrijs == -1)
                return false;

            if (aantal > productDao.VerkrijgAantal(productid))
                return false;

            if (productPrijs * aantal > gebruikerDao.VerkrijgSaldo(gebruikersnaam))
                return false;

            if (!productDao.VerkoopProduct(productid, aantal))
                return false;

            if (!gebruikerDao.KoopProduct(gebruikersnaam, productid, aantal, productPrijs))
                return false;

            return true;
        }

        public string KoopHistory(string gebruikersnaam, string wachtwoord)
        {
            // Alleen mogelijk met geldige credentials
            if (!Inloggen(gebruikersnaam, wachtwoord))
                return "";

            var aankoopId = gebruikerDao.VerkrijgAankopen(gebruikersnaam);
            var aankoopLijst = new List<Tuple<String, double>>();
            var productLijst = ProductenVerkijgen();
            for (int i = 0; i < aankoopId.Count; ++i)
            {
                // Heb verwijst naar DAO.Product
                foreach(DAO.Product p in productDao.GetProducten())
                {
                    if (p.Id == aankoopId[i])
                        aankoopLijst.Add(new Tuple<string, double>(p.naam, p.prijs));

                }
            }

            return jsonSerializer.Serialize(aankoopLijst);
        }
    }
}
