using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halloween
{
    class Kinder : Human
    {
        public Kinder(string name):base(name)
        {
            Life = 0.5;
            Blood = 0.5;
            Candies = 1;
        }
    }
}