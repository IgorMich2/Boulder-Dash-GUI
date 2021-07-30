using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dach_GUI
{
    class Portal : Cell
    {
        public (int x, int y) coordinatesthis;
        public (int x, int y) coordinatesnew = (10, 10);
        //public static bool Isteleportes = false;
        public override char Value { get => '&'; }
        public override bool CanEnter()
        {
            return true;
        }

        public override bool IsDestroyable { get => false; }

        public override void OnEnter()
        {
            //Thread.Sleep(110);
           /* Output.Emptycoordinates.x = Hero.x * 20;
            Output.Emptycoordinates.y = Hero.y * 20;
            Output.switcherempty = true;*/
            //Thread.Sleep(110);
            //portal.Teleportation(2 * y - prev.y, 2 * x - prev.x);
            Teleportation();
            Hero.Teleportation++;
        }

        public override string Path()
        {
            return "portal.jpg";
        }

        public void Teleportation()
        {
            coordinatesthis = (Hero.x, Hero.y);
            
            for (int i = 0; i < Field.PortalCoordinates.Count; i++)
            {
                if (coordinatesthis != Field.PortalCoordinates[i])
                {
                    coordinatesnew = Field.PortalCoordinates[i];
                }
            }

            for (int i = coordinatesnew.x - 1; i <= coordinatesnew.x + 1; i++)
            {
                for (int j = coordinatesnew.y; j <= coordinatesnew.y + 1; j++)
                {
                    if (!(Field.frame[j][i] is Portal) && Field.frame[j][i].CanEnter())
                    {
                        Hero.GoHero(j, i);
                    }
                }
            }
        }

        /*public void FindPortals()
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
        }*/
    }
}
