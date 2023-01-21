using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    internal class LifeFood : TimedFood
    {
        public LifeFood() : base()
        {
            Points = 0;
            Color = Brushes.Aqua;
        }

        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            return (score, lives + 1, timer, false);
        }
    }
}
