using System;
namespace Halloween
{
    class Witcher : Human
    {
        public Witcher(string name) : base(name)
        {

        }
        public bool CheckKillMonstor(TypeMonstor monstor)
        {
            int probabilityKill = 50; // Вероятность убийства монстра 
            if (probabilityKill > random.Next(0, 100))
            {
                return true;
            }
            Dead = true;
            return false;
        }
        public override void Display()
        {
            Console.WriteLine($"Witcher {Name}");
        }
    }
}
