using System;
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

        private void BoulderDash_Load(object sender, EventArgs e)
        {
            Form Temp = this;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread music = new Thread(()=>Music.MusicFunction(Temp));
            //music.Priority = ThreadPriority.Normal;
            music.Start();
            Thread gravity = new Thread(gameField.GravityFunction);
            Thread lives = new Thread(gameField.LivesFunction);
            lives.Priority = ThreadPriority.Highest;
            //lives.Start();
            gravity.Priority = ThreadPriority.Normal;
            gameField.GetArrayFromFile("menu.txt");
            gameField.Renderer(this);
            //gravity.Start();
            while (true)
            {
                gameField.maxpoint = 400;
                int choose = -1;
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
                    Thread.Sleep(1000);
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
                            gameField.GetArrayFromFile("1.txt");
                            gameField.maxpoint = 3400;
                            break;
                        }
                    case 2:
                        {
                            gameField.GetArrayFromFile("2.txt");
                            gameField.maxpoint = 3400;
                            break;
                        }
                    case 3:
                        {
                            gameField.GetArrayFromFile("3.txt");
                            gameField.maxpoint = 3400;
                            break;
                        }
                    case 4:
                        {
                            gameField.GetArrayFromFile("4.txt");
                            gameField.Random2();
                            break;
                        }
                    case 5:
                        {
                            System.Environment.Exit(0);
                            break;
                        }
                }

                //Console.ForegroundColor = ConsoleColor.Cyan;
                gameField.Renderer(this);
               /* Console.SetCursorPosition(12, 24);
                Console.Write("Score: " + gameField.score);
                Console.SetCursorPosition(1, 24);
                Console.Write("Lives: " + gameField.lives);*/


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
                }

                gameField.score = 0;

                //Console.Clear();
                Field.frame.Clear();
                gameField.frame.Clear();
                /*Console.SetCursorPosition(0, 0);
                gameField.GetArrayFromFile("menu.txt");*/
                gameField.Renderer(this);
            }
        }

        

        private void BoulderDash_KeyDown(object sender, KeyEventArgs e)
        {
            gameField.MoveHero(e, this);
        }
    }
}
