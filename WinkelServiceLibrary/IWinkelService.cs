using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WinkelServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWinkelService" in both code and config file together.
    [ServiceContract]
    public interface IWinkelService
    {
        [OperationContract]
        bool Registreren(string gebruikersnaam, string wachtwoord);
        [OperationContract]
        bool Inloggen(string gebruikersnaam, string wachtwoord);
        [OperationContract]
        double SaldoInformatie(string gebruikersnaam, string wachtwoord);
        [OperationContract]
        string ProductenVerkijgen();
        [OperationContract]
        bool Koop(string gebruikersnaam, string wachtwoord, int productid, int aantal);
        [OperationContract]
        string KoopHistory(string gebruikersnaam, string wachtwoord);
    }
}
