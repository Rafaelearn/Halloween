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
        public override void Display()
        {
            Console.WriteLine($"Kinder {Name}");
            if (Life > 2)
            {
                Console.WriteLine($"Immortal");
            }
            else
            {
                Console.WriteLine($"Life: {Life}");
            }
            Console.WriteLine($"Blood: {Blood}");
            Console.WriteLine($"Candies: {Candies}");
        }
    }
}