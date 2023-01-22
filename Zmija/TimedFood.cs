using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace Zmija
{
    /// <summary>
    /// Klasa nasljeđuje BasicFood i dodaje objekt Timer. Kada istekne 30 sekundi
    /// glavnoj klasi se javlja da je hrana istekla i da se treba maknuti s polja.
    /// </summary>
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
