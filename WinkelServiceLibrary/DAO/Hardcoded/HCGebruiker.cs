using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO.Hardcoded
{
    public class HCGebruiker : IGebruiker
    {
        List<Gebruiker> gebruikers;

        public HCGebruiker()
        {
            gebruikers = new List<Gebruiker>();
        }

        // Local
        private Gebruiker ZoekGebruiker(string gebruikersnaam)
        {
            // Zoek gebruiker op case insensitive naam
            foreach (Gebruiker g in gebruikers)
            {
                if (gebruikersnaam.ToLower().CompareTo(g.gebruikersnaam.ToLower()) == 0)
                    return g;
            }

            return null;
        }

        // Interface
        public bool ControleerCredentials(string gebruikersnaam, string wachtwoord)
        {
            Gebruiker g = ZoekGebruiker(gebruikersnaam);
            if (g == null)
                return false;

            // Controleer of wachtwoorden niet gelijk zijn
            if (wachtwoord.CompareTo(g.wachtwoord) != 0)
                return false;

            return true;
        }

        // Interface
        public bool Registreer(string gebruikersnaam, string wachtwoord)
        {
            // Valideer input
            if (gebruikersnaam.Length < 3 || wachtwoord.Length < 3)
                return false;

            // Controleer of gebruiker al bestaat
            Gebruiker g = ZoekGebruiker(gebruikersnaam);
            if (g != null)
                return false;

            // Maak een nieuwe gebruiker aan binnen het systeem
            g = new Gebruiker();
            g.saldo = 1000;
            g.gebruikersnaam = gebruikersnaam;
            g.wachtwoord = wachtwoord;
            gebruikers.Add(g);

            return true;
        }

        // Interface
        public double VerkrijgSaldo(string gebruikersnaam)
        {
            Gebruiker g = ZoekGebruiker(gebruikersnaam);
            if (g == null)
                return 0;

            return g.saldo;
        }

        public bool KoopProduct(string gebruikersnaam, int productid, int aantal, double prijs)
        {
            Gebruiker g = ZoekGebruiker(gebruikersnaam);
            if (g == null)
                return false;

            for (int i = 0; i < aantal; ++i)
                g.aankopen.Add(productid);

            g.saldo -= prijs * aantal;

            return true;
        }

        public List<int> VerkrijgAankopen(string gebruikersnaam)
        {
            Gebruiker g = ZoekGebruiker(gebruikersnaam);
            if (g == null)
                return null;

            return g.aankopen;
        }
    }
}
