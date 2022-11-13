using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Interval
    {
        public Queue<Patient> pt = new Queue<Patient>();
        public Interval Next { get; set; }
    }
}
