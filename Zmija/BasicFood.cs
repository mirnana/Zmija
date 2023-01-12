using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zmija
{
    internal class BasicFood : Unit
    {
        public int Points { get; set; }
        public Brush Color { get; set; }

        public BasicFood() : base()
        {
            Points = 10;
            Color = Brushes.Red;
        }
        // nova metoda - activate effect - napraviti da radi u zmijaform
        // tl;dr dodaj bodove + efekt
        // POGLEDATI UPUTE!!
        // druge boje za drugu hranu

        public virtual (int, int) ActivateEffect(List<Unit> Snake, int score, int lives)
        {
            Unit rear = new Unit
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y,
            };
            Snake.Add(rear);
            return (score + Points, lives);
        }

        public virtual bool CheckTimer() { return true; }
    }
}
