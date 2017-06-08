using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO.SQLServer
{
    class SQLGebruiker : IGebruiker
    {
        public bool ControleerCredentials(string gebruikersnaam, string wachtwoord)
        {
            try
            {
                using (WinkelModel db = new WinkelModel())
                {
                    WinkelServiceLibrary.tbGebruiker gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam.ToLower() == gebruikersnaam.ToLower() && g.wachtwoord == wachtwoord);
                    if (gebruiker != null)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool KoopProduct(string gebruikersnaam, int productid, int tal, double prijs)
        {
            using (WinkelModel db = new WinkelModel())
            {
                WinkelServiceLibrary.tbProduct product = db.tbProductSet.Single(p => p.Id == productid);

                WinkelServiceLibrary.tbGebruiker gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam == gebruikersnaam);
                if (product.aantal < tal)
                    return false;
                else
                {
                    product.aantal = product.aantal - tal;
                    tbAankoopRegel ar = new tbAankoopRegel { Product_Id = productid , aantal = tal };
                   
                    tbAankoop ak = new tbAankoop { Gebruiker_Id = gebruiker.Id , aankoopdatum = DateTime.Today };
                    ak.AankoopRegels.Add(ar);
                    db.tbAankoopSet.Add(ak);
                    db.SaveChanges();
                    return true;
                }

            }

        }

        private bool BestaatGebruiker(string gebruikersnaam)
        {
            try
            {
                using (WinkelModel db = new WinkelModel())
                {
                    WinkelServiceLibrary.tbGebruiker gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam.ToLower() == gebruikersnaam.ToLower());
                    if (gebruiker != null)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Registreer(string gebruikersnaam, string wachtwoord)
        {
            try
            {
                using (WinkelModel db = new WinkelModel())
                {
                    if (BestaatGebruiker(gebruikersnaam))
                        return false;

                    WinkelServiceLibrary.tbGebruiker gr = new WinkelServiceLibrary.tbGebruiker { gebruikersnaam = gebruikersnaam, wachtwoord = wachtwoord, saldo = 100 };
                    db.tbGebruikerSet.Add(gr);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<int> VerkrijgAankopen(string gebruikersnaam)
        {
            List<int> producten = new List<int>();
            using (WinkelModel db = new WinkelModel())
            {
                var products = from p in db.tbProductSet
                               select p;

                foreach (var p in products)
                    producten.Add(p.Id);
            }

            return producten;
        }

        public double VerkrijgSaldo(string gebruikersnaam)
        {
            using (WinkelModel db = new WinkelModel())
            {
                Gebruiker gr = new Gebruiker { gebruikersnaam = gebruikersnaam};
                return gr.saldo;
            }
        }
    }
}
