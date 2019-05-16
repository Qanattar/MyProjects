using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LilGame
{
    public partial class Form1 : Form
    {
        #region  variables
        int speed = 10;
        int score = 0;
        int bulletSpeed ;
        bool moveRight = false;
        bool moveLeft = false;
        bool moveUp = false;
        bool moveDown = false;
        #endregion

        Random random = new Random(DateTime.Now.Second);

        public Form1()
        {
            InitializeComponent();
            Point p = new Point
            {
                X = random.Next(100, 500),
                Y = random.Next(150, 350)
            };
            bulletSpeed = random.Next(14,20);
            coin.Location = new Point(p.X, p.Y);

            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) moveRight = true;
            if (e.KeyCode == Keys.A) moveLeft = true;
            if (e.KeyCode == Keys.W) moveUp = true;
            if (e.KeyCode == Keys.S) moveDown = true;

            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) moveRight = false;
            if (e.KeyCode == Keys.A) moveLeft = false;
            if (e.KeyCode == Keys.W) moveUp = false;
            if (e.KeyCode == Keys.S) moveDown = false;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (moveRight)
            {
                hero.Left += speed;
            }
            if (moveLeft)
            {
                hero.Left -= speed;
            }
            if (moveUp)
            {
                hero.Top -= speed;
            }
            if (moveDown)
            {
                hero.Top += speed;
            }
            #region bullets
            bullet.Top += bulletSpeed;
            if (bullet.Top > 50) bullet.Visible = true;
            if (bullet.Top >499)
            {
                bullet.Top = random.Next(0,30);
                bullet.Visible = false;
            }
            bulletSpeed = random.Next(14, 20);
            bullet2.Top += bulletSpeed;
            if (bullet2.Top > 50) bullet2.Visible = true;
            if (bullet2.Top > 499)
            {
                bullet2.Top = random.Next(0, 30);
                bullet2.Visible = false;
            }
            bulletSpeed = random.Next(14, 20);
            bullet3.Top += bulletSpeed;
            if (bullet3.Top > 50) bullet3.Visible = true;
            if (bullet3.Top > 499)
            {
                bullet3.Top = random.Next(0, 30);
                bullet3.Visible = false;
            }
            #endregion
            
            CheckCollision();
            Refresh();
        }

        private void GenerateCoin()
        {
            Point p = new Point
            {
                X = random.Next(100, 500),
                Y = random.Next(150, 350)
            };
            coin.Location = new Point(p.X, p.Y);
        }

        private void CheckCollision()
        {
            if (bullet.Top >= hero.Top - 25 && bullet.Top <= hero.Top + 25 && bullet.Left >= hero.Left && bullet.Left <= hero.Left + 25)
            {
                gameTimer.Stop();
                MessageBox.Show("GAME OVER");
            }
            if (bullet2.Top >= hero.Top - 25 && bullet2.Top <= hero.Top + 25 && bullet2.Left >= hero.Left && bullet2.Left <= hero.Left + 25)
            {
                gameTimer.Stop();
                MessageBox.Show("GAME OVER");
            }
            if (bullet3.Top >= hero.Top - 25 && bullet3.Top <= hero.Top + 25 && bullet3.Left >= hero.Left && bullet3.Left <= hero.Left + 25)
            {
                gameTimer.Stop();
                MessageBox.Show("GAME OVER");
            }
            if (coin.Top >= hero.Top - 25 && coin.Top <= hero.Top + 25 && coin.Left >= hero.Left && coin.Left <= hero.Left + 25)
            {
                GenerateCoin();
                score++;
                label2.Text = score.ToString();
            }
        }
    }
}
