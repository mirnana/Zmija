using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// Ova podklasa predstavlja tip hrane koji, ukoliko ga zmija pojede, skracuje zmiju za 3 jedinice. 
    /// Igrac dobije 20 bodova.
    /// </summary>
    internal class ShortFood : BasicFood
    {
        public ShortFood() : base()
        {
            Color = Brushes.DarkOrange;
        }

        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            if(Snake.Count >= 5)
            {
                Snake.RemoveAt(Snake.Count - 1);
                Snake.RemoveAt(Snake.Count - 1);
                Snake.RemoveAt(Snake.Count - 1);
            }

            return (score + Points, lives, timer, false);
        }
    }
}
