using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameInterface
{
    class GameLogic
    {
        public static bool end;
        public MyTank t34;
        public EnemyTank tiger;


        internal static void StartApplicationLogic()
        {

            Player movePlayer = new Player(tiger);
            Computer movePc = new Computer(t34);

            while (!end)
            {
                if(Player.move == false)
                {
                    movePlayer.MovePlayer();
                }

                else
                {
                    movePc.MovePc();
                }
                
            }
        }


        //public MyTank(double armor, double hp, double damage, double ammu)
        //{
        //    Armor = armor;
        //    Hp = hp;
        //    Damage = damage;
        //    Ammu = ammu;
        //}
    }
}
