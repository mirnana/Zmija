using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// Klasa predstavlja opcenite karakteristike vecine tipova hrane. Ukoliko ju zmija pojede, 
    /// donosi 20 bodova igracu te produljuje zmiju za jednu jedinicu.
    /// </summary>
    internal class BasicFood : Unit
    {
        /// <summary>
        /// Broj bodova koje nosi svaki pojedeni komad hrane
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// Boja pojedine vrste hrane
        /// </summary>
        public Brush Color { get; set; }

        public BasicFood() : base()
        {
            Points = 20;
            Color = Brushes.Red;
        }

        /// <summary>
        /// Metoda se poziva kada se hrana pojede. Vraca parametre koje je moguce promijeniti.
        /// Moze dodati ili oduzeti jedinice zmije.
        /// U osnovnoj verziji dodaje jednu jedinicu i 20 bodova.
        /// </summary>
        public virtual (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            Unit rear = new Unit
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y,
            };
            Snake.Add(rear);
            return (score + Points, lives, timer, false);
        }

        /// <summary>
        /// Metoda za provjeru trajanja hrane. U osnovnoj klasi hrana ne istjece.
        /// </summary>
        public virtual bool CheckTimer() { return true; }
    }
}
