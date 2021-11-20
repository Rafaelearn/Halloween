using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halloween
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFromFileToQueqeMonstor(out Queue<Monstor> monstors);
            WriteFromFileToListHuman(out List<Human> humen);
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
        static void WriteFromFileToQueqeMonstor(out Queue<Monstor> monstors)
        {
            monstors = new Queue<Monstor>();
            using (StreamReader fileTextRead = new StreamReader(@"..\..\Resources\ListMonstor.txt"))
            {
                string stringfromfile;
                while ((stringfromfile = fileTextRead.ReadLine()) != null)
                {
                    string[] date = stringfromfile.Split();
                    if (!int.TryParse(date[0], out int type))
                    {
                        throw new FormatException("Неправильный формат");
                    }
                    monstors.Enqueue(new Monstor(date[1], (TypeMonstor)type));
                }
            }
        }
        static void WriteFromFileToListHuman(out List<Human> humen)
        {
            humen = new List<Human>();
            using (StreamReader fileTextRead = new StreamReader(@"..\..\Resources\ListHuman.txt"))
            {
                string stringfromfile;
                while ((stringfromfile = fileTextRead.ReadLine()) != null)
                {
                    string[] date = stringfromfile.Split();
                    if (date[0].Equals("W"))
                    {
                        humen.Add(new Witcher(date[1]));
                    }
                    if (date[0].Equals("A"))
                    {
                        humen.Add(new Adult(date[1]));
                    }
                    if (date[0].Equals("K"))
                    {
                        humen.Add(new Kinder(date[1]));
                    }
                }
            }
        }
    }
}
