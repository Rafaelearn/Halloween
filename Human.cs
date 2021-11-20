using System;
namespace Halloween
{
    abstract class Human
    {
        protected Random random = new Random();
        public double Life { get; set; } = 0;
        public double Blood { get; set; } = 0;
        public uint Candies { get; set; } = 0;
        public bool Dead { get; set; } = false;
        public string Name { get; set; }
        public Human(string name)
        {
            Name = name;
        }
        public Human()
        {

        }

        abstract public void Display();
    }
}
