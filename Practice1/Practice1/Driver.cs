using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8En_tutorial
{
    public class Driver
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return Name + " " + LastName + ", " + Age;
        }
    }
}
