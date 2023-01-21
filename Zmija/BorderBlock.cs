using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// Ova podklasa predstavlja ciglu od kojih gradimo zidove, ukoliko ga zmija dotakne igrac gubi jedan zivot.
    /// </summary>
    internal class BorderBlock : BasicFood
    {
        public BorderBlock() : base()
        {
            Color = Brushes.DarkGray;
        }

        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            return (score, lives - 1, timer, false);
        }
    }
}
