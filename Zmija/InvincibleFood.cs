using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    internal class InvincibleFood : TimedFood
    {
        public InvincibleFood() : base()
        {
            Color = Brushes.Magenta;
        }

        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            return (score, lives, timer, true);
        }
    }
}
