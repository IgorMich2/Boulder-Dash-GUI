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
using System.Diagnostics;

namespace Boulder_Dach_GUI
{
    public partial class BoulderForm : Form
    {
        public BoulderForm()
        {
            InitializeComponent();
        }

        public static void OnGame(Form Boulder)
        {
            while (true)
            {
                while (GameField.GameStatus == true)
                {
                    if (Boulder.InvokeRequired)
                    {
                        Boulder.BeginInvoke((MethodInvoker)delegate ()
                        {
                            Output.Game(Boulder);
                        });
                    }
                    else
                    {
                        Output.Game(Boulder);
                    }
                    Thread.Sleep(1000);
                }
                Thread.Sleep(1000);
            }
        }

        public static void GameFunction(Form Boulder)
        {
            int choose;
            bool openfile = false;
            Hero.FindHero();
            while (true)
            {
                Output.GenereateInfo(Boulder);
                Hero.FindHero();
                Hero.steps = 0;
                Hero.digs = 0;
                GameField.maxpoint = 400;
                choose = -1;


                while (choose == -1)
                {
                    if (GameField.score == 100)
                    {
                        for (int k = 7; k < Field.frame.Count; k++)
                        {
                            if (Field.frame[k][2].Value == new Hero().Value)
                            {
                                choose = k - 6;
                                break;
                            }
                        }
                    }
                    Thread.Sleep(500);
                }

                Field.frame.Clear();
                GameField.score = 0;
                GameField.maxpoint = 0;
                Hero.steps = 0;
                Rock.RocksDownGravity = 0;
                Hero.RocksMoveByHero = 0;
                Hero.digs = 0;
                switch (choose)
                {
                    case 1:
                        {
                            Levels.GetArrayFromFile("1.txt");
                            break;
                        }
                    case 2:
                        {
                            Levels.GetArrayFromFile("2.txt");
                            break;
                        }
                    case 3:
                        {
                            Levels.GetArrayFromFile("3.txt");
                            break;
                        }
                    case 4:
                        {
                            Levels.GetArrayFromFile("4.txt");
                            GenerationLevel.Random2();
                            break;
                        }
                    case 5:
                        {
                            Levels.GetArrayFromFile("4.txt");
                            GenerationLevel.Intellectual();
                            break;
                        }
                    case 6:
                        {
                            Levels.GetArrayFromFile("6.txt");
                            break;
                        }
                    case 7:
                        {
                            Levels.GetArrayFromFile("menu.txt");
                            Process.Start(new ProcessStartInfo(@"6.txt") { UseShellExecute = true });
                            openfile = true;
                            break;
                        }
                    case 8:
                        {
                            Levels.GetArrayFromFile("menu.txt");
                            Database.GetResults();
                            openfile = true;
                            break;
                        }
                    case 9:
                        {
                            Levels.GetArrayFromFile("menu.txt");
                            Database.GetBestResults();
                            openfile = true;
                            break;
                        }
                    case 10:
                        {
                            Levels.GetArrayFromFile("save.txt");
                            break;
                        }
                    case 11:
                        {
                            Levels.GetArrayFromFile("instruction.txt");
                            GameField.TechnicalLevel = true;
                            break;
                        }
                    case 12:
                        {
                            System.Environment.Exit(0);
                            break;
                        }
                    case 13:
                        {
                            Levels.GetArrayFromFile("5.txt");
                            GameField.TechnicalLevel = true;
                            break;
                        }
                    case 14:
                        {
                            Levels.GetArrayFromFile("5.txt");
                            break;
                        }
                }
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
                if (openfile == false && GameField.TechnicalLevel == false && Levels.Failedload == false)
                {
                    GameField.Time = DateTime.Now;
                    Output.GameStart(Boulder);
                    Output.GenereateInfo(Boulder);
                    Output.Renderer(Boulder);
                    //LoadLevel();

                    Hero.FindHero();
                    //Portal.FindPortals();
                    GameField.GameStatus = true;
                    while (true)
                    {
                        if (GameField.score >= GameField.maxpoint)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                    GameField.GameStatus = false;
                    Output.GameClear(Boulder);
                    if (GameField.score >= GameField.maxpoint)
                    {
                        Database.EndLevel("Win");
                    }
                    else
                    {
                        Database.EndLevel("Defeat");
                    }
                    /*if (Boulder.InvokeRequired)
                    {
                        Boulder.BeginInvoke((MethodInvoker)delegate ()
                        {
                            
                            Boulder.Controls.Remove(Enemy);
                        });
                    }
                    else
                    {
                        Boulder.Controls.Remove(Enemy);
                    }*/
                }
                else if (GameField.TechnicalLevel == true && choose != 13)
                {
                    Output.Renderer(Boulder);
                    Output.GenereateInfo(Boulder);

                    Hero.FindHero();

                    while (true)
                    {

                        if (GameField.score >= GameField.maxpoint)
                        {
                            break;
                        }
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    Output.Renderer(Boulder);
                    LevelEditor.on = true;

                    while (true)
                    {              
                        if (LevelEditor.exit)
                        {
                            LevelEditor.on = false;
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }

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
                
                GameField.score = 0;
                openfile = false;
                Field.frame.Clear();
                Levels.GetArrayFromFile("menu.txt");

                //LoadLevel();
                Output.Renderer(Boulder);
                
                GameField.TechnicalLevel = false;
            }
        }

        private void BoulderForm_Load(object sender, EventArgs e)
        {
            
            
            Thread music = new Thread(Music.MusicFunction);
            music.Priority = ThreadPriority.Lowest;

            Thread lives = new Thread(Lives.LivesFunction);
            lives.Priority = ThreadPriority.Lowest;

            Thread gravity = new Thread(Gravity.GravityFunction);
            gravity.Priority = ThreadPriority.Lowest;

            Thread Info = new Thread(() => OnGame(this));
            Info.Priority = ThreadPriority.Lowest;
            Info.Start();

            Thread PrintingRocks = new Thread(() => Output.PrintingRocks(this));
            PrintingRocks.Priority = ThreadPriority.Lowest;
            PrintingRocks.Start();

            Thread PrintingEmptyies = new Thread(() => Output.PrintingEmptyies(this));
            PrintingEmptyies.Priority = ThreadPriority.Lowest;
            PrintingEmptyies.Start();

            Thread PrintingHero = new Thread(() => Output.PrintingHero(this));
            PrintingHero.Priority = ThreadPriority.Lowest;
            PrintingHero.Start();

            Thread PrintingValue = new Thread(() => Output.PrintingValue(this));
            PrintingValue.Priority = ThreadPriority.Lowest;
            PrintingValue.Start();

            Thread PrintingEnemy = new Thread(() => Output.PrintingEnemy(this));
            PrintingEnemy.Priority = ThreadPriority.Lowest;
            PrintingEnemy.Start();

            /*Thread Printing = new Thread(() => Output.Printing(this));
            Printing.Priority = ThreadPriority.Lowest;
            Printing.Start();*/

            Thread MoveEnemy = new Thread(Enemy.MoveEnemy);
            MoveEnemy.Priority = ThreadPriority.Lowest;
            MoveEnemy.Start();

            Thread HelpTip = new Thread(Help.Update);
            HelpTip.Priority = ThreadPriority.Lowest;
            HelpTip.Start();

            

            Levels.GetArrayFromFile("menu.txt");
            //LoadLevel();
            Output.Renderer(this);

            Thread GameFunctionThread = new Thread(()=>GameFunction(this));
            GameFunctionThread.Priority = ThreadPriority.Lowest;
            GameFunctionThread.Start();

            Thread UpdateField = new Thread(()=>Output.UpdateField(this));
            UpdateField.Priority = ThreadPriority.Lowest;
            UpdateField.Start();
            
            music.Start();
            lives.Start();
            gravity.Start();
            Output.GenereateInfo(this);
        }

        private void BoulderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!LevelEditor.on)
            {
                string key = Convert.ToString(e.KeyData);
                Hero.MoveHero(key);
                Output.InfoSteps(this);
                Thread.Sleep(200);
            }
            else
            {
                switch (e.KeyData)
                {
                    case Keys.W:
                        {
                            LevelEditor.MoveCursor(-1, 0);
                            break;
                        }
                    case Keys.A:
                        {
                            LevelEditor.MoveCursor(0, -1);
                            break;
                        }
                    case Keys.D:
                        {
                            LevelEditor.MoveCursor(0, 1);
                            break;
                        }
                    case Keys.S:
                        {
                            LevelEditor.MoveCursor(1, 0);
                            break;
                        }
                    case Keys.Space:
                        {
                            LevelEditor.ChangeCell(this);
                            break;
                        }
                    case Keys.Escape:
                        {
                            LevelEditor.exit = true;
                            break;
                        }
                }
            }

        }

        private void BoulderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BoulderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Выйти из игры?",
                "Boulder Dash by Igor Michurin",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
