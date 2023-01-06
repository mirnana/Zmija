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
    public partial class KeySettings : Form
    {
        public KeySettings()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void KeySettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == ZmijaForm.settings.CloseKey)
            {
                this.Close();
            }
        }

        private void izmijeni_Click_left(object sender, string e)
        {
            ZmijaForm.settings.GoLeftKey = ((KeyChange)sender).key;
            foreach (Control c in panelLeft.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = ((KeyChange)sender).key;
                }
            }
        }

        private void Load_left(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.GoLeftKey;
        }

        private void izmijeni_Click_right(object sender, string e)
        {
            ZmijaForm.settings.GoRightKey = ((KeyChange)sender).key;
            foreach (Control c in panelRight.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = ((KeyChange)sender).key;
                }
            }
        }

        private void Load_right(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.GoRightKey;
        }

        private void izmijeni_Click_up(object sender, string e)
        {
            ZmijaForm.settings.GoUpKey = ((KeyChange)sender).key;
            foreach (Control c in panelUp.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = ((KeyChange)sender).key;
                }
            }
        }

        private void Load_up(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.GoUpKey;
        }

        private void izmijeni_Click_down(object sender, string e)
        {
            ZmijaForm.settings.GoDownKey = ((KeyChange)sender).key;
            foreach (Control c in panelDown.Controls)
            {
                if (c is KeyChange)
                {
                    ((KeyChange)c).key = ((KeyChange)sender).key;
                }
            }
        }

        private void Load_down(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.GoDownKey;
        }

        private void keyChange_keySettings_izmijeni_Click(object sender, string e)
        {
            ZmijaForm.settings.SettingsKey = ((KeyChange)sender).key;
        }

        private void keyChange_keySettings_Load(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.SettingsKey;
        }

        private void keyChange_instructions_izmijeni_Click(object sender, string e)
        {
            ZmijaForm.settings.InstructionsKey = ((KeyChange)sender).key;
        }

        private void keyChange_instructions_Load(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.InstructionsKey;
        }

        private void keyChange_close_izmijeni_Click(object sender, string e)
        {
            ZmijaForm.settings.CloseKey = ((KeyChange)sender).key;
        }

        private void keyChange_close_Load(object sender, EventArgs e)
        {
            ((KeyChange)sender).key = ZmijaForm.settings.CloseKey;
        }
    }
}
