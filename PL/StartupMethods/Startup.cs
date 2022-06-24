using System;
using System.Diagnostics;
using BLL.Services;
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
        Core.NewModels.Player player = new Core.NewModels.Player(0,0);
        Core.NewModels.Ball ball = new Core.NewModels.Ball(0,0);
        private int _score = 0;
        private int _total = 0;
        ConsoleGraphic graphic = new ConsoleGraphic();
        public Startup(IUserService service)
        {
            _userService = service;
        }
        private int _frameRate = 50;

        private readonly Map map= new Map();
        private readonly Checkings _check = new Checkings();

        public async Task StartGame()
        {
            BaseElement.DrawElement += graphic.Draw;
            Console.SetWindowSize(150, 100);
            Console.SetBufferSize(150, 100);
            Console.SetWindowSize(100, 60);
            Console.SetBufferSize(100, 60);
            Direction currentDirection = Direction.Right;
            Direction currentDirectionPlayer = Direction.Stop;
            var oldMovementPlayer = currentDirectionPlayer;
            var movement = new Movement();
            var time = new TimeCheck();
            bool changeWall = false;
            var menu = new DrawMainMenu();
            menu.DrawMenu();

            var login = new DrawLogin();
            if (Console.ReadKey(true).Key == ConsoleKey.D1)
            {
                var user = await login.Login(_userService);
                map.CreateMap();
                DetermineElements(ref player, ref ball);

                Console.ReadKey();
                Console.CursorVisible = false;
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
                    currentDirection = _check.FrameTickBall(currentDirection, ref ball, map, player, ref _score);
                    currentDirectionPlayer = _check.FrameTick(currentDirectionPlayer, player,map);
                    if (currentDirectionPlayer != Direction.Stop)
                    {
                        player.Move(currentDirectionPlayer);
                        map[x, y] = new Empty(x, y);
                        map[player.X, player.Y] = new Core.NewModels.Player(player.X, player.Y) { reverseSlash = player.reverseSlash };
                    }
                    if (changeWall)
                    {
                        var temp = (Core.NewModels.Player)map[player.X, player.Y];
                        temp.reverseSlash = !temp.reverseSlash;
                        player.reverseSlash = !player.reverseSlash;
                    }
                    ball.Move(currentDirection);
                    map[ballX, ballY] = new Empty(ballX, ballY);
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
