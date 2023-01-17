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
            Points = 20;
            Color = Brushes.Red;
        }

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

        public virtual bool CheckTimer() { return true; }
    }
}
