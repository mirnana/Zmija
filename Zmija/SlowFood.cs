using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    internal class SlowFood : BasicFood
    {
        /// <summary>
        /// Ova podklasa predstavlja tip hrane koji, ukoliko ga zmija pojede, usporava kretanje zmije. 
        /// Zmija naraste za jednu jedinicu.
        /// </summary>
        public SlowFood() : base()
        {
            Color = Brushes.Yellow;
        }

        /// <summary>
        /// Metoda se poziva kada se hrana pojede. Zmija dobiva jednu jedinicu i usporava do dozvoljene granice.
        /// Dodaju se bodovi.
        /// </summary>
        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            Unit rear = new Unit
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y,
            };
            Snake.Add(rear);
            if(timer < 10)
            {
                timer += 1;
            }
            
            return (score + Points, lives, timer, false);
        }
    }
}
