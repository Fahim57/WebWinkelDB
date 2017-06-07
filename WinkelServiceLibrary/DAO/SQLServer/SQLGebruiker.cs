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
            using (WinkelModel db = new WinkelModel())
            {
                Gebruiker gebruiker = db.GebruikerSet.Single(g => g.gebruikersnaam == gebruikersnaam && g.wachtwoord == wachtwoord);
                if (gebruiker != null)
                    return true;
                else
                    return false;
            }
        }

        public bool KoopProduct(string gebruikersnaam, int productid, int tal, double prijs)
        {
            using (WinkelModel db = new WinkelModel())
            {
                Product product = db.ProductSet.Single(p => p.Id == productid);
                Gebruiker gebruiker = db.GebruikerSet.Single(g => g.gebruikersnaam == gebruikersnaam);
                if (product.aantal < tal)
                    return false;
                else
                {
                    product.aantal = product.aantal - tal;
                    AankoopRegel ar = new AankoopRegel { Product_Id = productid , aantal = tal };
                   
                    Aankoop ak = new Aankoop { Gebruiker_Id = gebruiker.Id , aankoopdatum = DateTime.Today };
                    ak.AankoopRegels.Add(ar);
                    db.AankoopSet.Add(ak);
                    db.SaveChanges();
                    return true;
                }

            }

        }

        public bool Registreer(string gebruikersnaam, string wachtwoord)
        {
            using (WinkelModel db = new WinkelModel())
            {
                Gebruiker gr = new Gebruiker { gebruikersnaam = gebruikersnaam, wachtwoord = wachtwoord };
                db.GebruikerSet.Add(gr);
                db.SaveChanges();
                return true;
            }
        }

        public List<int> VerkrijgAankopen(string gebruikersnaam)
        {
            throw new NotImplementedException();
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
