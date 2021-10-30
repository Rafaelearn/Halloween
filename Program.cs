using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halloween
{
    
    #region Другая реализация
    /*
     Как вариант построить дерево наследников
     
     */
    //class Vampire:Monstor
    //{
    //    public TypeMonstor TypeMonstor { get; } = TypeMonstor.Vampire;
    //}
    //class Witch:Monstor
    //{
    //    public TypeMonstor TypeMonstor { get; } = TypeMonstor.Witch;
    //}
    //class Werewolf:Monstor
    //{
    //    public TypeMonstor TypeMonstor { get; } = TypeMonstor.Werewolf;
    //}
    //class Ghost : Monstor
    //{
    //    public TypeMonstor TypeMonstor { get; } = TypeMonstor.Ghost;
    //}
    //class Daemon : Monstor
    //{
    //    public TypeMonstor TypeMonstor { get; } = TypeMonstor.Daemon;
    //}
    //class Zombie : Monstor
    //{
    //    public TypeMonstor TypeMonstor { get; } = TypeMonstor.Zombie;
    //}
    //class BlackWidow : Monstor
    //{
    //    public TypeMonstor TypeMonstor { get; } = TypeMonstor.BlackWidow;
    //}
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            WriteFromFileToQueqeMonstor(out Queue<Monstor> monstors);
            WriteFromFileToListHuman(out List<Human> humen);
            List<Monstor> monstorsDead = new List<Monstor>();
            List<Monstor> monstorsEat = new List<Monstor>();
            while (monstors.Count != 0)
            {
                Monstor monstor = monstors.Dequeue();

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
                        throw new FormatException("Непраильный формат");
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
