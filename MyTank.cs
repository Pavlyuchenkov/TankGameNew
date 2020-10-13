using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameInterface
{
    class MyTank : ITank
    {
        private double ammu;
        public double Ammu {
            get { return ammu; }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    ammu = value;
                }
                else if (value > 10)
                {
                    ammu = 10;
                }
                else if (value < 0)
                {
                    ammu = 0;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private double armor;
        public double Armor {
            get { return armor; }
            set
            {
                if (value >= 0 && value <= 10)
                    armor = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private double damage;
        public double Damage {
            get { return damage; }
            set
            {
                if (value >= 1 && value <= 80)
                    damage = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double hp;
        public double Hp {
            get { return hp; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    hp = value;
                }
                else if (value > 100)
                {
                    hp = 100;
                }
                else if (value < 0)
                {
                    hp = 0;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public MyTank(double armor, double hp, double damage, double ammu)
        {
            Armor = armor;
            Hp = hp;
            Damage = damage;
            Ammu = ammu;
        }

        public void Impact(double enm_Damage)
        {
            Random randch = new Random();
            int chanceImp = randch.Next(1, 11);
            if (chanceImp <= 1) //вероятность 10%
            {
                Hp -= (enm_Damage * 1.2) / Armor;
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t----Критический урон!----");
            }
            else
            {
                Hp -= enm_Damage / Armor;
            }
        }

        public void BuyAmmu()
        {
            Ammu += 4;
        }

        public void Repair()
        {
            Hp += 10;
        }

        public void Shoot(ITank unit)
        {
            Random randch = new Random();
            int chanceSht = randch.Next(1, 11);
            if (chanceSht <= 2) //вероятность 20%
            {
                Ammu -= 1;
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t----Промах!----");
                Console.ResetColor();
            }
            else
            {
                Ammu -= 1;
                unit.Impact(Damage);
            }
        }

        public void StatInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Класс брони: {Armor}.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Здоровье: {Hp}.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Снаряды:{Ammu}.");
            Console.ResetColor();
        }
    }
}
