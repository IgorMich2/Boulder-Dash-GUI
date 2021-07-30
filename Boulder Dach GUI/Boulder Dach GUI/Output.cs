using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace Boulder_Dach_GUI
{
    class Output
    {
        public static bool switcherrocks = false;
        public static bool switcherempty = false;
        public static bool switcherenemy = false;
        public static bool switcherisenemy = false;
        public static bool switcherhero = false;
        public static bool switchervalue = false;
        public static bool switchupdate = false;
        public static bool switchhelp = false;
        public static string helpmessage = "";
        public static object locker = new object();
        public static (int x, int y) Rockcoordinates;
        public static (int x, int y) Emptycoordinates;
        public static (int x, int y) Herocoordinates;
        public static (int x, int y) Valuecoordinates;
        public static (int x, int y) Enemycoordinates;
        public static Cell value;
        public static Label[] Last = new Label[12];
        public static PictureBox Enemy = new PictureBox();
        
        public static void ArrayStart()
        {

        }

        public static void PrintCell2(int x, int y, Cell Printed, Form Boulder)
        {
            PictureBox PrintedCell = new PictureBox();
            PrintedCell.SizeMode = PictureBoxSizeMode.StretchImage;
            PrintedCell.Location = new Point(x * 20, y * 20);
            PrintedCell.Size = new Size(20, 20);
            PrintedCell.Image = Image.FromFile(Printed.Path());
            PrintedCell.BringToFront();

            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(PrintedCell);
                    PrintedCell.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(PrintedCell);
                PrintedCell.BringToFront();
            }
        }

        public static void PrintCell(int x, int y, Cell Printed, Form Boulder)
        {
            PictureBox Test = new PictureBox();
            Test.SizeMode = PictureBoxSizeMode.StretchImage;
            Test.Location = new Point(x * 20, y * 20);
            Test.Size = new Size(20, 20);
            Test.Image = Image.FromFile(Printed.Path());
            Test.BringToFront();

            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    //Boulder.Controls.Add(test);
                    Boulder.Controls.Add(Test);
                    Test.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Test);
                Test.BringToFront();
            }
        }

        public static void PrintingRocks(Form Boulder)
        {
            while (true)
            {
                lock (locker)
                {
                    if (switcherrocks)
                    {
                        PictureBox Test = new PictureBox();
                        Test.SizeMode = PictureBoxSizeMode.StretchImage;
                        Test.Location = new Point(Rockcoordinates.x, Rockcoordinates.y);
                        Test.Size = new Size(20, 20);
                        Test.Image = Image.FromFile("rock.jpg");
                        Test.BringToFront();

                        if (Boulder.InvokeRequired)
                        {
                            Boulder.BeginInvoke((MethodInvoker)delegate ()
                            {
                                Boulder.Controls.Add(Test);
                                Test.BringToFront();
                            });
                        }
                        else
                        {
                            Boulder.Controls.Add(Test);
                            Test.BringToFront();
                        }
                        switcherrocks = false;
                    }
                }
                Thread.Sleep(200);
            }
        }

        public static void PrintingEmptyies(Form Boulder)
        {
            while (true)
            {
                if (switcherempty)
                {
                    PictureBox Test = new PictureBox();
                    Test.SizeMode = PictureBoxSizeMode.StretchImage;
                    Test.Location = new Point(Emptycoordinates.x, Emptycoordinates.y);
                    Test.Size = new Size(20, 20);
                    Test.Image = Image.FromFile("empty.jpg");
                    Test.BringToFront();

                    if (Boulder.InvokeRequired)
                    {
                        Boulder.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Boulder.Controls.Add(Test);
                            Test.BringToFront();
                        });
                    }
                    else
                    {
                        Boulder.Controls.Add(Test);
                        Test.BringToFront();
                    }
                    switcherempty = false;
                }
                Thread.Sleep(200);
            }
        }

        public static void PrintingHero(Form Boulder)
        {
            while (true)
            {
                if (switcherhero)
                {
                    PictureBox Test = new PictureBox();
                    Test.SizeMode = PictureBoxSizeMode.StretchImage;
                    Test.Location = new Point(Herocoordinates.x, Herocoordinates.y);
                    Test.Size = new Size(20, 20);
                    Test.Image = Image.FromFile("hero.jpg");
                    Test.BringToFront();

                    if (Boulder.InvokeRequired)
                    {
                        Boulder.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Boulder.Controls.Add(Test);
                            Test.BringToFront();
                        });
                    }
                    else
                    {
                        Boulder.Controls.Add(Test);
                        Test.BringToFront();
                    }
                    switcherhero = false;
                }
                Thread.Sleep(100);
            }
        }

        public static void PrintingValue(Form Boulder)
        {
            while (true)
            {
                if (switchervalue)
                {
                    PictureBox Test = new PictureBox();
                    Test.SizeMode = PictureBoxSizeMode.StretchImage;
                    Test.Location = new Point(Valuecoordinates.x, Valuecoordinates.y);
                    Test.Size = new Size(20, 20);
                    Test.Image = Image.FromFile(value.Path());
                    Test.BringToFront();

                    if (Boulder.InvokeRequired)
                    {
                        Boulder.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Boulder.Controls.Add(Test);
                            Test.BringToFront();
                        });
                    }
                    else
                    {
                        Boulder.Controls.Add(Test);
                        Test.BringToFront();
                    }
                    switchervalue = false;
                }
                Thread.Sleep(50);
            }
        }

        public static void PrintingEnemy(Form Boulder)
        {
            while (true)
            {
                if (switcherenemy)
                {
                    if (Boulder.InvokeRequired)
                    {
                        Boulder.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Boulder.Controls.Remove(Enemy);
                            Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                            Enemy.Location = new Point(Enemycoordinates.x, Enemycoordinates.y);
                            Enemy.Size = new Size(20, 20);
                            Enemy.Image = Image.FromFile("enemy.jpg");
                            Enemy.BringToFront();
                            Boulder.Controls.Add(Enemy);
                            Enemy.BringToFront();
                        });
                    }
                    else
                    {
                        Boulder.Controls.Remove(Enemy);
                        Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                        Enemy.Location = new Point(Enemycoordinates.x, Enemycoordinates.y);
                        Enemy.Size = new Size(20, 20);
                        Enemy.Image = Image.FromFile("enemy.jpg");
                        Enemy.BringToFront();
                        Boulder.Controls.Add(Enemy);
                        Enemy.BringToFront();
                    }
                    switchervalue = false;
                }
                Thread.Sleep(200);
            }
        }


        public static void Clear()
        {

        }

        public static void Lives()
        {

        }

        public static void Renderer(Form Boulder)
        {
            for (int i = 0; i < Field.frame.Count; i++)
            {
                for (int j = 0; j < Field.frame[0].Count; j++)
                {
                    if (Field.frame[i][j] is Portal)
                    {
                        Field.PortalCoordinates.Add((j, i));
                    }
                    Output.PrintCell(j, i, Field.frame[i][j], Boulder);
                }
            }
        }

        public static void UpdateField(Form Boulder)
        {
            while (true)
            {
                if (switchupdate)
                {
                    if (Boulder.InvokeRequired)
                    {
                        Boulder.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Boulder.Controls.Clear();
                        });
                    }
                    else
                    {
                        Boulder.Controls.Clear();
                    }
                    for (int i = 0; i < Field.frame.Count; i++)
                    {
                        for (int j = 0; j < Field.frame[0].Count; j++)
                        {
                            Output.PrintCell(j, i, Field.frame[i][j], Boulder);
                        }
                    }
                    switchupdate = false;
                }
                Thread.Sleep(5000);
            }
        }

        public static void BigSpace()
        {

        }

        public static void ToForm(Form Boulder, string Text, Point Location, int Index)
        {
            Label FormLabel = new Label();
            FormLabel.Location = Location;
            FormLabel.Text = Text;
            FormLabel.Size = new Size(400, 25);
            FormLabel.BringToFront();
            Last[Index] = FormLabel;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(FormLabel);
                });
            }
            else
            {
                Boulder.Controls.Add(FormLabel);
            }
            FormLabel.BringToFront();
        }

        public static void GameStart(Form Boulder)
        {    
            ToForm(Boulder, "Score: ", new Point(100, 500), 1);
            ToForm(Boulder, "Lives: ", new Point(100, 525), 2);
            ToForm(Boulder, "Deadlock: ", new Point(100, 550), 3);
            ToForm(Boulder, "Steps to @: ", new Point(100, 575), 4);
            ToForm(Boulder, "Time: ", new Point(100, 600), 5);
            ToForm(Boulder, "Digs: ", new Point(100, 625), 6);
            ToForm(Boulder, "Teleportates: ", new Point(100, 650), 8);
            ToForm(Boulder, "To finish level: ", new Point(100, 675), 9);
        }

        public static void GenereateInfo(Form Boulder)
        {
            ToForm(Boulder, "Steps: ", new Point(100, 650), 0);
            ToForm(Boulder, "Coordinates: ", new Point(100, 675), 7);
        }

        public static void InfoSteps(Form Boulder)
        {
            Last[0].Text = "Steps: " + Convert.ToString(Hero.steps);
            Last[7].Text = "Coordinates: x=" + Convert.ToString(Hero.x) + " y=" + Convert.ToString(Hero.y);
        }

        public static void Game(Form Boulder)
        {
            Last[1].Text = "Score: " + GameField.score;
            Last[2].Text = "Lives: " + Convert.ToString(Hero.lives);
            Last[3].Text = "Deadlock: " + Convert.ToString(!GenerationLevel.DFS(Hero.y, Hero.x));
            Last[4].Text = "Steps to @: " + Convert.ToString(GenerationLevel.BFSRadar(Hero.y, Hero.x));
            Last[5].Text = "Time: " + Convert.ToString(DateTime.Now.Subtract(GameField.Time));
            Last[6].Text = "Digs: " + Convert.ToString(Hero.digs);
            Last[8].Text = "Teleportates: " + Convert.ToString(Hero.Teleportation);
            Last[9].Text = "To finish level: " + helpmessage;
        }

        public static void GameClear(Form Boulder)
        {

            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        Boulder.Controls.Remove(Last[i]);
                    }
                });
            }
            else
            {
                for (int i = 1; i <= 9; i++)
                {
                    Boulder.Controls.Remove(Last[i]);
                }
            }
            Field.PortalCoordinates.Clear();
        }


        public static string GetName()
        {
            string input = Interaction.InputBox("Введите имя игрока", "Сохранение результата", "");

            return input;
        }

        public static void Exception(Exception ex)
        {
            //Console.WriteLine(ex.Message);
        }

        public static void Message(string text)
        {
            //Console.WriteLine(text);
        }
    }
}
