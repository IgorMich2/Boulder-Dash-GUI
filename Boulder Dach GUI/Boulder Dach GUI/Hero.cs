using System;
using NAudio.Wave;
using System.Threading;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Hero : Cell
    {
        public static int lives = 500;
        public static int x;
        public static int y;
        public static int steps=0;
        public static int digs=0;
        public static string value = "I";
        public static int RocksMoveByHero = 0;

        public override string path()
        {
            return "hero.jpg";
        }

        public override char Value { get => 'I'; }
        public override bool CanEnter()
        {
            return true;
        }

        public static void FindHero()
        {
            for (int y = 0; y < Field.frame.Count; y++)
            {
                for (int x = 0; x < Field.frame[y].Count; x++)
                {
                    if (Field.frame[y][x].Value == new Hero().Value)
                    {
                        Hero.x = x;
                        Hero.y = y;
                        y = 10000;
                        break;
                    }
                }
            }
        }

        public static void MoveHero(KeyEventArgs keyInfo, Form Boulder)
        {
            if (Keys.W == keyInfo.KeyCode || Keys.Up == keyInfo.KeyCode)
            {
                Hero.GoHero(Hero.y - 1, Hero.x, Boulder);
            }
            else if (Keys.S == keyInfo.KeyCode || Keys.Down == keyInfo.KeyCode)
            {
                Hero.GoHero(Hero.y + 1, Hero.x, Boulder);
            }
            else if (Keys.A == keyInfo.KeyCode || Keys.Left == keyInfo.KeyCode)
            {
                Hero.GoHero(Hero.y, Hero.x-1, Boulder);
            }
            else if (Keys.D == keyInfo.KeyCode || Keys.Right == keyInfo.KeyCode)
            {
                Hero.GoHero(Hero.y, Hero.x + 1, Boulder);
            }
            else if (Keys.E == keyInfo.KeyCode)
            {
                Hero.GoDig(Hero.y, Hero.x+1, Boulder);
            }
            else if (Keys.Q == keyInfo.KeyCode)
            {
                Hero.GoDig(Hero.y, Hero.x-1, Boulder);
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

            //Logic.Coordinates(Boulder);
            //Logic.Steps(Boulder);


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
                Logic.PrintCell(Hero.x, Hero.y, new Empty(), Boulder);
                Logic.PrintCell(x, y, new Hero(), Boulder); 
                Hero.x = x;
                Hero.y = y;
                if (isdiamond)
                {
                    GameField.AddScores();
                }
            }
            else if (x >= 0 && y >= 0 && y < Field.frame.Count && x < Field.frame[0].Count && x + (x - Hero.x) > 0 && x + (x - Hero.x) < Field.frame[0].Count && Math.Abs(x - Hero.x) == 1 && Field.frame[y][x + (x-Hero.x)].Value == new Empty().Value && Field.frame[y][x].Value == new Rock().Value)
            {
                Field.frame[y][Hero.x] = new Empty();
                Field.frame[y][x] = new Hero();
                Field.frame[y][x + (x-Hero.x)] = new Rock();
                Logic.PrintCell(Hero.x, Hero.y, new Empty(), Boulder);
                Logic.PrintCell(x, y, new Hero(), Boulder);
                Logic.PrintCell(x + (x - Hero.x), y, new Rock(), Boulder);
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
                Logic.PrintCell(x, y, new Empty(), Boulder);
                digs++;
            }
        }
    }
}
