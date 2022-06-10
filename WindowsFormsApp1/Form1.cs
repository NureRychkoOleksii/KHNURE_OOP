using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int dirXBall = 1, dirYBall = 0;
        private bool slash = true;

        public Form1()
        {
            InitializeComponent();
            Music music = new Music();
            music.Play();
            timer1.Tick += new EventHandler(Update);
            timer1.Tick += new EventHandler(ChangeBallDirection);
            timer1.Interval = 100;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OKP);
        }

        private void Update(Object myObject, EventArgs eventsArgs)
        {
            ball.Location = new Point(ball.Location.X + dirXBall * 15, ball.Location.Y + dirYBall * 15);
        }

        
        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.Location = new Point(player.Location.X + 15, player.Location.Y);
                    break;
                case "Left":
                    player.Location = new Point(player.Location.X - 15, player.Location.Y);
                    break;
                case "Down":
                    player.Location = new Point(player.Location.X, player.Location.Y + 15);
                    break;
                case "Up":
                    player.Location = new Point(player.Location.X, player.Location.Y - 15);
                    break;
            }
        }

        private void ChangeBallDirection(object sender, EventArgs e)
        {
            if(ball.Location.X < 0)
            {
                dirXBall = 1;
            }
            else if(ball.Location.X >= 660)
            {
                dirXBall = -1;
            }
            else if (ball.Location.Y >= 660)
            {
                dirYBall = -1;
            }
            else if (ball.Location.Y < 0)
            {
                dirYBall = 1;
            }

            if(player.Location.X == ball.Location.X && player.Location.Y == ball.Location.Y)
            {
                if(slash)
                {
                    ChangeBallAndWallSlash(DefineDirection());
                }
            }
        }

        private string DefineDirection()
        {
            if(dirXBall == 1)
            {
                return "right";
            }
            else if(dirXBall == -1)
            {
                return "left";
            }
            else if(dirYBall == 1)
            {
                return "down";
            }
            else
            {
                return "up";
            }
        }

        private void ChangeBallAndWallSlash(string dir)
        {
            switch(dir)
            {
                case "right":
                    dirXBall = 0;
                    dirYBall = -1;
                    break;
                case "left":
                    dirXBall = 0;
                    dirYBall = 1;
                    break;
                case "up":
                    dirXBall = 1;
                    dirYBall = 0;
                    break;
                case "down":
                    dirXBall = -1;
                    dirYBall = 0;
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
