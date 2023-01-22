using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zmija.Properties;

namespace Zmija
{
    /// <summary>
    /// forma u kojoj korisnik može vidjeti koja tipka je pridružena kojoj funkcionalnosti i izmijeniti navedene tipke
    /// </summary>
    public partial class KeySettings : Form
    {
        public KeySettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda se poziva kada želimo izmijeniti tipku koja aktivira kretanje ulijevo.
        /// </summary>
        private void izmijeni_Click_left(object sender, string e)
        {
            // korisnik je potvrdio koju tipku želi pa mijenjamo tu vrijednost u glavnoj formi
            ZmijaForm.settings.GoLeftKey = e;

            // ako korisnik izmijeni kako se kreće ulijevo, ili ulijevo za određeni broj, ili ulijevo do kraja ploče - onda sve te tri funkcionalnosti moraju imati istu novu tipku. analogno za sve smjerove
            foreach (Control c in panelLeft.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = e;
                }
            }
        }

        /// <summary>
        /// Metoda se poziva pri učitavanju kontrole za kretanje ulijevo.
        /// </summary>
        private void Load_left(object sender, EventArgs e)
        {
            // pri učitavanju svake kontrole moramo dohvatiti potrebnu informaciju iz glavne forme
            ((KeyChange)sender).key = ZmijaForm.settings.GoLeftKey;
        }

        /// <summary>
        /// Metoda se poziva kada želimo izmijeniti tipku koja aktivira kretanje udesno.
        /// </summary>
        private void izmijeni_Click_right(object sender, string e)
        {
            ZmijaForm.settings.GoRightKey = e;
            foreach (Control c in panelRight.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = e;
                }
            }
        }

        /// <summary>
        /// Metoda se poziva pri učitavanju kontrole za kretanje udesno.
        /// </summary>
        private void Load_right(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.GoRightKey;
        }

        /// <summary>
        /// Metoda se poziva kada želimo izmijeniti tipku koja aktivira kretanje prema gore.
        /// </summary>
        private void izmijeni_Click_up(object sender, string e)
        {
            ZmijaForm.settings.GoUpKey = e;
            foreach (Control c in panelUp.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = e;
                }
            }
        }

        /// <summary>
        /// Metoda se poziva pri učitavanju kontrole za kretanje prema gore.
        /// </summary>
        private void Load_up(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.GoUpKey;
        }

        /// <summary>
        /// Metoda se poziva kada želimo izmijeniti tipku koja aktivira kretanje prema dolje.
        /// </summary>
        private void izmijeni_Click_down(object sender, string e)
        {
            ZmijaForm.settings.GoDownKey = e;
            foreach (Control c in panelDown.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = e;
                }
            }
        }

        /// <summary>
        /// Metoda se poziva pri učitavanju kontrole za kretanje prema dolje.
        /// </summary>
        private void Load_down(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.GoDownKey;
        }

        /// <summary>
        /// Metoda se poziva kada želimo izmijeniti tipku koja otvara prozor s postavkama.
        /// </summary>
        private void keyChange_keySettings_izmijeni_Click(object sender, string e)
        {
            ZmijaForm.settings.SettingsKey = e;
        }

        /// <summary>
        /// Metoda se poziva pri učitavanju kontrole za otvaranje prozora s postavkama.
        /// </summary>
        private void keyChange_keySettings_Load(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.SettingsKey;
        }

        /// <summary>
        /// Metoda se poziva kada želimo izmijeniti tipku koja otvara prozor s uputama.
        /// </summary>
        private void keyChange_instructions_izmijeni_Click(object sender, string e)
        {
            ZmijaForm.settings.InstructionsKey = e;
        }

        /// <summary>
        /// Metoda se poziva pri učitavanju kontrole za otvaranje prozora s uputama.
        /// </summary>
        private void keyChange_instructions_Load(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.InstructionsKey;
        }

        /// <summary>
        /// Metoda se poziva kada želimo izmijeniti tipku koja zatvara prozor.
        /// </summary>
        private void keyChange_close_izmijeni_Click(object sender, string e)
        {
            ZmijaForm.settings.CloseKey = e;
        }

        /// <summary>
        /// Metoda se poziva pri učitavanju kontrole za zatvaranje prozora.
        /// </summary>
        private void keyChange_close_Load(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.CloseKey;
        }
    }
}
