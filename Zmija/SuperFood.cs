using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// Ova podklasa predstavlja tip hrane koji, ukoliko ga zmija pojede, igrac dobije 50 bodova (standardnih je 20). 
    /// </summary>
    internal class SuperFood : TimedFood
    {
        public SuperFood() : base()
        {
            Points = 50;
            Color = Brushes.Goldenrod;
        }
    }
}
