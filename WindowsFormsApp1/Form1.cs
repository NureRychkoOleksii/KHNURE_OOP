using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int dirXBall = 1, dirYBall = 0;
        private bool slash = true;
        int count = 0;
        public List<PictureBox> _walls = new List<PictureBox>();

        public List<PictureBox> _energyBalls = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            Music music = new Music();
            Items items = new Items();
            items.CreateItems();
            music.Play();
            timer1.Tick += new EventHandler(Update);
            timer1.Tick += new EventHandler(ChangeBallDirection);
            timer1.Interval = 100;
            timer1.Start();
            timer2.Tick += new EventHandler(CreateItems);
            timer2.Interval = 100;
            timer2.Start();
            this.KeyDown += new KeyEventHandler(OKP);
        }

        private void Update(Object myObject, EventArgs eventsArgs)
        {
            ball.Location = new Point(ball.Location.X + dirXBall * 10, ball.Location.Y + dirYBall * 10);
        }

        private void CreateItems(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (count == 10)
            {
                timer2.Tick -= new EventHandler(CreateItems);
                timer2.Enabled = false;
            }
            var picture1 = new PictureBox()
            {
                Name = $"wall{++count}",
                Size = new Size(15, 15),
                Location = new Point(rand.Next(1, 66) * 10, rand.Next(1, 66) * 10),
                BackColor = Color.Red
            };
            var picture2 = new PictureBox()
            {
                Name = $"energyBall{++count}",
                Size = new Size(15, 15),
                Location = new Point(rand.Next(1, 66) * 10, rand.Next(1, 66) * 10),
                BackColor = Color.Green
            };
            _walls.Add(picture1);
            this.Controls.Add(picture1);
            picture1.BringToFront();
            _energyBalls.Add(picture2);
            this.Controls.Add(picture2);
            picture2.BringToFront();
        }
        
        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.Location = new Point(player.Location.X + 10, player.Location.Y);
                    break;
                case "Left":
                    player.Location = new Point(player.Location.X - 10, player.Location.Y);
                    break;
                case "Down":
                    player.Location = new Point(player.Location.X, player.Location.Y + 10);
                    break;
                case "Up":
                    player.Location = new Point(player.Location.X, player.Location.Y - 10);
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
