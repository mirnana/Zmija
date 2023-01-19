using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmija
{
    /// <summary>
    /// predstavlja jedno polje na ploči
    /// </summary>
    internal class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Unit()
        {
            X = 0;
            Y = 0;
        }
    }
}
