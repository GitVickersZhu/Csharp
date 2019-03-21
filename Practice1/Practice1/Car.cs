using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8En_tutorial
{
    public class Car
    {
        public string Brand { get; set; }
        public int MaxSpeed { get; set; }
        public override string ToString()
        {
            return Brand + ", Max speed: " + MaxSpeed + "km/h";
        }
    }
}
