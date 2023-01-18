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
        /// <summary>
        /// jedinična širina na igraćoj ploči
        /// </summary>
        public int UnitWidth { get; set; }
        /// <summary>
        /// jedinična visina na igraćoj ploči
        /// </summary>
        public int UnitHeight { get; set; }
        /// <summary>
        /// smjer kretanja zmije
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// tipka pomoću koje zmija skreće ulijevo
        /// </summary>
        public string GoLeftKey { get; set; }
        /// <summary>
        /// tipka pomoću koje zmija skreće udesno
        /// </summary>
        public string GoRightKey { get; set; }
        /// <summary>
        /// tipka pomoću koje zmija skreće prema gore
        /// </summary>
        public string GoUpKey { get; set; }
        /// <summary>
        /// tipka pomoću koje zmija skreće prema dolje
        /// </summary>
        public string GoDownKey { get; set; }
        /// <summary>
        /// tipka pomoću koje korisnik otvara formu s postavkama
        /// </summary>
        public string SettingsKey { get; set; }
        /// <summary>
        /// tipka pomoću koje korisnik otvara formu s uputama
        /// </summary>
        public string InstructionsKey { get; set; }
        /// <summary>
        /// tipka pomoću koje korisnik zatvara tekuću formu
        /// </summary>
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
