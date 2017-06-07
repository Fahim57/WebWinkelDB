using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinkelClient
{
    static class SessionHandler
    {
        static public WinkelServiceClient.WinkelServiceClient webClient = new WinkelServiceClient.WinkelServiceClient();
        static public string gebruikersnaam;
        static public string wachtwoord;
    }
}
