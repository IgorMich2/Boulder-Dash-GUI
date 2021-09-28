using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Boulder_Dach_GUI
{
    class Enemy : Cell
    {
        static Random randomNumber = new Random();
        public static (int, int, int) point;
        public static (int x, int y) coordinates;
        public static bool isenemy = false;
        public static Cell prev = new Sand();
        public static List<List<bool>> Visited = new List<List<bool>>();
        static List<(int y, int x, int distance)> BFSQuery = new List<(int y, int x, int distance)>();

        public override string Path()
        {
            return "enemy.jpg";
        }

        public override char Value { get => '='; }
        public override bool CanEnter()
        {
            return true;
        }

        public static void FindEnemy()
        {
            for (int y = 0; y < Field.frame.Count; y++)
            {
                for (int x = 0; x < Field.frame[y].Count; x++)
                {
                    if (Field.frame[y][x] is Enemy)
                    {
                        Enemy.coordinates = (x, y);
                        y = 10000;
                        isenemy = true;
                        break;
                    }
                }
            }
        }

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

        public static void GoEnemy(int dx, int dy)
        {
            (int x, int y) prevcord = Enemy.coordinates;

            Enemy.coordinates = (Enemy.coordinates.x + dx, Enemy.coordinates.y + dy);

            Cell newvalue = Enemy.prev;
            Enemy.prev = Field.frame[coordinates.y][coordinates.x];

            Field.frame[coordinates.y][coordinates.x] = new Enemy();
            Field.frame[prevcord.y][prevcord.x] = newvalue;

            for (int i = 0; i < 3; i++)
            {
                Output.value = newvalue;
                Output.Valuecoordinates.x = prevcord.x * 20;
                Output.Valuecoordinates.y = prevcord.y * 20;
                Output.switchervalue = true;
                Thread.Sleep(60);
            }
            Output.Enemycoordinates.x = coordinates.x * 20;
            Output.Enemycoordinates.y = coordinates.y * 20;
            Output.switcherenemy = true;

            for (int i = 0; i < 3; i++)
            {
                Output.value = newvalue;
                Output.Valuecoordinates.x = prevcord.x * 20;
                Output.Valuecoordinates.y = prevcord.y * 20;
                Output.switchervalue = true;
                Thread.Sleep(60);
            }
        }


        public static void MoveEnemy()
        {
            while (true)
            {
                if (GameField.GameStatus)
                {
                    FindEnemy();
                    if (isenemy)
                    {
                        (int x, int y) prev = coordinates;
                        int distance = BFSRadar(prev.y, prev.x);
                        if (distance < 7)
                        {
                            if (distance == 1)
                            {
                                GameField.Defeat();
                                GameField.GameStatus = false;
                            }
                            else if (BFSRadar(prev.y - 1, prev.x) == distance - 1 && Field.frame[prev.y - 1][prev.x].CanEnter())
                            {
                                GoEnemy(0, -1);
                            }
                            else if (BFSRadar(prev.y + 1, prev.x) == distance - 1 && Field.frame[prev.y + 1][prev.x].CanEnter())
                            {
                                GoEnemy(0, 1);
                            }
                            else if (BFSRadar(prev.y, prev.x + 1) == distance - 1 && Field.frame[prev.y][prev.x + 1].CanEnter())
                            {
                                GoEnemy(1, 0);
                            }
                            else if (BFSRadar(prev.y, prev.x - 1) == distance - 1 && Field.frame[prev.y][prev.x - 1].CanEnter())
                            {
                                GoEnemy(-1, 0);
                            }
                        }
                        else
                        {
                            int move = randomNumber.Next() % 8;
                            if (move == 0 && Field.frame[prev.y - 1][prev.x].CanEnter())
                            {
                                GoEnemy(0, -1);
                            }
                            else if (move == 1 && Field.frame[prev.y + 1][prev.x].CanEnter())
                            {
                                GoEnemy(0, 1);
                            }
                            else if (move == 2 && Field.frame[prev.y][prev.x + 1].CanEnter())
                            {
                                GoEnemy(1, 0);
                            }
                            else if (move == 3 && Field.frame[prev.y][prev.x - 1].CanEnter())
                            {
                                GoEnemy(-1, 0);
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
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
                if (Field.frame[BFSQuery[0].y][BFSQuery[0].x].Value == new Hero().Value)
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
