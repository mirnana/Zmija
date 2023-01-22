using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// Ova podklasa predstavlja tip hrane koji, ukoliko ga zmija pojede, igracu oduzima jedan zivot. 
    /// Ova vrsta hrane se pojavljuje u trajanju od 30 sekundi.
    /// </summary>
    internal class DeathFood : TimedFood
    {
        public DeathFood() : base()
        {
            Points = 0;
            Color = Brushes.Black;
        }

        /// <summary>
        /// Metoda se poziva kada se hrana pojede. Zmija gubi jedan zivot.
        /// </summary>
        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            return (score, lives - 1, timer, false);
        }
    }
}
