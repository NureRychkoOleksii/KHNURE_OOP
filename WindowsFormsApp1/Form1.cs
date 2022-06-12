using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int _dirXBall = 1, _dirYBall = 0;
        private bool _slash = true;
        private int _count = 0;
        private int _score = 0;
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
            ball.Location = new Point(ball.Location.X + _dirXBall * 10, ball.Location.Y + _dirYBall * 10);
        }

        private void CreateItems(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (_count == 10)
            {
                timer2.Tick -= new EventHandler(CreateItems);
                timer2.Enabled = false;
            }
            var picture1 = new PictureBox()
            {
                Name = $"wall{++_count}",
                Size = new Size(15, 15),
                Location = new Point(rand.Next(1, 66) * 10, rand.Next(1, 66) * 10),
                BackColor = Color.Red
            };
            var picture2 = new PictureBox()
            {
                Name = $"energyBall{++_count}",
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
            if(_score == _energyBalls.Count())
            {
                this.Close();
            }
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
                case "Tab":
                    ChangeImage();
                    break;
            }
        }

        private void ChangeImage()
        {
            if(player.BackgroundImage.Tag == "reverseSlash")
            {
                player.BackgroundImage = Image.FromFile(@"C:\Users\moonler\OneDrive - Kharkiv National University of Radioelectronics\Desktop\slash.png");
            }
            else
            {
                player.BackgroundImage = Image.FromFile(@"C:\Users\moonler\OneDrive - Kharkiv National University of Radioelectronics\Desktop\reverseSlash.png");
                player.BackgroundImage.Tag = "reverseSlash";
            }
        }

        private void ChangeBallDirection(object sender, EventArgs e)
        {
            if(ball.Location.X < 0)
            {
                _dirXBall = 1;
            }
            else if(ball.Location.X >= 660)
            {
                _dirXBall = -1;
            }
            else if (ball.Location.Y >= 660)
            {
                _dirYBall = -1;
            }
            else if (ball.Location.Y < 0)
            {
                _dirYBall = 1;
            }

            if(player.Location.X == ball.Location.X && player.Location.Y == ball.Location.Y)
            {
                if(_slash)
                {
                    ChangeBallAndWallSlash(DefineDirection());
                }
            }
            if(_walls.Any(w => w.Location.X == ball.Location.X && w.Location.Y == ball.Location.Y))
            {
                ChangeInteractionDirection();
            }
            var item = _energyBalls.FirstOrDefault(w => w.Location.X == ball.Location.X && w.Location.Y == ball.Location.Y);
            if (item != null)
            {
                _score++;
                scoreBox.Text = Convert.ToString(_score);
                _energyBalls.Remove(item);
                this.Controls.Remove(item);
            }
        }

        private void ChangeInteractionDirection()
        {
            if(_dirXBall != 0)
            {
                switch(_dirXBall)
                {
                    case 1:
                        _dirXBall = -1;
                        break;
                    case -1:
                        _dirXBall = 1;
                        break;
                }
            }
            else
            {
                switch(_dirYBall)
                {
                    case 1:
                        _dirYBall = -1;
                        break;
                    case -1:
                        _dirYBall = 1;
                        break;
                }
            }
        }

        private string DefineDirection()
        {
            if(_dirXBall == 1)
            {
                return "right";
            }
            else if(_dirXBall == -1)
            {
                return "left";
            }
            else if(_dirYBall == 1)
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
            if (player.BackgroundImage.Tag == "slash")
            {
                switch (dir)
                {
                    case "right":
                        _dirXBall = 0;
                        _dirYBall = -1;
                        break;
                    case "left":
                        _dirXBall = 0;
                        _dirYBall = 1;
                        break;
                    case "up":
                        _dirXBall = 1;
                        _dirYBall = 0;
                        break;
                    case "down":
                        _dirXBall = -1;
                        _dirYBall = 0;
                        break;
                }
            }
            else
            {
                switch (dir)
                {
                    case "right":
                        _dirXBall = 0;
                        _dirYBall = 1;
                        break;
                    case "left":
                        _dirXBall = 0;
                        _dirYBall = -1;
                        break;
                    case "up":
                        _dirXBall = -1;
                        _dirYBall = 0;
                        break;
                    case "down":
                        _dirXBall = 1;
                        _dirYBall = 0;
                        break;
                }
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
