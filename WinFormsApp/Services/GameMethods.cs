using BLL;
using Core.Models;
using Core.NewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.Services
{
    public class GameMethods
    {
        public void StartGame(ref Map map, ref TimeCheck time)
        {
            map.CreateMap();
            time.StartTimeChecking();
        }

        public void MoveBall(ref Direction _currentBallDir, ref Core.NewModels.Ball _ball, ref Map map, ref GraphicEngine _graphicEngine)
        {
            var (dx, dy) = DirectionsDictionary.directions[_currentBallDir];
            int ballX = _ball.X, ballY = _ball.Y;
            map[ballX, ballY] = new Empty(ballX, ballY);
            _ball.X += dx;
            _ball.Y += dy;
            map[_ball.X, _ball.Y] = new Core.NewModels.Ball(_ball.X, _ball.Y);
            _graphicEngine.ballPictureBox.Location = new Point(_graphicEngine.ballPictureBox.Location.X + dx * 15, _graphicEngine.ballPictureBox.Location.Y + dy * 15);
        }

        public void CheckBall(ref Direction _currentBallDir, ref Core.NewModels.Ball _ball, ref Map map, Checkings checkings, ref Core.NewModels.Player _player, Form1 form, ref int _score)
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
                (dx, dy) = DirectionsDictionary.directions[_currentDir];
                map[_player.X, _player.Y] = new Empty(_player.X, _player.Y);
                _player.X += dx;
                _player.Y += dy;
                map[_player.X, _player.Y] = new Core.NewModels.Player(_player.X, _player.Y) { reverseSlash = _player.reverseSlash };
            }
        }
    }
}
