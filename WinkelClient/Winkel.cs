using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace WinkelClient
{
    public partial class Winkel : Form
    {
        static JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

        public Winkel()
        {
            InitializeComponent();
        }

        private void VerkrijgData()
        {
            var res = SessionHandler.webClient.ProductenVerkijgen();
            var productList = jsonSerializer.Deserialize<List<Product>>(res);
            foreach (Product p in productList)
                productenBox.Rows.Add(p.id, p.naam, p.prijs, p.aantal);

            res = SessionHandler.webClient.KoopHistory(SessionHandler.gebruikersnaam, SessionHandler.wachtwoord);
            var historieList = jsonSerializer.Deserialize<List<Historie>>(res);
            if (historieList != null)
            {
                foreach (Historie h in historieList)
                    historieBox.Rows.Add(h.Item1, h.Item2);
            }
        }

        private void ResetValues()
        {
            productenBox.Rows.Clear();
            historieBox.Rows.Clear();
            VerkrijgData();
            aantalSelector.Value = 1;
            saldoLabel.Text = SessionHandler.webClient.SaldoInformatie(SessionHandler.gebruikersnaam, SessionHandler.wachtwoord).ToString();
        }

        private void Winkel_Load(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void koopButton_Click(object sender, EventArgs e)
        {
            if(productenBox.SelectedRows.Count != 1)
            {
                MessageBox.Show("Er moet 1 product geselecteerd zijn!", "Fout", MessageBoxButtons.OK);
                return;
            }

            var res = SessionHandler.webClient.Koop(SessionHandler.gebruikersnaam, SessionHandler.wachtwoord, (int)productenBox.SelectedRows[0].Cells[0].Value, (int)aantalSelector.Value);
            if (!res)
                MessageBox.Show("Er is iets mis met de bestelling! Controleer uw saldo", "Fout", MessageBoxButtons.OK);

            ResetValues();
        }
    }
}
