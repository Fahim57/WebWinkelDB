using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelServiceLibrary.DAO
{
    public interface IGebruiker
    {
        bool ControleerCredentials(string gebruikersnaam, string wachtwoord);
        bool Registreer(string gebruikersnaam, string wachtwoord);
        double VerkrijgSaldo(string gebruikersnaam);
        bool KoopProduct(string gebruikersnaam, int productid, int aantal, double prijs);
        List<int> VerkrijgAankopen(string gebruikersnaam);
    }
}
