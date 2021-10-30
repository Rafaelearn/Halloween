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
        private string name;

        public string Name
        {
            get { return name; }
            private set { Name = value.Trim(); }
        }
        public Human(string name)
        {
            Name = name;
        }
        public Human()
        {

        }
    }
}
