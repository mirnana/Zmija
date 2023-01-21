using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zmija
{
    internal class TimedFood : BasicFood
    {
        int Timer;

        public TimedFood() : base()
        {
            Timer = 3000;
        }

        public override bool CheckTimer()
        {
            if(Timer > 0)
            {
                Timer--;
                return true;
            }
            return false;
        }
    }
}
