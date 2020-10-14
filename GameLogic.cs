using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameInterface
{
    class GameLogic
    {
        public static bool End;
        public static bool Move;
        MyTank T34 = new MyTank(5, 10, 80, 6);
        EnemyTank Tiger = new EnemyTank(5, 100, 80, 4);
        

        public GameLogic(MyTank t34, EnemyTank tiger, bool end, bool move)
        {
            T34 = t34;
            Tiger = tiger;
            End = end;
            Move = move;
        }
        internal static void StartApplicationLogic()
        {

            Player movePlayer = new Player();
            Computer movePc = new Computer();

            while (!End)
            {
                if(Move == false)
                {
                    movePlayer.MovePlayer();
                }

                else
                {
                    movePc.MovePc();
                }
                
            }
        }
    }
}
