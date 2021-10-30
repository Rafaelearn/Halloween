﻿using System;

namespace Halloween
{
    enum TypeMonstor
    {
        Vampire = 0,
        Witch,
        Werewolf,
        Ghost,
        Daemon,
        Zombie,
        BlackWidow
    }
    class Monstor
    {
        Random random = new Random();
        public static uint CountCycle { get; private set; } = 0;
        public uint Lifetime { get; set; }
        public bool Dead { get; private set; } = false;
        public TypeMonstor Type { get; private set; }
        public string Name { get; private set; }
        public double UnitHunger { get; set; } // Ед. голода
        public bool ExistingHunger { get; private set; } = true;
        public Monstor(string name, TypeMonstor type)
        {
            Name = name;
            Type = type;
            UnitHunger = SetMonstorUnitHunger(Type);
            Lifetime = SetMonstorCycle(Type);
        }
        public void MeetStranger(ref Human human)
        {

            if (human is Witcher)
            {
                Witcher witcher = (Witcher)human;
                if (witcher.CheckKillMonstor(Type))
                {
                    Dead = true;
                }
                return;
            }
            else
            {
                if (random.Next(100) < 31)
                {
                    GetGiftFromMonstor(Type, ref human);
                }
                else
                {
                    EatHuman(Type, ref human);
                }
            }
            CountCycle++;
        }
        private void EatHuman(TypeMonstor type, ref Human human)
        {
            switch (type)
            {
                   //Кровь
                case TypeMonstor.Vampire:
                case TypeMonstor.Witch:
                case TypeMonstor.Zombie:
                    if (UnitHunger == human.Blood)
                    {
                        UnitHunger = 0;
                        human.Blood = 0;
                        human.Dead = true;
                        ExistingHunger = false;

                    }
                    if (UnitHunger < human.Blood)
                    {
                        human.Blood -= UnitHunger;
                        UnitHunger = 0;
                        ExistingHunger = false;
                    }
                    else
                    {
                        UnitHunger -= human.Blood;
                        human.Blood = 0;
                        human.Dead = true;
                    }
                    return;
                    //Жизнь
                case TypeMonstor.Werewolf:
                case TypeMonstor.Daemon:
                    if (human.Life == double.MaxValue)
                    {
                        UnitHunger = 0;
                        ExistingHunger = false;
                    }
                    else
                    {
                        UnitHunger -= human.Life;
                        human.Life = 0;
                        ExistingHunger = false;
                        human.Dead = true;
                    }
                    return;
                    //Конфеты
                case TypeMonstor.BlackWidow:
                case TypeMonstor.Ghost:

                    if (UnitHunger <= human.Candies)
                    {
                        human.Candies -= (uint)UnitHunger;
                        UnitHunger = 0;
                        ExistingHunger = false;
                    }
                    else
                    {
                        UnitHunger -= human.Candies;
                        human.Candies = 0;
                    }
                    return;
                default:
                    return;
            }
            
        }
        private void GetGiftFromMonstor(TypeMonstor type, ref Human human)
        {
            switch (type)
            {
                case TypeMonstor.Vampire:
                    human.Life = double.MaxValue;
                    break;
                case TypeMonstor.Witch:
                    human.Candies += 5;
                    break;
                case TypeMonstor.Werewolf:
                    break;
                case TypeMonstor.Ghost:
                    human.Candies += 5;
                    break;
                case TypeMonstor.Daemon:
                    human.Blood += 1;
                    break;
                case TypeMonstor.Zombie:
                    break;
                case TypeMonstor.BlackWidow:
                    human.Blood += 1.5f;
                    break;
            }
        }
        private double SetMonstorUnitHunger(TypeMonstor type)
        {
            switch (type)
            {
                case TypeMonstor.Vampire:
                    return 2.0;
                case TypeMonstor.Witch:
                    return 1.0;
                case TypeMonstor.Werewolf:
                    return 1.0;
                case TypeMonstor.Ghost:
                    return 5.0;
                case TypeMonstor.Daemon:
                    return 1.0;
                case TypeMonstor.Zombie:
                    return 1.5;
                case TypeMonstor.BlackWidow:
                    return 3.0;
                default:
                    return 0;
            }
        }
        private uint SetMonstorCycle(TypeMonstor type)
        {
            switch (type)
            {
                case TypeMonstor.Vampire:
                    return 10;
                case TypeMonstor.Witch:
                    return 5;
                case TypeMonstor.Werewolf:
                    return 5;
                case TypeMonstor.Ghost:
                    return 5;
                case TypeMonstor.Daemon:
                    return 10;
                case TypeMonstor.Zombie:
                    return 5;
                case TypeMonstor.BlackWidow:
                    return 10;
                default:
                    return 0;
            }
        }
    }
}
