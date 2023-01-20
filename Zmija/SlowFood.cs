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
        public SlowFood() : base()
        {
            Color = Brushes.Yellow;
        }

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
