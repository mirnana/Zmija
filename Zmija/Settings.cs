using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmija
{
    internal class Settings
    {
        public static int UnitWidth { get; set; }
        public static int UnitHeight { get; set; }
        public static string Direction { get; set; }

        public static string GoLeftKey { get; set; }
        public static string GoRightKey { get; set; }
        public static string GoUpKey { get; set; }
        public static string GoDownKey { get; set; }
        
        public Settings()
        {
            UnitWidth = 16;
            UnitHeight = 16;
            Direction = "left";

            GoLeftKey = Keys.Left.ToString();
            GoRightKey = Keys.Right.ToString();
            GoUpKey = Keys.Up.ToString();
            GoDownKey = Keys.Down.ToString();
        }

        public void ChangeKey(string key)
        {
            // kasnije
        }
    }
}
