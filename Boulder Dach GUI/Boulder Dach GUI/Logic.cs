using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic;

namespace Boulder_Dach_GUI
{
    class Logic
        {
        //public static Form Boulder;
        public static Graphics e;
        public static void Set(Graphics test)
        {
            e = test;
        }

        public static Label[] Last = new Label[8];

        public static void ArrayStart()
        {
            
        }

            public static void PrintCell(int x, int y, Cell Printed, Form Boulder)
        {
            PictureBox Test = new PictureBox();
            Test.SizeMode = PictureBoxSizeMode.StretchImage;
            Test.Location = new Point(x*20, y*20);
            Test.Size = new Size(20, 20);
            Test.Image = Image.FromFile(Printed.path());
            Test.BringToFront();
            //Bitmap test = new Bitmap(Printed.path(), true);
            //Image Test = Image.FromFile(Printed.path());
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

        public static void GameStart(Form Boulder)
        {
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
        }

        public static void GameClear(Form Boulder)
        {
            
            if (Boulder.InvokeRequired)
            {
                Boulder.BeginInvoke((MethodInvoker)delegate ()
                {
                    Boulder.Controls.Remove(Last[1]);
                    Boulder.Controls.Remove(Last[2]);
                    Boulder.Controls.Remove(Last[3]);
                    Boulder.Controls.Remove(Last[4]);
                    Boulder.Controls.Remove(Last[5]);
                    Boulder.Controls.Remove(Last[6]);
                });
            }
            else
            {
                Boulder.Controls.Remove(Last[1]);
                Boulder.Controls.Remove(Last[2]);
                Boulder.Controls.Remove(Last[3]);
                Boulder.Controls.Remove(Last[4]);
                Boulder.Controls.Remove(Last[5]);
                Boulder.Controls.Remove(Last[6]);
            }
        }


        public static string GetName()
        {

            /*if (MessageBox.Show("Введите имя игрока",
                "Boulder Dash by Igor Michurin",
                ,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                e.Cancel = true;
            }*/
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
