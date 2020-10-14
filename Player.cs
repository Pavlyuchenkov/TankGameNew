using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameInterface
{
    class Player : IPlayer
    {
        private MyTank T34;
        private EnemyTank Tiger;
        private bool End;
        private static bool Move;
        public void MovePlayer()
        {
            GameLogic tank = new GameLogic(T34, Tiger, End, Move);
            Dictionary<ConsoleKey, Actions> command = new Dictionary<ConsoleKey, Actions>(3)
                {
                    {ConsoleKey.F, Actions.Shoot},
                    {ConsoleKey.R, Actions.Repair},
                    {ConsoleKey.B, Actions.Buy},
                    {ConsoleKey.E, Actions.Exit}

                };


            while (!GameLogic.End)
            {
                if (T34.Hp == 0)
                {
                    Console.Clear();
                    Console.WriteLine("you lose");
                    GameLogic.End = true;
                }
                else if (Tiger.Hp == 0)
                {
                    Console.Clear();
                    Console.WriteLine("you win");
                    GameLogic.End = true;
                }
                else
                {
                    Move = true;


                    #region статы
                    Console.Clear();
                    Console.WriteLine("Статы вашего танка: ");
                    T34.StatInfo();
                    Console.WriteLine("\nСтаты вражеского танка: ");
                    Tiger.StatInfo();
                    #endregion

                    Console.WriteLine("\nF - выстрел, R - ремонт, B - купить снаряды, E - выход.");
                    ConsoleKeyInfo button = Console.ReadKey(true);
                    if (!command.ContainsKey(button.Key))
                    {
                        Console.WriteLine("Ошибка. Выберет доступную команду!");
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    }

                    Actions selection = command[button.Key];
                    switch (selection)
                    {
                        case Actions.Shoot:
                            if (T34.Ammu != 0)
                            {
                                Console.WriteLine("\t***************************");
                                Console.WriteLine("\tЯ стреляю в вражеский танк!");
                                Console.WriteLine("\t***************************");
                                T34.Shoot(Tiger);
                            }
                            else
                            {
                                Console.WriteLine("\tБоекомплект пуст!");
                                System.Threading.Thread.Sleep(1000);
                                continue;
                            }
                            Move = false;
                            break;
                        case Actions.Repair:
                            if (T34.Hp != 100)
                            {
                                Console.WriteLine("\t***************************");
                                Console.WriteLine("\tЯ ремонтируюсь!");
                                Console.WriteLine("\t***************************");
                                T34.Repair();
                            }
                            else
                            {
                                Console.WriteLine("\tЗдоровье полное!");
                                System.Threading.Thread.Sleep(1000);
                                continue;

                            }
                            Move = false;
                            break;
                        case Actions.Buy:
                            if (T34.Ammu != 10)
                            {
                                Console.WriteLine("\t***************************");
                                Console.WriteLine("\tПополняю боекомплект!");
                                Console.WriteLine("\t***************************");
                                T34.BuyAmmu();
                            }
                            else
                            {
                                Console.WriteLine("\tБоекомплект полон!");
                                System.Threading.Thread.Sleep(1000);
                                continue;
                            }

                            Move = false;
                            break;
                        case Actions.Exit:
                            Console.Clear();
                            Console.WriteLine("\t\t\t\tВЫ ПОКИДАЕТЕ ПОЛЕ БОЯ! ТРУСЫ БУДУТ ОТДАНЫ ПОД ТРЕБУНАЛ!");
                            GameLogic.End = true;
                            break;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}