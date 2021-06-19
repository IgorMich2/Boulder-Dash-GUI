using System;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Rock : Cell
    {
        public override char Value { get => 'o';  }
        public static int RocksDownGravity = 0;
        public override string path()
        {
            return "rock.jpg";
        }
        public static int CountRock()
        {
            int count = 0;

            for (int y = Field.frame.Count - 2; y >= 0; y--)
            {
                for (int x = Field.frame[y].Count - 1; x >= 0; x--)
                {
                    if (Field.frame[y][x].Value == new Rock().Value)
                    {
                        if (Field.frame[y + 1][x].Value == new Empty().Value)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        public static void MoveRock1()
        {
            for (int y = Field.frame.Count - 2; y >= 0; y--)
            {
                for (int x = Field.frame[y].Count - 1; x >= 0; x--)
                {
                    if (Field.frame[y][x].Value == new Rock().Value)
                    {
                        if (Field.frame[y + 1][x].Value == new Empty().Value)
                        {
                            Field.frame[y][x] = new Empty();
                            Field.frame[y + 1][x] = new Rock();
                            Output.Emptycoordinates.x = x * 20;
                            Output.Emptycoordinates.y = y * 20;
                            Output.switcherempty = true;
                            Output.Rockcoordinates.x = x * 20;
                            Output.Rockcoordinates.y = (y + 1) * 20;
                            Output.switcherrocks = true;
                            RocksDownGravity++;
                        }
                    }
                }
            }
        }

        public static void MoveRock2()
        {
            for (int y = 0; y < Field.frame.Count - 1; y++)
            {
                for (int x = 0; x <= Field.frame[y].Count - 1; x++)
                {
                    if (Field.frame[y][x].Value == new Rock().Value)
                    {
                        if (Field.frame[y + 1][x].Value == new Empty().Value)
                        {
                            Field.frame[y][x] = new Empty();
                            Field.frame[y + 1][x] = new Rock();
                            Output.Emptycoordinates.x = x * 20;
                            Output.Emptycoordinates.y = y * 20;
                            Output.switcherempty = true;
                            Output.Rockcoordinates.x = x * 20;
                            Output.Rockcoordinates.y = (y + 1) * 20;
                            Output.switcherrocks = true;
                            RocksDownGravity++;
                        }
                    }
                }
            }
        }
    }
}
