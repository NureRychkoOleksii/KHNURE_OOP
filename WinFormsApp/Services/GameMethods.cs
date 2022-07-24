using Core.Methods;
using Core.Models;
using Core.NewModels;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp.Services
{
    public class GameMethods
    {
        public void StartGame(ref Map map, ref TimeCheck time, User user, bool isNew)
        {
            if(isNew)
            {
                map.CreateMap(user);
            }
            else
            {
                map.UpdateMap();
            }
            time.StartTimeChecking();
        }
        public void DetermineMap(Map _map, ref Map mapToChange, ref bool isNew)
        {
            mapToChange = _map == null ? new Map(50, 50) : _map;
            isNew = _map == null ? true : false;
        }

        public void Initalization(GraphicEngine _graphicEngine)
        {
            var music = new Music();
            music.Play();
            BaseElement.DrawElement += _graphicEngine.Draw;
            BaseElement.ClearElement += _graphicEngine.Clear;
        }

        public void MoveBall(ref Direction _currentBallDir, ref Core.NewModels.Ball _ball, ref Map map, ref GraphicEngine _graphicEngine)
        {
            var (dx, dy) = DirectionsDictionary.directions[_currentBallDir];
            _ball.Action(ref map, _currentBallDir);
            _graphicEngine.ballPictureBox.Location = new Point(_graphicEngine.ballPictureBox.Location.X + dx * 15, _graphicEngine.ballPictureBox.Location.Y + dy * 15);
        }

        public void CheckBall(ref Direction _currentBallDir, ref Core.NewModels.Ball _ball, ref Map map, Methods checkings, ref Core.NewModels.Player _player, GameForm form, ref int _score, ref int _userScore)
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
                    if (item.isStopping)
                    {
                        if(!item.isAngleChanging)
                        {
                            _currentBallDir = checkings.ChangeDirection(_currentBallDir);
                        }
                        else
                        {
                            _currentBallDir = checkings.ChangeDirectionWithPlayer(_currentBallDir, _player);
                        }
                    }
                    else if (item.isCollecting || item is Teleport)
                    {
                        if(item is Teleport)
                        {
                            Random rand = new Random();
                            map[item.X, item.Y] = new Empty(item.X, item.Y);
                            int x = rand.Next(5, 25);
                            int y = rand.Next(5, 25);
                            foreach(var i in form.pictureBox1.Controls)
                            {
                                if (i is PictureBox pictureBox && pictureBox.Location.X == _ball.X * 15 && pictureBox.Location.Y == _ball.Y * 15)
                                {
                                    pictureBox.Location = new Point(x * 15, y * 15);
                                }
                            }
                            _ball.Teleport(ref map, x, y);
                        }
                        else
                        {
                            map[item.X, item.Y] = new Empty(item.X, item.Y);
                            _userScore++;
                            _score++;
                            form.scoreBox.Text = Convert.ToString(_score);
                        }
                        item.Clear(item.X, item.Y);
                    }
                }
            }
        }

        public void End(TimeCheck time, ref User _user, UserService _userService)
        {
            time.StopTimeChecking();
            _user.Record = time.stopwatch.Elapsed.ToString();
            _userService.UpdateUser(ref _user, _user.Id);
        }

    }
}
