using System;
using System.IO;
using System.Collections.Generic;

namespace Halloween
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Monstor> monstors = new Queue<Monstor>();
            monstors.Enqueue(new Monstor( "Vampire", TypeMonstor.Vampire));
            monstors.Enqueue(new Monstor("Ghost", TypeMonstor.Ghost));
            monstors.Enqueue(new Monstor("Werewolf", TypeMonstor.Werewolf));
            monstors.Enqueue(new Monstor("Daemon", TypeMonstor.Daemon));
            monstors.Enqueue(new Monstor("BlackWidow", TypeMonstor.BlackWidow));
            monstors.Enqueue(new Monstor("Witch", TypeMonstor.Witch));
            monstors.Enqueue(new Monstor("Zombie", TypeMonstor.Zombie));

            List<Human> humen = new List<Human>();
            humen.Add(new Kinder("Петя"));
            humen.Add(new Kinder("Вася"));
            humen.Add(new Kinder("Маша"));
            humen.Add(new Adult("Игорь"));
            humen.Add(new Witcher("Анастасия"));
            humen.Add(new Adult("Диана"));
            humen.Add(new Witcher("Честер"));
            humen.Add(new Adult("Морис"));
            humen.Add(new Adult("Женя"));
            humen.Add(new Witcher("Розалин"));
            humen.Add(new Adult("Дюшес"));
            humen.Add(new Witcher("Люмень"));
            List<Monstor> monstorsDead = new List<Monstor>();
            List<Monstor> monstorsEat = new List<Monstor>();
            Stack<Human> humenDead = new Stack<Human>();
            int i = 0;
            while (monstors.Count != 0 && humen.Count != 0)
            {
                Monstor monstor = monstors.Dequeue();
                bool flag = true;
                while (flag)
                {
                    int indHum = i % humen.Count;
                    monstor.MeetStranger(humen[indHum]);
                    if (monstor.Dead)
                    {
                        monstorsDead.Add(monstor);
                        flag = false;
                    }
                    if (!monstor.ExistingHunger)
                    {
                        monstorsEat.Add(monstor);
                        flag = false;
                    }
                    if (humen[indHum].Dead)
                    {
                        humenDead.Push(humen[indHum]);
                        humen.RemoveAt(indHum);
                    }
                    i++;
                }
            }
            Console.WriteLine("Монстры: ");
            Console.WriteLine("===========================МЕРТВЫЕ=================================================");
            foreach (var item in monstorsDead)
            {
                item.Display();
            }
            Console.WriteLine("===========================ВЫЖИВШИЕ================================================");
            foreach (var item in monstorsEat)
            {
                item.Display();
            }
            Console.WriteLine("\n\n\nЛюди: ");
            Console.WriteLine("===========================МЕРТВЫЕ=================================================");
            foreach (var item in humenDead)
            {
                item.Display();
            }
            Console.WriteLine("===========================ВЫЖИВШИЕ================================================");
            foreach (var item in humen)
            {
                item.Display();
            }
            Console.ReadKey();
        }
    }
}
