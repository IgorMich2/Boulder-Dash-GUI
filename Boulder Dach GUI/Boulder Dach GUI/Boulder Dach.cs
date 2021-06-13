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
                            Logic.Game(Boulder);
                        });
                    }
                    else
                    {
                        Logic.Game(Boulder);
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
                Logic.GenereateInfo(Boulder);
                Hero.FindHero();
                Hero.steps = 0;
                Hero.digs = 0;
                GameField.maxpoint = 400;
                choose = -1;


                while (choose == -1)
                {
                    //Logic.BigSpace();
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
                    Logic.GameStart(Boulder);
                    Logic.GenereateInfo(Boulder);
                    Levels.Renderer(Boulder);
                    //LoadLevel();

                    Hero.FindHero();
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
                    Logic.GameClear(Boulder);
                    if (GameField.score >= GameField.maxpoint)
                    {
                        Database.EndLevel("Win", Boulder);
                    }
                    else
                    {
                        Database.EndLevel("Defeat", Boulder);
                    }
                }
                else if (GameField.TechnicalLevel == true)
                {
                    Levels.Renderer(Boulder);
                    Logic.GenereateInfo(Boulder);

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
                Levels.Renderer(Boulder);
                
                GameField.TechnicalLevel = false;
            }
        }

        private void BoulderForm_Load(object sender, EventArgs e)
        {
            Form Temp = this;
            
            Thread music = new Thread(Music.MusicFunction);
            music.Priority = ThreadPriority.Lowest;

            Thread lives = new Thread((() => Lives.LivesFunction(Temp)));
            lives.Priority = ThreadPriority.Lowest;

            Thread gravity = new Thread(()=>Gravity.GravityFunction(Temp));
            gravity.Priority = ThreadPriority.Lowest;

            Thread Info = new Thread(() => OnGame(Temp));
            Info.Priority = ThreadPriority.Lowest;
            Info.Start();

            Levels.GetArrayFromFile("menu.txt");
            //LoadLevel();
            Levels.Renderer(this);

            Thread GameFunctionThread = new Thread(()=>GameFunction(Temp));
            GameFunctionThread.Priority = ThreadPriority.Lowest;
            GameFunctionThread.Start();

            music.Start();
            lives.Start();
            gravity.Start();
            Logic.GenereateInfo(this);
        }

        private void BoulderForm_KeyDown(object sender, KeyEventArgs e)
        {
            Hero.MoveHero(e, this);

            Logic.InfoSteps(this);

        }

        //public void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        /*public void LoadLevel()
        {
            for (int x = 0; x < Field.frame.Count; x++)
            {
                for (int y = 0; y < Field.frame[0].Count; y++)
                {
                    PictureBox Test = new PictureBox();
                    Test.SizeMode = PictureBoxSizeMode.StretchImage;
                    Test.Location = new Point(x * 20, y * 20);
                    Test.Size = new Size(20, 20);
                    Cell Printed = Levels.ToCell(Convert.ToString(Field.frame[x][y].Value));
                    Test.Image = Image.FromFile(Printed.path());
                    Test.BringToFront();
                    Controls.Add(Test);
                    Test.BringToFront();
                    
                }
            }
        }*/

        public void UpdatePanel()
        {

        }

        public void BoulderForm_Paint(object sender, PaintEventArgs e)
        {
            
            /*Pen pen = new Pen(Color.Red);
            e.Graphics.DrawLine(pen, new Point(0, 0), new Point(200, 200));
            Logic.Set(e.Graphics);
            //Drawing();
            //Draw();

            e.Graphics.DrawLine(new Pen(Color.Red), new Point(0, 0), new Point(300, 300));*/
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

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
