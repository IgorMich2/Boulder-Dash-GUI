﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;
using System.Media;



namespace Boulder_Dach_GUI
{
    
    public partial class BoulderDash : Form
    {
        public BoulderDash()
        {
            InitializeComponent();
        }

        public void BoulderDash_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Form Temp = this;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread music = new Thread(()=>Music.MusicFunction(Temp));
            music.Priority = ThreadPriority.Normal;

            music.Start();
            
           

            
            Thread lives = new Thread(() => gameField.LivesFunction(Temp));
            lives.Priority = ThreadPriority.Normal;
            //lives.Start();
            

            Thread GameFunctionThread = new Thread(GameFunction);
            GameFunctionThread.Priority = ThreadPriority.Highest;
            GameFunctionThread.Start();
            
            
            gameField.GetArrayFromFile("menu.txt", this);
            gameField.Renderer(this);

            
            
        }



        public void BoulderDash_KeyDown(object sender, KeyEventArgs e)
        {
            Encoding utf8 = Encoding.UTF8;
            gameField.MoveHero(e, this);
            //Functionx(sender, e);
           
        }


        public async void GameFunction()
        {
            Thread gravity = new Thread(() => gameField.GravityFunction(this));
            gravity.Priority = ThreadPriority.Normal;
            gravity.Start();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            int choose = -1;
            
            while (true)
            {
                gravity.Suspend();
                PictureBox menu = new PictureBox();
                menu.SizeMode = PictureBoxSizeMode.StretchImage;
                menu.Location = new Point(0, 0);
                menu.Size = new Size(1600, 900);
                menu.Image = Image.FromFile("menu.jpg");
                this.Invoke((MethodInvoker)delegate
                {
                    this.Controls.Add(menu);
                });
                
                gameField.maxpoint = 400;
                choose = -1;
                while (choose == -1)
                {
                    //Console.SetCursorPosition(Field.frame[1].Length, Field.frame.Count);
                    
                    if (gameField.score == 100)
                    {
                        for (int k = 6; k < Field.frame.Count; k++)
                        {
                            if (Field.frame[k][2] == Hero.value)
                            {
                                choose = k - 5;
                                break;
                            }
                        }
                    }

                    Thread.Sleep(100);
                }

                //Console.Clear();
                Field.frame.Clear();
                gameField.frame.Clear();
                //Console.SetCursorPosition(0, 0);
                gameField.score = 0;
                switch (choose)
                {
                    case 1:
                        {
                            gameField.GetArrayFromFile("1.txt", this);
                            gameField.maxpoint = 3400;
                            break;
                        }
                    case 2:
                        {
                            gameField.GetArrayFromFile("2.txt", this);
                            gameField.maxpoint = 3400;
                            break;
                        }
                    case 3:
                        {
                            gameField.GetArrayFromFile("3.txt", this);
                            gameField.maxpoint = 3400;
                            break;
                        }
                    case 4:
                        {
                            gameField.GetArrayFromFile("4.txt", this);
                            gameField.Random2(this);
                            
                            break;
                        }
                    case 5:
                        {
                            gameField.GetArrayFromFile("5.txt", this);
                            gameField.Intellectual(this);

                            break;
                        }
                    case 6:
                        {
                            
                            System.Environment.Exit(0);
                            Application.Exit();
                            this.Close();
                            break;
                        }
                }

                //Console.ForegroundColor = ConsoleColor.Cyan;

                gameField.Renderer(this);


                /* Console.SetCursorPosition(12, 24);
                 Console.Write("Score: " + gameField.score);
                 Console.SetCursorPosition(1, 24);
                 Console.Write("Lives: " + gameField.lives);*/

                gravity.Resume();
                while (true)
                {
                    /*Console.SetCursorPosition(Field.frame[1].Length, Field.frame.Count);
                    var keyInfo = Console.ReadKey();*/


                    if (gameField.score >= gameField.maxpoint)
                    {
                        break;
                    }
                    
                    /*Console.SetCursorPosition(24, 24);
                    Console.Write("Deadlock: " + !gameField.BFS(gameField.y, gameField.x));
                    Console.Write(" ");*/
                    //Console.SetCursorPosition(64, 24);
                    //Console.Write("Steps to @: " + gameField.BFS_help(gameField.y, gameField.x));
                    //Console.Write(" ");
                    Thread.Sleep(1000);
                }
                gravity.Suspend();
                gameField.score = 0;
                gameField.maxpoint = 400;
                //Console.Clear();
                Field.frame.Clear();
                Field.frame2.Clear();
                //gameField.frame.Clear();
                //Console.SetCursorPosition(0, 0);
                gameField.GetArrayFromFile("menu.txt", this);
                gameField.Renderer(this);
            }
        }

        private void BoulderDash_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            System.Environment.Exit(0);
            Application.Exit();
        }

        private void BoulderDash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Выйти из игры?",
                "Boulder Dash by Igor Michurin",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
