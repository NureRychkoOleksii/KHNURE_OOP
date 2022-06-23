using System;
using System.Collections.Generic;
using System.Diagnostics;
using BLL.Services;
using System.Linq;
using BLL.Interfaces;
using Core.Models;
using Core.NewModels;
using PL.Services;
using BLL;
using System.Threading.Tasks;

namespace PL.StartupMethods
{
    public class Startup
    {
        private readonly IUserService _userService;
        public static Dictionary<Direction, (int,int)> directions = new Dictionary<Direction, (int,int)>();
        Core.NewModels.Player player;
        Core.NewModels.Ball ball;
        private int _score = 0;
        private int _total = 0;
        public Startup(IUserService service)
        {
            _userService = service;
        }

        private const int _mapWidth = 60;
        private const int _mapHeight = 40;

        private int _frameRate = 50;

        private readonly Map map= new Map();
        private readonly DrawMenu _drawMenu = new DrawMenu();

        public async Task StartGame()
        {
            directions.Add(Direction.Right, (1, 0));
            directions.Add(Direction.Left, (-1, 0));
            directions.Add(Direction.Up, (0, -1));
            directions.Add(Direction.Down, (0, 1));
            directions.Add(Direction.Stop, (0, 0));
            Console.SetWindowSize(150, 100);
            Console.SetBufferSize(150, 100);
            Console.SetWindowSize(100, 60);
            Console.SetBufferSize(100, 60);
            var menu = new DrawMainMenu();
            menu.DrawMenu();

            var login = new DrawLogin();
            if (Console.ReadKey(true).Key == ConsoleKey.D1)
            {
                var user = await login.Login(_userService);
                map.CreateMap();
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

                Console.ReadKey();
                Console.CursorVisible = false;
                var timeWatch = new TimeCheck();
                Direction currentDirection = Direction.Right;
                Direction currentDirectionPlayer = Direction.Stop;
                var oldMovementPlayer = currentDirectionPlayer;
                var movement = new Movement();
                var time = new TimeCheck();
                bool changeWall = false;
                var count = 0;
                time.StartTimeChecking();
                while (true)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    int x = player.X, y = player.Y;
                    int ballX = ball.X, ballY = ball.Y;
                    while (sw.ElapsedMilliseconds <= _frameRate)
                    {
                        if (currentDirectionPlayer == oldMovementPlayer)
                        {
                            movement.ProcessKey(ref currentDirectionPlayer, ref changeWall);
                        }
                    }
                    currentDirection = FrameTickBall(currentDirection, ball);
                    currentDirectionPlayer = FrameTick(currentDirectionPlayer, player);
                    if (currentDirectionPlayer != Direction.Stop)
                    {
                        player.Move(currentDirectionPlayer);
                        map[x, y] = new BaseElement(x, y);
                        map[player.X, player.Y] = new Core.NewModels.Player(player.X, player.Y) { reverseSlash = player.reverseSlash };
                    }
                    if (changeWall)
                    {
                        var temp = (Core.NewModels.Player)map[player.X, player.Y];
                        temp.reverseSlash = !temp.reverseSlash;
                        player.reverseSlash = !player.reverseSlash;
                    }
                    ball.Move(currentDirection);
                    map[ballX, ballY] = new BaseElement(ballX, ballY);
                    map[ball.X, ball.Y] = new Core.NewModels.Ball(ball.X, ball.Y);
                    map.UpdateMap();
                    currentDirectionPlayer = Direction.Stop;
                    sw.Reset();
                    changeWall = false;
                    if (_score == _total)
                    {
                        time.StartTimeChecking();
                        user.Record = time.stopwatch.Elapsed.ToString();
                        await _userService.UpdateUser(user, user.Id);
                        Console.Clear();
                        Console.SetCursorPosition(50, 30);
                        Console.WriteLine($"You won! your record: ${user.Record}");
                        break;
                    }
                }
            }
            else if (Console.ReadKey(true).Key == ConsoleKey.D2)
            {
                Console.WriteLine("Ok...");
            }
            else if(Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Console.WriteLine("It's not right button, but ok, you won (Easter egg for Vitaliy Nikolaevich)");
            }
            else
            {
                Console.WriteLine("Bruh, learn how to read");
            }
        }

        private Direction FrameTick(Direction currentDirection, Core.NewModels.Player player)
        {
            var (dx, dy) = directions[currentDirection];
            foreach (var item in map.map)
            {
                if(player.X + dx == item.X && player.Y + dy == item.Y &&(item is Wall || item is EnergyBall))
                {
                    return Direction.Stop ;
                }
                else if (player.X == 0 || player.Y == 0 || player.X + 1== map.map.GetLength(0) || player.Y + 1 == map.map.GetLength(1))
                {
                    return ChangeDirection(currentDirection);
                }
            }
            return currentDirection;
        }

        private Direction FrameTickBall(Direction dir, Core.NewModels.Ball ball)
        {
            var (dx, dy) = directions[dir];
            if (ball.X + 1 == map.map.GetLength(0) || ball.Y + 1 == map.map.GetLength(1) || ball.X == 0  || ball.Y == 0)
            {
                return ChangeDirection(dir);
            }
            foreach (var item in map.map)
            {
                if (ball.X + dx == item.X && ball.Y + dy == item.Y && (item is EnergyBall))
                {
                    _score++;
                    return dir;
                }

                if (ball.X + dx == item.X && ball.Y + dy == item.Y && (item is Wall))
                {
                    return ChangeDirection(dir);
                }
                if(ball.X + dx == item.X && ball.Y + dy == item.Y && (item is Core.NewModels.Player))
                {
                    return ChangeDirectionWithPlayer(dir, player);
                }
            }
            return dir;
        }

        private Direction ChangeDirectionWithPlayer(Direction dir, Core.NewModels.Player player)
        {

            var vertical = dir == Direction.Up || dir == Direction.Down;
            int delta;
            delta = vertical ? 1 : -1;
            if (player.reverseSlash)
            {
                delta *= -1;
            }

            return (Direction)(((int)dir + delta) % 4);
        }

        private Direction ChangeDirection(Direction dir)
        {
            return (Direction)(((int)dir + 2) % 4);
        }
    }

}
