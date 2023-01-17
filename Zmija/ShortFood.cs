using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    internal class ShortFood : BasicFood
    {
        public ShortFood() : base()
        {
            Color = Brushes.Orange;
        }

        public override (int, int, int, bool) ActivateEffect(List<Unit> Snake, int score, int lives, int timer)
        {
            //change speed (return?)
             Snake.RemoveAt(Snake.Count - 1);
             Snake.RemoveAt(Snake.Count - 1);
             Snake.RemoveAt(Snake.Count - 1);
             Snake.RemoveAt(Snake.Count - 1);


            return (score + Points, lives, timer, false);
        }
    }
}
