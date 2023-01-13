using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmija
{
    public class Settings
    {
        public int UnitWidth { get; set; }
        public int UnitHeight { get; set; }
        public string Direction { get; set; }

        public string GoLeftKey { get; set; }
        public string GoRightKey { get; set; }
        public string GoUpKey { get; set; }
        public string GoDownKey { get; set; }
        public string SettingsKey { get; set; }
        public string InstructionsKey { get; set; }
        public string CloseKey { get; set; }
        
        public Settings()
        {
            UnitWidth = 16;
            UnitHeight = 16;
            Direction = "left";

            GoLeftKey = Keys.Left.ToString();
            GoRightKey = Keys.Right.ToString();
            GoUpKey = Keys.Up.ToString();
            GoDownKey = Keys.Down.ToString();
            SettingsKey = Keys.P.ToString();
            InstructionsKey = Keys.U.ToString();
            CloseKey = Keys.Escape.ToString();
        }
    }
}
