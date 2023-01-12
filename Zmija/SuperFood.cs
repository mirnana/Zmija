using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    internal class SuperFood : TimedFood
    {
        public SuperFood() : base()
        {
            Points = 50;
            Color = Brushes.Goldenrod;
        }
    }
}
