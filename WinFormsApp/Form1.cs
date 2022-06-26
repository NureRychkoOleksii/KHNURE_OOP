using Core.NewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Core.Models;
using WinFormsApp.Services;
using User = WinFormsApp.Models.User;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private Thread _th;
        private User _user = new User();
        private Direction _currentDir = Direction.Stop;
        private Direction _currentBallDir = Direction.Right;
        private Core.NewModels.Player _player = new Core.NewModels.Player(0,0);
        private Core.NewModels.Ball _ball = new Core.NewModels.Ball(0, 0);
        private Map map = new Map();
        private int _total = 0;
        private int _score = 0;

        private GraphicEngine _graphicEngine;
        Checkings checkings = new Checkings();

        private List<PictureBox> _energyBalls = new List<PictureBox>();

        // private PictureBox _tp = new PictureBox()
        // {
        //     Name = $"tp",
        //     Size = new Size(15, 15),
        //     Location = new Point(new Random().Next(1, 66) * 10, new Random().Next(1, 33) * 15),
        //     BackColor = Color.Yellow
        // };

        public Form1(User user)
        {
            InitializeComponent();
            _graphicEngine = new GraphicEngine(this);
            BaseElement.DrawElement += _graphicEngine.Draw;
            BaseElement.ClearElement += _graphicEngine.Clear;
            map.CreateMap();
            DetermineElements(ref _player, ref _ball);
            _graphicEngine.playerPicturebox.Tag = "slash";
            _user = user;
            timer1.Interval = 300;
            timer1.Start();
            this.KeyDown += UpdateKeyEventHandler;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_score == _total)
            {
                this.Close();
                _th = new Thread(OpenNewForm);
                _th.SetApartmentState(ApartmentState.STA);
                _th.Start();
            }
            CheckBall();
            var (dx, dy) = DirectionsDictionary.directions[_currentBallDir];
            //_currentDir = checkings.FrameTick(_currentDir, _player, map);
            int ballX = _ball.X, ballY = _ball.Y;
            map[ballX, ballY] = new Empty(ballX, ballY);
            _ball.X += dx;
            _ball.Y += dy;
            map[_ball.X, _ball.Y] = new Core.NewModels.Ball(_ball.X, _ball.Y);
            _graphicEngine.ballPictureBox.Location = new Point(_graphicEngine.ballPictureBox.Location.X + dx * 15, _graphicEngine.ballPictureBox.Location.Y + dy * 15);
            //map.UpdateMap();
        }

        private void CheckBall()
        {
            var (dx, dy) = DirectionsDictionary.directions[_currentBallDir];
            if (_ball.X + 1 == map.map.GetLength(0) || _ball.Y + 1 == map.map.GetLength(1) || _ball.X == 0 || _ball.Y == 0)
            {
                _currentBallDir = checkings.ChangeDirection(_currentBallDir);
            }
            foreach (var item in map.map)
            {
                if (_ball.X + dx == item.X && _ball.Y + dy == item.Y)
                {
                    if (item.isStopping && item.isHorizontal)
                    {
                        _currentBallDir = checkings.ChangeDirection(_currentBallDir);
                    }
                    else if (!item.isHorizontal)
                    {
                        _currentBallDir = checkings.ChangeDirectionWithPlayer(_currentBallDir, _player);
                    }
                    else if (item.isCollecting)
                    {
                        foreach(var i in this.Controls)
                        {
                            if(i is PictureBox picture)
                            {
                                if(picture.Location.X == (item.X * 15) && picture.Location.Y == (item.Y * 15))
                                {
                                    this.Controls.Remove(picture);
                                }
                            }
                        }
                        map[item.X, item.Y] = new Empty(item.X, item.Y);
                        _score++;
                    }

                }
            }
        }

        private void UpdateKeyEventHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    _currentDir = Direction.Right;
                    break;
                case "Left":
                    _currentDir = Direction.Left;
                    break;
                case "Down":
                    _currentDir = Direction.Down;
                    break;
                case "Up":
                    _currentDir = Direction.Up;
                    break;
                case "Tab":
                    ChangeImage();
                    _currentDir = Direction.Stop;
                    break;
            }
            var (dx, dy) = DirectionsDictionary.directions[_currentDir];
            _currentDir = checkings.FrameTick(_currentDir, _player, map);
            if (_currentDir != Direction.Stop)
            {
                _graphicEngine.playerPicturebox.Location = new Point(_graphicEngine.playerPicturebox.Location.X + dx * 15, _graphicEngine.playerPicturebox.Location.Y + dy * 15);
                (dx,dy) = DirectionsDictionary.directions[_currentDir];
                map[_player.X, _player.Y] = new Empty(_player.X, _player.Y);
                _player.X += dx;
                _player.Y += dy;
                map[_player.X, _player.Y] = new Core.NewModels.Player(_player.X, _player.Y) { reverseSlash = _player.reverseSlash };
            }
        }

        private void ChangeImage()
        {
            _player.reverseSlash = !_player.reverseSlash;
            if (!_player.reverseSlash)
            {
                _graphicEngine.playerPicturebox.BackgroundImage = Image.FromFile(@"C:\Users\moonler\OneDrive - Kharkiv National University of Radioelectronics\Desktop\slash.png");
                _graphicEngine.playerPicturebox.BackgroundImage.Tag = "slash";
            }
            else
            {
                _graphicEngine.playerPicturebox.BackgroundImage = Image.FromFile(@"C:\Users\moonler\OneDrive - Kharkiv National University of Radioelectronics\Desktop\reverseSlash.png");
                _graphicEngine.playerPicturebox.BackgroundImage.Tag = "reverseSlash";
            }

        }

        private void OpenNewForm()
        {
            Application.Run(new Form4(_user));
        }

        private void DetermineElements(ref Core.NewModels.Player player, ref Core.NewModels.Ball ball)
        {
            foreach (var i in map.map)
            {
                if (i is Core.NewModels.Player)
                {
                    player = (Core.NewModels.Player)i;
                }
                else if (i is Core.NewModels.Ball)
                {
                    ball = (Core.NewModels.Ball)i;
                }
                else if (i is EnergyBall)
                {
                    _total++;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void scoreBox_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
