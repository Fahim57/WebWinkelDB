using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO
{
    class Gebruiker
    {
        public List<int> aankopen;
        public string gebruikersnaam { get; set; }
        public string wachtwoord { get; set; }
        public double saldo { get; set; }

        public Gebruiker()
        {
            aankopen = new List<int>();
        }
    }
}
