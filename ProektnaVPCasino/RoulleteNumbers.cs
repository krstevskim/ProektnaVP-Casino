using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektnaVPCasino
{
    public class RoulleteNumbers
    {
        public int number { get; set; }
        public Color color { get; set; }
        public int bet { get; set; }
        public RoulleteNumbers(int number,Color color)
        {
            this.number = number;
            this.color = color;
            bet = 0;
        }
    }
}
