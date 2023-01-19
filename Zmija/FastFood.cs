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

        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            //change speed (return?)
            timer = timer - 50;
            return (score + Points, lives, timer, false);
        }
    }
}
