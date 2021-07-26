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
        public static string valuefile;
        public static Cell value;
        public static Label[] Last = new Label[12];
        public static PictureBox Enemy = new PictureBox();
        

        public static void ArrayStart()
        {

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
                    switcherisenemy = true;
                }
                else
                {
                    if (switcherisenemy)
                    {
                        if (Boulder.InvokeRequired)
                        {
                            Boulder.BeginInvoke((MethodInvoker)delegate ()
                            {
                                Boulder.Controls.Remove(Enemy);
                            });
                        }
                        else
                        {
                            Boulder.Controls.Remove(Enemy);
                        }
                        switcherisenemy = false;
                    }
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

        /*public static void GameStart1(Form Boulder)
        {
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                    Enemy.Location = new Point(Enemycoordinates.x, Enemycoordinates.y);
                    Enemy.Size = new Size(0, 0);
                    Enemy.Image = Image.FromFile("enemy.jpg");
                    Enemy.BringToFront();
                    Boulder.Controls.Add(Enemy);
                    Enemy.BringToFront();
                });
            }
            else
            {
                Enemy.SizeMode = PictureBoxSizeMode.StretchImage;
                Enemy.Location = new Point(Enemycoordinates.x, Enemycoordinates.y);
                Enemy.Size = new Size(0, 0);
                Enemy.Image = Image.FromFile("enemy.jpg");
                Enemy.BringToFront();
                Boulder.Controls.Add(Enemy);
                Enemy.BringToFront();
            }
            switchervalue = false;


            Label Time = new Label();
            Time.Location = new Point(100, 600);
            Time.Text = "Time: ";
            Time.Size = new Size(400, 25);
            Time.BringToFront();
            Last[5] = Time;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Time);
                    Time.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Time);
                Time.BringToFront();
            }
            Time.BringToFront();

            Label Score = new Label();
            Score.Location = new Point(100, 500);
            Score.Text = "Score: ";
            Score.Size = new Size(400, 25);
            Score.BringToFront();
            Last[1] = Score;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Score);
                    Score.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Score);
                Score.BringToFront();
            }
            Score.BringToFront();


            Label Lives = new Label();
            Lives.Location = new Point(100, 525);
            Lives.Text = "Lives: ";
            Lives.Size = new Size(400, 25);
            Lives.BringToFront();
            Last[2] = Lives;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Lives);
                    Lives.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Lives);
                Lives.BringToFront();
            }
            Lives.BringToFront();

            Label Deadlock = new Label();
            Deadlock.Location = new Point(100, 550);
            Deadlock.Text = "Deadlock: ";
            Deadlock.Size = new Size(400, 25);
            Deadlock.BringToFront();
            Last[3] = Deadlock;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Deadlock);
                    Deadlock.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Deadlock);
                Deadlock.BringToFront();
            }
            Deadlock.BringToFront();

            
        }

        public static void GameStart2(Form Boulder)
        {

            Label Radar = new Label();
            Radar.Location = new Point(100, 575);
            Radar.Text = "Steps to @: ";
            Radar.Size = new Size(400, 25);
            Radar.BringToFront();
            Last[4] = Radar;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Radar);
                    Radar.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Radar);
                Radar.BringToFront();
            }
            Radar.BringToFront();

            Label Digs = new Label();
            Digs.Location = new Point(100, 625);
            Digs.Text = "Digs: ";
            Digs.Size = new Size(400, 25);
            Digs.BringToFront();
            Last[6] = Digs;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Digs);
                    Digs.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Digs);
                Digs.BringToFront();
            }
            Digs.BringToFront();

            Label Teleportates = new Label();
            Teleportates.Location = new Point(100, 700);
            Teleportates.Text = "Teleportates: ";
            Teleportates.Size = new Size(500, 25);
            Teleportates.BringToFront();
            Last[8] = Teleportates;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Teleportates);
                    Teleportates.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Teleportates);
                Teleportates.BringToFront();
            }
            Teleportates.BringToFront();



            Label Helptip = new Label();
            Helptip.Location = new Point(100, 500);
            Helptip.Text = "Helptip: ";
            Helptip.Size = new Size(500, 100);
            Helptip.BringToFront();
            Last[9] = Helptip;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Helptip);
                    Helptip.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Helptip);
                Helptip.BringToFront();
            }
            Helptip.BringToFront();
        }*/

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
            /*Label Time = new Label();
            Time.Location = new Point(100, 600);
            Time.Text = "Time: ";
            Time.Size = new Size(400, 25);
            Time.BringToFront();
            Last[5] = Time;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Time);
                    Time.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Time);
                Time.BringToFront();
            }
            Time.BringToFront();

            Label Score = new Label();
            Score.Location = new Point(100, 500);
            Score.Text = "Score: ";
            Score.Size = new Size(400, 25);
            Score.BringToFront();
            Last[1] = Score;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Score);
                    Score.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Score);
                Score.BringToFront();
            }
            Score.BringToFront();
            

            Label Lives = new Label();
            Lives.Location = new Point(100, 525);
            Lives.Text = "Lives: ";
            Lives.Size = new Size(400, 25);
            Lives.BringToFront();
            Last[2] = Lives;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Lives);
                    Lives.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Lives);
                Lives.BringToFront();
            }
            Lives.BringToFront();
            
            Label Deadlock = new Label();
            Deadlock.Location = new Point(100, 550);
            Deadlock.Text = "Deadlock: ";
            Deadlock.Size = new Size(400, 25);
            Deadlock.BringToFront();
            Last[3] = Deadlock;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Deadlock);
                    Deadlock.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Deadlock);
                Deadlock.BringToFront();
            }
            Deadlock.BringToFront();
            
            Label Radar = new Label();
            Radar.Location = new Point(100, 575);
            Radar.Text = "Steps to @: ";
            Radar.Size = new Size(400, 25);
            Radar.BringToFront();
            Last[4] = Radar;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Radar);
                    Radar.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Radar);
                Radar.BringToFront();
            }
            Radar.BringToFront();
            
            Label Digs = new Label();
            Digs.Location = new Point(100, 625);
            Digs.Text = "Digs: ";
            Digs.Size = new Size(400, 25);
            Digs.BringToFront();
            Last[6] = Digs;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Digs);
                    Digs.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Digs);
                Digs.BringToFront();
            }
            Digs.BringToFront();
            
            Label Teleportates = new Label();
            Teleportates.Location = new Point(100, 700);
            Teleportates.Text = "Teleportates: ";
            Teleportates.Size = new Size(500, 100);
            Teleportates.BringToFront();
            Last[8] = Teleportates;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Teleportates);
                    Teleportates.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Teleportates);
                Teleportates.BringToFront();
            }
            Teleportates.BringToFront();

            

            Label Helptip = new Label();
            Helptip.Location = new Point(100, 500);
            Helptip.Text = "Helptip: ";
            Helptip.Size = new Size(500, 100);
            Helptip.BringToFront();
            Last[9] = Helptip;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Helptip);
                    Helptip.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Helptip);
                Helptip.BringToFront();
            }
            Helptip.BringToFront();*/
        }

        public static void GenereateInfo(Form Boulder)
        {
            Label Steps = new Label();
            Steps.Location = new Point(100, 650);
            Steps.Text = "Steps: ";
            Steps.Size = new Size(400, 25);
            Steps.BringToFront();
            Last[0] = Steps;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Steps);
                    Steps.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Steps);
                Steps.BringToFront();
            }
            Steps.BringToFront();

           

            Label Coordinates = new Label();
            Coordinates.Location = new Point(100, 675);
            Coordinates.Text = "Coordinates: ";
            Coordinates.Size = new Size(500, 100);
            Coordinates.BringToFront();
            Last[7] = Coordinates;
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Add(Coordinates);
                    Coordinates.BringToFront();
                });
            }
            else
            {
                Boulder.Controls.Add(Coordinates);
                Coordinates.BringToFront();
            }
            Coordinates.BringToFront();

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
