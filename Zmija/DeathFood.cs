using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    internal class DeathFood : TimedFood
    {
        public DeathFood() : base()
        {
            Points = 0;
            Color = Brushes.Black;
        }

        public override (int, int) ActivateEffect(List<Unit> Snake, int score, int lives)
        {
            return (score, lives - 1);
        }
    }
}
