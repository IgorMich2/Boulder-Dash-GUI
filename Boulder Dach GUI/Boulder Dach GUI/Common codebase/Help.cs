using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Boulder_Dach_GUI
{
    class Help
    {
        static Random randomNumber = new Random();
        public static List<List<bool>> Visited = new List<List<bool>>();
        static List<(int y, int x, int distance)> BFSQuery = new List<(int y, int x, int distance)>();
        public static (int, int, int) point;

        public static int BFSRadar(int y, int x)
        {
            BFSQuery.Clear();

            if (GameField.GameStatus)
            {
                point = (y, x, 0);
                int distance = BFSRadarStep(point);
                return distance;
            }
            return 0;
        }

        public static void Update()
        {
            while (true)
            {
                if (GameField.GameStatus)
                {
                        (int x, int y) prev = (Hero.x, Hero.y);
                        int distance = BFSRadar(prev.y, prev.x);

                            if (Field.frame[prev.y - 1][prev.x].CanEnter() && BFSRadar(prev.y - 1, prev.x) == distance - 1)
                            {
                                Output.helpmessage = "Go up";
                            }
                            else if (Field.frame[prev.y + 1][prev.x].CanEnter() && BFSRadar(prev.y + 1, prev.x) == distance - 1)
                            {
                                Output.helpmessage = "Go down";
                            }
                            else if (Field.frame[prev.y][prev.x + 1].CanEnter() && BFSRadar(prev.y, prev.x + 1) == distance - 1)
                            {
                                Output.helpmessage = "Go right";
                            }
                            else if (Field.frame[prev.y][prev.x - 1].CanEnter() && BFSRadar(prev.y, prev.x - 1) == distance - 1)
                            {
                                Output.helpmessage = "Go left";
                            }
                    
                }
                Thread.Sleep(200);
            }

        }

        public static void AddToQuery(int dy, int dx)
        {
            int y = BFSQuery[0].y + dy;
            int x = BFSQuery[0].x + dx;
            int distance = BFSQuery[0].distance + 1;

            if (!Visited[y][x] && Field.frame[y][x].CanEnter())
            {
                BFSQuery.Add((y, x, distance));
                Visited[y][x] = true;
            }
        }

        public static int BFSRadarStep((int, int, int) point)
        {
            Visited.Clear();
            for (int i = 0; i < Field.frame.Count; i++)
            {
                List<bool> Temp = new List<bool>();
                for (int j = 0; j < Field.frame[0].Count; j++)
                {
                    Temp.Add(false);
                }
                Visited.Add(Temp);
            }

            BFSQuery.Add(point);
            while (BFSQuery.Count != 0)
            {
                if (Field.frame[BFSQuery[0].y][BFSQuery[0].x].Value == new Diamond().Value)
                {
                    return (BFSQuery[0].distance);
                }

                if (BFSQuery[0].y > 0 && BFSQuery[0].x > 0)
                {
                    AddToQuery(1, 0);
                    AddToQuery(0, 1);
                    AddToQuery(-1, 0);
                    AddToQuery(0, -1);
                }

                BFSQuery.RemoveAt(0);
            }

            return (1000);
        }

    }
}
