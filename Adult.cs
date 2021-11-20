using System;
namespace Halloween
{
    class Adult : Human
    {
        public Adult(string name) : base(name)
        {
            Life = 0.5f;
            Blood = 0.5f;
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
