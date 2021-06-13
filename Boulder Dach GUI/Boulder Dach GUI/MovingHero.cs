using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using NAudio.Wave;
using System.Threading;
using System.Windows.Forms;

namespace Boulder_Dach_GUI
{
    class MovingHero : Hero
    {
        public static void MoveHero(KeyEventArgs keyInfo, Form Boulder)
        {
            if (Keys.W == keyInfo.KeyCode || Keys.Up == keyInfo.KeyCode)
            {
                MovingHero.GoHero(Hero.y - 1, Hero.x, Boulder);
            }
            else if (Keys.S == keyInfo.KeyCode || Keys.Down == keyInfo.KeyCode)
            {
                MovingHero.GoHero(Hero.y + 1, Hero.x, Boulder);
            }
            else if (Keys.A == keyInfo.KeyCode || Keys.Left == keyInfo.KeyCode)
            {
                MovingHero.GoHero(Hero.y, Hero.x - 1, Boulder);
            }
            else if (Keys.D == keyInfo.KeyCode || Keys.Right == keyInfo.KeyCode)
            {
                MovingHero.GoHero(Hero.y, Hero.x + 1, Boulder);
            }
            else if (Keys.E == keyInfo.KeyCode)
            {
                MovingHero.GoDig(Hero.y, Hero.x + 1, Boulder);
            }
            else if (Keys.Q == keyInfo.KeyCode)
            {
                MovingHero.GoDig(Hero.y, Hero.x - 1, Boulder);
            }
            else if (Keys.L == keyInfo.KeyCode)
            {
                GameField.score = GameField.maxpoint;
                GameField.Defeat();
            }
            else if (Keys.K == keyInfo.KeyCode)
            {
                GameField.Win();
            }
            else if (Keys.F == keyInfo.KeyCode)
            {
                Levels.SaveToFile();
            }
            else if (Keys.T == keyInfo.KeyCode)
            {
                Music.waveOut.Volume = Convert.ToSingle(Math.Min(Music.waveOut.Volume + Convert.ToSingle(0.1), 1.0));
            }
            else if (Keys.G == keyInfo.KeyCode)
            {
                Music.waveOut.Volume = Convert.ToSingle(Math.Max(Music.waveOut.Volume - Convert.ToSingle(0.1), 0));
            }
            else if (Keys.N == keyInfo.KeyCode)
            {
                Music.waveOut.Stop();
                Thread music = new Thread(Music.MusicFunction);
                music.Priority = ThreadPriority.Normal;
                music.Start();
            }
        }

        public static void GoHero(int y, int x, Form Boulder)
        {
            if (x >= 0 && y >= 0 && y < Field.frame.Count && x < Field.frame[0].Count && (Field.frame[y][x].CanEnter() == true))
            {
                bool isdiamond = false;
                if (Field.frame[y][x].Value == new Diamond().Value)
                {
                    isdiamond = true;
                }
                Field.frame[Hero.y][Hero.x] = new Empty();
                Field.frame[y][x] = new Hero();
                Output.PrintCell(Hero.x, Hero.y, new Empty(), Boulder);
                Output.PrintCell(x, y, new Hero(), Boulder);
                Hero.x = x;
                Hero.y = y;
                if (isdiamond)
                {
                    GameField.AddScores();
                }
            }
            else if (x >= 0 && y >= 0 && y < Field.frame.Count && x < Field.frame[0].Count && x + (x - Hero.x) > 0 && x + (x - Hero.x) < Field.frame[0].Count && Math.Abs(x - Hero.x) == 1 && Field.frame[y][x + (x - Hero.x)].Value == new Empty().Value && Field.frame[y][x].Value == new Rock().Value)
            {
                Field.frame[y][Hero.x] = new Empty();
                Field.frame[y][x] = new Hero();
                Field.frame[y][x + (x - Hero.x)] = new Rock();
                Output.PrintCell(Hero.x, Hero.y, new Empty(), Boulder);
                Output.PrintCell(x, y, new Hero(), Boulder);
                Output.PrintCell(x + (x - Hero.x), y, new Rock(), Boulder);
                Hero.x = x;
                Hero.y = y;
                RocksMoveByHero++;
            }
            steps++;
        }
        public static void GoDig(int y, int x, Form Boulder)
        {
            if (Field.frame[y][x].Value == new Sand().Value)
            {
                Field.frame[y][x] = new Empty();
                Output.PrintCell(x, y, new Empty(), Boulder);
                digs++;
            }
        }
    }
}
