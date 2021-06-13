using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Gravity
    {
        public static void GravityFunction(Form Boulder)
        {
            while (true)
            {
                try
                {
                    if (GameField.GameStatus == true)
                    {
                        if (Rock.CountRock() == 1)
                        {
                            Rock.MoveRock1(Boulder);
                        }
                        else if (Rock.CountRock() > 1)
                        {

                            Rock.MoveRock1(Boulder);
                            for (int i = 0; i < 5; i++)
                                Rock.MoveRock2(Boulder);

                        }
                    }
                    Thread.Sleep(200);
                }
                catch { }
            }
        }
    }
}
