using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    internal class FastFood : BasicFood
    {
        public FastFood() : base()
        {
            Color = Brushes.Blue;
        }

        public override (int, int) ActivateEffect(List<Unit> Snake, int score, int lives)
        {
            //change speed (return?)
            return (score + Points, lives);
        }
    }
}
