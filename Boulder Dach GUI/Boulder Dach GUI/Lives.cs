using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Lives
    {
        public static void LivesFunction(Form Boulder)
        {
            while (true)
            {
                try
                {
                    if (Hero.y > 0 && Hero.lives > 0 && GameField.GameStatus == true)
                    {
                        if (Field.frame[Hero.y - 1][Hero.x].Value == new Rock().Value)
                        {
                            Hero.lives = Hero.lives - 1;
                            if (Hero.lives <= 0)
                            {
                                GameField.Defeat();
                            }
                        }
                    }
                }
                catch { }
                Thread.Sleep(200);
            }
        }
    }
}
