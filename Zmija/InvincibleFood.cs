using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// Ova podklasa predstavlja tip hrane koji, ukoliko ga zmija pojede, cini zmiju imunu na doticanje sa zidovima, sa drugim zmijama te sa samom sobom. 
    /// Ova vrsta hrane se pojavljuje u trajanju od 30 sekundi.
    /// </summary>
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
