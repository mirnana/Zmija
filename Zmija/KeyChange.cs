using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Zmija
{
    /// <summary>
    /// kontrola za izmjenu tipke za pojedinu funkcionalnost
    /// </summary>
    public partial class KeyChange : UserControl
    {
        private string keyAux;
        public KeyChange()
        {
            InitializeComponent();
        }

        /// <summary>
        /// funkcionalnost za koju korisnik mijenja tipke ovom kontrolom
        /// </summary>
        public string functionality
        {
            get { return functionality_label.Text; }
            set { functionality_label.Text = value; }
        }

        /// <summary>
        /// tipka pridružena funkcionalnosti pridruženoj ovoj kontroli
        /// </summary>
        public string key
        {
            get { return key_label.Text; }
            set { key_label.Text = value; }
        }

        /// <summary>
        /// dodatna tipka (npr. Shift, Ctrl, Alt) potrebna za postizanje određene funkcionalnosti. Korisnik ovo ne može mijenjati!
        /// </summary>
        public string command
        {
            get { return command_label.Text; }
            set { command_label.Text = value; }
        }

        /// <summary>
        /// događaj kojim korisnik potvrđuje izmjenu tipke
        /// </summary>
        public event EventHandler<string> izmijeni_Click;

        private void changeKey_button_Click(object sender, EventArgs e)
        {
            keyAux = key_label.Text;
            if (izmijeni_Click != null)
            {
                izmijeni_Click(this, key);
            }
        }

        private void KeyChange_Enter(object sender, EventArgs e)
        {
            keyAux = key_label.Text;
            this.BackColor = SystemColors.ActiveCaption;
        }

        private void KeyChange_Leave(object sender, EventArgs e)
        {
            key_label.Text = keyAux;
            this.BackColor = SystemColors.Control;
        }

        // da bi kontrola mogla ispravno reagirati na KeyDown događaje, potrebno je override-ati ovu metodu
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            List<Keys> unwanted = new List<Keys>
            {
                Keys.Shift,
                Keys.ShiftKey,
                Keys.Control,
                Keys.ControlKey,
                Keys.Alt
            };  // ne želimo da korisnik odabere zauzete tipke za neku funkcionalnost
            if (!unwanted.Contains(keyData)) {
                key_label.Text = keyData.ToString();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
