﻿using System;
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

        public override (int, int) ActivateEffect(List<Unit> Snake, int score, int lives)
        {
            //change speed (return?)
            return (score + Points, lives);
        }
    }
}
