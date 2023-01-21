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
    /// <summary>
    /// forma u koju smještamo korisničke upute, odnosno objašnjenja o funkcionalnostima igrice
    /// </summary>
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

        private void pictureBox11_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.SeaGreen, 0, 0, 16, 16);
            Rectangle[] ostali = new Rectangle[]
            {
                new Rectangle(16, 0, 16, 16),
                new Rectangle(16, 16, 16, 16),
                new Rectangle(32, 16, 16, 16),
                new Rectangle(32, 32, 16, 16)
            };
            g.FillRectangles(Brushes.MediumAquamarine, ostali);
        }
    }
}
