using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dach_GUI
{
    class Portal:Cell
    {
        public static (int x, int y) coordinatesthis;
        public static (int x, int y) coordinatesnew;
        public static bool Isteleportes = false;
        public override char Value { get => '&'; }
        public override bool CanEnter()
        {
            return false;
        }

        public override string path()
        {
            return "portal.jpg";
        }

        public override void Teleportation(int y, int x)
        {
            //if (!Isteleportes) {
                coordinatesthis = (x, y);
                FindPortals();
                for (int i = coordinatesnew.x + 1; i >= coordinatesnew.x - 1; i--)
                {
                    for (int j = coordinatesnew.y - 1; j <= coordinatesnew.y + 1; j++)
                    {
                        if (Field.frame[j][i].CanEnter())
                        {
                            Hero.GoHero(j, i);
                        }
                    }
                }
                //Isteleportes = true;
            //}
        }

        public static void FindPortals()
        {
            for (int i = 0; i < Field.frame.Count; i++)
            {
                for (int j = 0; j < Field.frame[0].Count; j++)
                {
                    if (Field.frame[i][j].Value == new Portal().Value && coordinatesthis.x != j && coordinatesthis.y != i)
                    {
                        coordinatesnew.x = j;
                        coordinatesnew.y = i;
                        break;
                    }
                }
            }
        }
    }
}
