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
        public void StartGame(ref Map map, ref TimeCheck time, User user)
        {
            map.CreateMap(user);
            time.StartTimeChecking();
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
                    else if (item.isCollecting)
                    {
                        foreach (var i in form.pictureBox1.Controls)
                        {
                            if (i is PictureBox picture)
                            {
                                if (picture.Location.X == item.X * 15 && picture.Location.Y == item.Y * 15)
                                {
                                    form.pictureBox1.Controls.Remove(picture);
                                    break;
                                }
                            }
                        }
                        map[item.X, item.Y] = new Empty(item.X, item.Y);
                        _userScore++;
                        _score++;
                        form.scoreBox.Text = Convert.ToString(_score);
                    }
                }
            }
        }
        public void MovePlayer(ref Direction _currentDir, ref Map map, Checkings checkings, ref GraphicEngine _graphicEngine,ref Core.NewModels.Player _player)
        {
            var (dx, dy) = DirectionsDictionary.directions[_currentDir];
            _currentDir = checkings.FrameTick(_currentDir, _player, map);
            if (_currentDir != Direction.Stop)
            {
                _graphicEngine.playerPicturebox.Location = new Point(_graphicEngine.playerPicturebox.Location.X + dx * 15, _graphicEngine.playerPicturebox.Location.Y + dy * 15);
                _player.Action(ref map, _currentDir);
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
