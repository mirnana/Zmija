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

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font drawFont = new Font("Arial", 16);

            int i = 0;

            // BasicFood
            g.FillRectangle(Brushes.Red, new Rectangle(16, 16*i + 16, 16, 16));
            g.DrawString("", drawFont, Brushes.Red, new Point(48, 16));
        }
    }
}
