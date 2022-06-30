using Core.NewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Core.Models;
using WinFormsApp.Services;
using Core.Methods;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private Thread _thread;
        private User _user = new User();
        private Direction _currentDir = Direction.Stop;
        private Direction _currentBallDir = Direction.Right;
        private Core.NewModels.Player _player = new Core.NewModels.Player(0,0);
        private Core.NewModels.Ball _ball = new Core.NewModels.Ball(0, 0);
        private Map map = new Map();
        private int _total = 0;
        private int _score = 0;
        Core.Methods.TimeCheck time = new Core.Methods.TimeCheck();
        private readonly UserService _userService;
        private GameMethods _game = new GameMethods();

        private GraphicEngine _graphicEngine;
        Checkings checkings = new Checkings();

        public Form1(User user)
        {
            InitializeComponent();
            _user = user;
            Music music = new Music();
            music.Play();
            _graphicEngine = new GraphicEngine(this);
            BaseElement.DrawElement += _graphicEngine.Draw;
            BaseElement.ClearElement += _graphicEngine.Clear;
            _game.StartGame(ref map, ref time);
            DetermineElements(ref _player, ref _ball);
            timer1.Interval = 300;
            timer1.Start();
            this.KeyDown += UpdateKeyEventHandler;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_score == _total)
            {
                EndGame();
            }
            _game.CheckBall(ref _currentBallDir, ref _ball, ref map, checkings, ref _player, this, ref _score);
            _game.MoveBall(ref _currentBallDir, ref _ball, ref map, ref _graphicEngine);
        }

        private void EndGame()
        {
            time.StopTimeChecking();
            _user.Record = time.stopwatch.Elapsed.ToString();
            _userService.UpdateUser(_user, _user.Id);
            this.Close();
            _thread = new Thread(OpenNewForm);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
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
            _game.MovePlayer(ref _currentDir, ref map, checkings, ref _graphicEngine, ref _player);
        }

        private void ChangeImage()
        {
            _player.reverseSlash = !_player.reverseSlash;
            if (!_player.reverseSlash)
            {
                _graphicEngine.playerPicturebox.BackgroundImage = Image.FromFile(@"C:\Users\moonler\OneDrive - Kharkiv National University of Radioelectronics\Desktop\slash.png");
            }
            else
            {
                _graphicEngine.playerPicturebox.BackgroundImage = Image.FromFile(@"C:\Users\moonler\OneDrive - Kharkiv National University of Radioelectronics\Desktop\reverseSlash.png");
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
    }
}
