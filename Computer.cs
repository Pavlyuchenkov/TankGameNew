using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameInterface
{
    class Computer : IComputer
    {
        private MyTank T34;
        private EnemyTank Tiger;
        private bool End;
        private static bool Move;

        public void MovePc()
        {
            GameLogic tank = new GameLogic(T34, Tiger, End, Move);
            var random = new Random();
            int option = random.Next(1, 3);
                switch (option)
                {
                    case 1:
                        if (Tiger.Ammu != 0)
                        {
                            Console.WriteLine("\r\t***************************");
                            Console.WriteLine("\tВражеский танк стреляет в меня!");
                            Console.WriteLine("\t***************************");
                            Tiger.Shoot(T34);
                        }
                        else
                        {
                            Console.WriteLine("\t***************************");
                            Console.WriteLine("\tВражеский танк пополняет боекомплект!");
                            Console.WriteLine("\t***************************");
                            Tiger.BuyAmmu();
                        }
                        break;
                    case 2:
                        if (Tiger.Hp != 100)
                        {
                            Console.WriteLine("\t***************************");
                            Console.WriteLine("\tВражеский танк ремонтируется!");
                            Console.WriteLine("\t***************************");
                            Tiger.Repair();
                        }
                        else
                        {
                            if (Tiger.Ammu != 0)
                            {
                                Console.WriteLine("\t***************************");
                                Console.WriteLine("\tВражеский танк стреляет в меня!");
                                Console.WriteLine("\t***************************");
                                Tiger.Shoot(T34);
                            }
                            else
                            {
                                Console.WriteLine("\t***************************");
                                Console.WriteLine("\tВражеский танк пополняет боекомплект!");
                                Console.WriteLine("\t***************************");
                                Tiger.BuyAmmu();
                            }
                        }

                        break;
                    case 3:
                        if (Tiger.Ammu != 10)
                        {
                            Console.WriteLine("\t***************************");
                            Console.WriteLine("\tКажется вражеский танк поплняет боекомплект!");
                            Console.WriteLine("\t***************************");
                            T34.BuyAmmu();
                        }
                        else
                        {

                        }
                        break;
                }
                System.Threading.Thread.Sleep(1000);
            

        }
    }
}
