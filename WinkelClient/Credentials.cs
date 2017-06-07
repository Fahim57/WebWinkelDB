using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinkelClient
{
    public partial class Credentials : Form
    {
        public Credentials()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenWinkel()
        {
            Winkel winkel = new Winkel();
            winkel.ShowDialog();
        }

        private void login_Click(object sender, EventArgs e)
        {
            var res = SessionHandler.webClient.Inloggen(loginGebruikersnaam.Text, loginWachtwoord.Text);
            if(!res)
                MessageBox.Show("Incorrect wachtwoord", "Fout", MessageBoxButtons.OK);
            else
            {
                SessionHandler.gebruikersnaam = loginGebruikersnaam.Text;
                SessionHandler.wachtwoord = loginWachtwoord.Text;
                OpenWinkel();
            }
        }

        private void registreer_Click(object sender, EventArgs e)
        {
            var res = SessionHandler.webClient.Registreren(registreerGebruikersnaam.Text, registreerGebruikersnaam.Text);
            if (!res)
                MessageBox.Show("Deze gebruikersnaam is al bezet of is te kort (minimum 3 characters)", "Fout", MessageBoxButtons.OK);
            else
            {
                SessionHandler.gebruikersnaam = registreerGebruikersnaam.Text;
                SessionHandler.wachtwoord = registreerWachtwoord.Text;
                OpenWinkel();
            }
        }
    }
}
