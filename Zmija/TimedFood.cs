using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace Zmija
{
    internal class TimedFood : BasicFood
    {
        Timer timer;
        bool timerActive;

        public TimedFood() : base()
        {
            timer = new Timer(30000);
            timer.Elapsed += TimerElapsed;
            timer.Start();
            timerActive = true;
        }

        public override bool CheckTimer()
        {
            return timerActive;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            timerActive = false;
            timer.Stop();
        }
    }
}
