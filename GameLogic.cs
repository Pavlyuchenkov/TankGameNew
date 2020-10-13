using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameInterface
{
    class GameLogic
    {
        public static bool end;


        internal static void StartApplicationLogic()
        {

            Player movePlayer = new Player();
            Computer movePc = new Computer();

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
    }
}
