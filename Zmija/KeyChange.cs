using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmija
{
    public partial class KeyChange : UserControl
    {
        public KeyChange()
        {
            InitializeComponent();
        }

        public string functionality
        {
            get { return functionality_label.Text; }
            set { functionality_label.Text = value; }
        }

        public string key
        {
            get { return key_label.Text; }
            set { key_label.Text = value; }
        }

        public string command
        {
            get { return command_label.Text; }
            set { command_label.Text = value; }
        }

        public event EventHandler<string> izmijeni_Click;

        private void changeKey_button_Click(object sender, EventArgs e)
        {
            if (izmijeni_Click != null)
            {
                izmijeni_Click(this, key);
            }
        }

        private void KeyChange_Enter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ActiveCaption;
        }

        private void KeyChange_Leave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void changeKey_button_KeyDown(object sender, KeyEventArgs e)
        {
            key = e.KeyCode.ToString();
            key_label.Text = key;
        }
    }
}
