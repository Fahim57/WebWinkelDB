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
                    tbGebruiker gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam.ToLower() == gebruikersnaam.ToLower() && g.wachtwoord == wachtwoord);
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
                tbProduct product = db.tbProductSet.Single(p => p.Id == productid);

                tbGebruiker gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam == gebruikersnaam);
                if (gebruiker == null)
                    return false;
                else
                {
                    for(int i=0 ; i < tal; i++)
                    {
                        product.aantal = product.aantal - tal;
                        tbAankoopRegel ar = new tbAankoopRegel { Product_Id = productid, aantal = tal };

                        tbAankoop ak = new tbAankoop { Gebruiker_Id = gebruiker.Id, aankoopdatum = DateTime.Today };
                        gebruiker.saldo -= prijs * tal;
                        ak.AankoopRegels.Add(ar);
                        db.tbAankoopSet.Add(ak);
                    }
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
                    tbGebruiker gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam.ToLower() == gebruikersnaam.ToLower());
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

                    tbGebruiker gr = new tbGebruiker { gebruikersnaam = gebruikersnaam, wachtwoord = wachtwoord, saldo = 1000 };
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
            
            List<int> aankopen = new List<int>();
            using (WinkelModel db = new WinkelModel())
            {
                var gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam.ToLower() == gebruikersnaam.ToLower());
                var aankoop = from ak in db.tbAankoopSet
                              where ak.Gebruiker_Id == gebruiker.Id
                              select ak;
                foreach(var ak in aankoop)
                {
                    var regels = from akr in db.tbAankoopRegelSet
                                         where akr.AankoopId == ak.Id
                                         select akr.Product_Id;
                   foreach (int r in regels)
                    {
                        aankopen.Add(r);
                    }
                }
            }

            return aankopen;
        }

        public double VerkrijgSaldo(string gebruikersnaam)
        {
            using (WinkelModel db = new WinkelModel())
            {
                tbGebruiker gebruiker = db.tbGebruikerSet.Single(g => g.gebruikersnaam.ToLower() == gebruikersnaam.ToLower());
                return gebruiker.saldo;
            }
        }
    }
}
