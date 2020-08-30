using System;
using System.Windows.Forms;

namespace car_racing_game
{
    public partial class Form1 : Form
    {
        private int speed = 1;
        private Random r = new Random();
        private int carHeight = 91 * 2;
        private int[] position = { 27, 117, 207, 297 };
        private int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (score >= speed * 10)
            {
                if (score % 10 == 0)
                {
                    if (speed < 21)
                    {
                        speed = score / 10 + 1;
                    }

                }
            }
            MoveLine(speed);
            Crash();

        }
        void Crash()
        {
            if (car.Left == enemy1.Left && (car.Top < enemy1.Bottom && car.Top > enemy1.Top))
            {
                speed = 0;
                gameOver_Box.Visible = true;
            }
            if (car.Left == enemy2.Left && (car.Top < enemy2.Bottom && car.Top > enemy2.Top))
            {
                speed = 0;
                gameOver_Box.Visible = true;
            }
            if (car.Left == enemy3.Left && (car.Top < enemy3.Bottom && car.Top > enemy3.Top))
            {
                speed = 0;
                gameOver_Box.Visible = true;
            }
        }

        void MoveLine(int speed)
        {
            #region Enemies move
            if (enemy1.Top >= 461)
            {
                enemy1.Top = -1 * carHeight;
                enemy1.Left = position[r.Next(0, 4)];
                score=score+1;
                score0ToolStripMenuItem.Text = $"Score: {score}";
            }
            else
            {
                enemy1.Top += speed;
            }

            if (enemy2.Top >= 461)
            {

                enemy2.Top = enemy1.Top - carHeight;
                enemy2.Left = position[r.Next(0, 4)];
                score++;
                score0ToolStripMenuItem.Text = $"Score: {score}";
            }
            else
            {
                enemy2.Top += speed;
            }

            if (enemy3.Top >= 461)
            {
                if (enemy2.Top >= 10)
                {
                    enemy3.Top = enemy2.Top - carHeight;
                    enemy3.Left = position[r.Next(0, 4)];
                    score++;
                    score0ToolStripMenuItem.Text = $"Score: {score}";
                }
            }
            else
            {
                enemy3.Top += speed;
            }
            #endregion

            #region Lines move
            if (pictureBox2.Top >= 461)
            {
                pictureBox2.Top = -115;
            }
            else
            {
                pictureBox2.Top += speed;
            }

            if (pictureBox3.Top >= 461)
            {
                pictureBox3.Top = -115;
            }
            else
            {
                pictureBox3.Top += speed;
            }

            if (pictureBox4.Top >= 461)
            {
                pictureBox4.Top = -115;
            }
            else
            {
                pictureBox4.Top += speed;
            }

            if (pictureBox5.Top >= 461)
            {
                pictureBox5.Top = -115;
            }
            else
            {
                pictureBox5.Top += speed;
            }

            if (pictureBox6.Top >= 461)
            {
                pictureBox6.Top = -115;
            }
            else
            {
                pictureBox6.Top += speed;
            }
            #endregion
        }

        void Init()
        {
            enemy1.Top = -carHeight;
            enemy2.Top = enemy1.Top - carHeight;
            enemy3.Top = enemy2.Top - carHeight;
            enemy4.Top = -carHeight;

            enemy1.Left = position[r.Next(0, 4)];
            enemy2.Left = position[r.Next(0, 4)];
            enemy3.Left = position[r.Next(0, 4)];
            enemy4.Left = position[r.Next(0, 4)];

            gameOver_Box.Visible = false;
            menuStrip1.BringToFront();
            car.BringToFront();
            speed = 1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver_Box.Visible == false)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (car.Left < 297)
                    {
                        car.Left += 90;
                    }

                }

                if (e.KeyCode == Keys.Left)
                {
                    if (car.Left > 27)
                    {
                        car.Left -= 90;
                    }
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Init();
        }
    }
}
