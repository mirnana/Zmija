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
    public partial class Instructions : Form
    {
        public Instructions()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void Instructions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == ZmijaForm.settings.CloseKey)
            {
                this.Close();
            }
        }
    }
}
