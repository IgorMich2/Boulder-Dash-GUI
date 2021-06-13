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
                if (GameField.GameStatus)
                {
                    if (Rock.CountRock() == 1)
                    {
                        MovingRocks.MoveRock1(Boulder);
                    }
                    else if (Rock.CountRock() > 1)
                    {

                        MovingRocks.MoveRock1(Boulder);
                        for (int i = 0; i < 5; i++)
                            MovingRocks.MoveRock2(Boulder);

                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}
