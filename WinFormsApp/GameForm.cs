using Core.NewModels;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Core.Models;
using WinFormsApp.Services;
using Core.Methods;

namespace WinFormsApp
{
    public partial class GameForm : Form
    {
        private Thread _thread;
        private EventHandler functionForMovement;
        private User _user = new User();
        private Direction _currentDir = Direction.Stop;
        private Direction _currentBallDir = Direction.Right;
        private Core.NewModels.Player _player = new Core.NewModels.Player(0,0, "default");
        private Core.NewModels.Ball _ball = new Core.NewModels.Ball(0, 0);
        private Map _map;
        private int _total = 0;
        private int _score = 0;
        TimeCheck time = new TimeCheck();
        private readonly UserService _userService = new UserService();
        private GameMethods _game = new GameMethods();
        private ProcessingKey movement = new ProcessingKey();
        Music music;
        bool isNew = false;

        private GraphicEngine _graphicEngine;
        Methods checkings = new Methods();

        public GameForm(User user, Map _map = null)
        {
            InitializeComponent();
            _user = user;
            _game.DetermineMap(_map, ref this._map, ref isNew);
            _graphicEngine = new GraphicEngine(this);
            _game.Initalization(_graphicEngine);
            functionForMovement += ChangeImage;
            StartGame(isNew);
            this.KeyDown += UpdateKeyEventHandler;
        }

        private void StartGame(bool isNew)
        {
            _game.StartGame(ref this._map, ref time, _user, isNew);
            checkings.DetermineElements(ref _player, ref _ball, this._map, ref _total, _user);
            timer1.Interval = 300;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_score == _total)
            {
                EndGame();
            }
            _game.CheckBall(ref _currentBallDir, ref _ball, ref _map, checkings, ref _player, this, ref _score, ref _user.CoinsCount);
            _game.MoveBall(ref _currentBallDir, ref _ball, ref _map, ref _graphicEngine);
            _userService.UpdateUser(ref _user, _user.Id);
        }

        private void UpdateKeyEventHandler(object sender, KeyEventArgs e)
        {
            _currentDir = movement.ProcessKeyWinForms(e.KeyCode.ToString(), functionForMovement);
            _currentDir = checkings.FrameTick(_currentDir, _player, _map);
            if (_currentDir != Direction.Stop)
            {
                var (dx, dy) = DirectionsDictionary.directions[_currentDir];
                _graphicEngine.playerPicturebox.Location = new Point(_graphicEngine.playerPicturebox.Location.X + dx * 15, _graphicEngine.playerPicturebox.Location.Y + dy * 15);
                _player.Action(ref _map, _currentDir);
            }
        }

        private void ChangeImage(object? sender, EventArgs e)
        {
            _player.reverseSlash = !_player.reverseSlash;
            if (!_player.reverseSlash)
            {
                _graphicEngine.playerPicturebox.BackgroundImage = Properties.Resources.slash;
            }
            else
            {
                _graphicEngine.playerPicturebox.BackgroundImage = Properties.Resources.reverseSlash;
            }
        }

        private void OpenNewForm()
        {
            Application.Run(new EndMenu(_user));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            music.Pause();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            music.ChangeVolume(10);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            music.ChangeVolume(-10);
        }
        private void EndGame()
        {
            _game.End(time, ref _user, _userService);
            this.Close();
            _thread = new Thread(OpenNewForm);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }
    }
}
