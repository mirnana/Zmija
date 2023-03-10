using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zmija
{
    /// <summary>
    /// Ova podklasa predstavlja tip hrane koji, ukoliko ga zmija pojede, donosi negativne bodove igracu.
    /// </summary>
    internal class BadFood : BasicFood
    {
        public BadFood() : base()
        {
            Points = -10;
            Color = Brushes.SaddleBrown;
        }
    }
}
