using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// Ova podklasa predstavlja tip hrane koji, ukoliko ga zmija pojede, ubrzava kretanje zmije. 
    /// Zmija naraste za jednu jedinicu.
    /// Igrac dobije 20 bodova.
    /// </summary>
    internal class FastFood : BasicFood
    {
        public FastFood() : base()
        {
            Color = Brushes.Blue;
        }

        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            Unit rear = new Unit
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y,
            };
            Snake.Add(rear);
            if(timer > 2)
            {
                timer = timer - 1;
            }
            
            return (score + Points, lives, timer, false);
        }
    }
}
