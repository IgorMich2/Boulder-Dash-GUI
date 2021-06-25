using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Gravity : Rock
    {
        public static void GravityFunction() 
        {
            while (true)
            {
                if (GameField.GameStatus)
                {
                    if (Rock.CountRock() == 1)
                    {
                        MoveRock1();
                    }
                    else if (Rock.CountRock() > 1)
                    {

                        MoveRock1();
                        for (int i = 0; i < 5; i++)
                            MoveRock2();
                    }
                }
                Thread.Sleep(200);
            }
        }   
    }
}
