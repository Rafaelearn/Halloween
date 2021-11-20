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
            byte probabilityKill;
            switch (monstor)
            {
                case TypeMonstor.Vampire:
                    probabilityKill = 65;
                    break;
                case TypeMonstor.Witch:
                    probabilityKill = 90;
                    break;
                case TypeMonstor.Werewolf:
                    probabilityKill = 80;
                    break;
                case TypeMonstor.Ghost:
                    probabilityKill = 70;
                    break;
                case TypeMonstor.Daemon:
                    probabilityKill = 40;
                    break;
                case TypeMonstor.Zombie:
                    probabilityKill = 95;
                    break;
                case TypeMonstor.BlackWidow:
                    probabilityKill = 55;
                    break;
                default:
                    probabilityKill = 100;
                    break;
            }
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
