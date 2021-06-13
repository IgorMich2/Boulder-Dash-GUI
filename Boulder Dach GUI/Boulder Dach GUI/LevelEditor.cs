using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class LevelEditor
    {
        public static (int x, int y) cursor = (1, 1);
        public static bool on = false;
        public static bool exit = false; 
        public static void ChangeCell(Form Boulder)
        {
            Cell changed = new Empty();
            switch (Field.frame[cursor.x][cursor.y].Value)
            {
                case '@':
                    {
                        Field.frame[cursor.x][cursor.y] = new Empty();
                        changed = new Empty();
                        break;
                    }
                case ' ':
                    {
                        Field.frame[cursor.x][cursor.y] = new Hero();
                        changed = new Hero();
                        break;
                    }
                case 'I':
                    {
                        Field.frame[cursor.x][cursor.y] = new Rock();
                        changed = new Rock();
                        break;
                    }
                case 'o':
                    {
                        Field.frame[cursor.x][cursor.y] = new Sand();
                        changed = new Sand();
                        break;
                    }
                case '*':
                    {
                        Field.frame[cursor.x][cursor.y] = new Diamond();
                        changed = new Diamond();
                        break;
                    }
            }


            string writePath = "5.txt";

            using (StreamWriter sw = new StreamWriter(writePath))
            {
                for (int j = 0; j < Field.frame.Count; j++)
                {
                    for (int i = 0; i < Field.frame[0].Count; i++)
                    {
                        sw.Write(Field.frame[j][i].Value);
                    }
                    sw.WriteLine("");
                }
            }

            Output.PrintCell(cursor.y, cursor.x, changed, Boulder);
        }

        public static void Start()
        {

        }

        public static void MoveCursor(int dx, int dy)
        {
            if ((cursor.x + dx) > 0 && (cursor.y + dy) > 0 && (cursor.x + dx) < (GameField.frame.Count - 1) && (cursor.y + dy) < (GameField.frame[0].Count - 1))
            {
                cursor.x += dx;
                cursor.y += dy;
            }
        }
    }
}

