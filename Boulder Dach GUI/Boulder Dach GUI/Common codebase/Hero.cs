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
        public static int Teleportation = 0;
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

        public static void MoveHero(string keyInfo)
        {
            if ("W" == keyInfo || "Up" == keyInfo)
            {
                Hero.GoHero(Hero.y - 1, Hero.x);
            }
            else if ("S" == keyInfo || "Down" == keyInfo)
            {
                Hero.GoHero(Hero.y + 1, Hero.x);
            }
            else if ("A" == keyInfo || "Left" == keyInfo)
            {
                Hero.GoHero(Hero.y, Hero.x - 1);
            }
            else if ("D" == keyInfo || "Right" == keyInfo)
            {
                Hero.GoHero(Hero.y, Hero.x + 1);
            }
            else if ("E" == keyInfo)
            {
                Hero.GoDig(Hero.y, Hero.x + 1);
            }
            else if ("Q" == keyInfo)
            {
                Hero.GoDig(Hero.y, Hero.x - 1);
            }
            else if ("L" == keyInfo)
            {
                GameField.score = GameField.maxpoint;
                GameField.Defeat();
            }
            else if ("K" == keyInfo)
            {
                GameField.Win();
            }
            else if ("F" == keyInfo)
            {
                Levels.SaveToFile();
            }
            else if ("T" == keyInfo)
            {
                Music.waveOut.Volume = Convert.ToSingle(Math.Min(Music.waveOut.Volume + Convert.ToSingle(0.1), 1.0));
            }
            else if ("G" == keyInfo)
            {
                Music.waveOut.Volume = Convert.ToSingle(Math.Max(Music.waveOut.Volume - Convert.ToSingle(0.1), 0));
            }
            else if ("N" == keyInfo)
            {
                Music.waveOut.Stop();
                Thread music = new Thread(Music.MusicFunction);
                music.Priority = ThreadPriority.Normal;
                music.Start();
            }
            else if ("M" == keyInfo)
            {
                Music.waveOut.Stop();
            }
            else if ("U" == keyInfo)
            {
                Output.switchupdate = true;
            }
        }

    public static void GoHero(int y, int x)
        {
            (int x, int y) prev = (Hero.x, Hero.y);

            if (x >= 0 && y >= 0 && y < Field.frame.Count && x < Field.frame[0].Count && (Field.frame[y][x].CanEnter() == true))
            {
                bool isdiamond = false;
                bool israrediamond = false;
                if (Field.frame[y][x].Value == new Diamond().Value)
                {
                    isdiamond = true;
                }
                else if (Field.frame[y][x].Value == new RareDiamond().Value)
                {
                    israrediamond = true;
                }
                Field.frame[Hero.y][Hero.x] = new Empty();
                Field.frame[y][x] = new Hero();
                Output.Emptycoordinates.x = Hero.x * 20;
                Output.Emptycoordinates.y = Hero.y * 20;
                Output.switcherempty = true;
                Output.Herocoordinates.x = x * 20;
                Output.Herocoordinates.y = y * 20;
                Output.switcherhero = true;
                Hero.x = x;
                Hero.y = y;
                if (isdiamond)
                {
                    GameField.AddScores(100);
                }
                else if (israrediamond)
                {
                    GameField.AddScores(500);
                }
                if (2 * x - prev.x >= 0 && 2 * y - prev.y >= 0 && 2 * y - prev.y < Field.frame.Count && 2 * x - prev.x < Field.frame[0].Count && Field.frame[2 * y - prev.y][2 * x - prev.x].Value == new Portal().Value)
                {
                    FindHero();
                    Thread.Sleep(110);
                    Output.Emptycoordinates.x = Hero.x * 20;
                    Output.Emptycoordinates.y = Hero.y * 20;
                    Output.switcherempty = true;
                    Thread.Sleep(110);
                    Field.frame[2 * y - prev.y][2 * x - prev.x].Teleportation(2 * y - prev.y, 2 * x - prev.x);
                    Teleportation++;
                }
            }
            else if (x >= 0 && y >= 0 && y < Field.frame.Count && x < Field.frame[0].Count && x + (x - Hero.x) > 0 && x + (x - Hero.x) < Field.frame[0].Count && Math.Abs(x - Hero.x) == 1 && Field.frame[y][x + (x - Hero.x)].Value == new Empty().Value && Field.frame[y][x].Value == new Rock().Value)
            {
                Field.frame[y][Hero.x] = new Empty();
                Field.frame[y][x] = new Hero();
                Field.frame[y][x + (x - Hero.x)] = new Rock();
                Output.Emptycoordinates.x = Hero.x * 20;
                Output.Emptycoordinates.y = Hero.y * 20;
                Output.switcherempty = true;
                Output.Herocoordinates.x = x * 20;
                Output.Herocoordinates.y = y * 20;
                Output.switcherhero = true;
                Output.Rockcoordinates.x = (x + (x - Hero.x)) * 20;
                Output.Rockcoordinates.y = y * 20;
                Output.switcherrocks = true;
                Hero.x = x;
                Hero.y = y;
                RocksMoveByHero++;
            }
            steps++;
            
        }
        public static void GoDig(int y, int x)
        {
            if (Field.frame[y][x].Value == new Sand().Value)
            {
                Field.frame[y][x] = new Empty();
                Output.Emptycoordinates.x = x * 20;
                Output.Emptycoordinates.y = y * 20;
                Output.switcherempty = true;
                digs++;
            }
        }
    }
}
