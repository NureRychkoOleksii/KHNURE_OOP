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
        Direction currentDirection = Direction.Right;
        Direction currentDirectionPlayer = Direction.Stop;
        private int _score = 0;
        private int _total = 0;
        ConsoleGraphic graphic = new ConsoleGraphic();
        private User user = new User();
        private TimeCheck time;
        public Startup(IUserService service)
        {
            _userService = service;
        }
        private int _frameRate = 50;

        private Core.NewModels.Map map= new Core.NewModels.Map();
        private readonly Checkings _check = new Checkings();

        public void StartGame()
        {
            SettingConsole();
            if (Console.ReadKey(true).Key == ConsoleKey.D1)
            {
                var login = new DrawLogin();
                BeforeStart(out user, out time, login);
                while (true)
                {
                    Start();
                    if (_score == _total)
                    {
                        End();
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
        
        private void SettingConsole()
        {
            BaseElement.DrawElement += graphic.Draw;
            BaseElement.ClearElement += graphic.Clear;
            Console.SetWindowSize(140, 100);
            Console.SetBufferSize(300, 350);
            var menu = new DrawMainMenu();
            menu.DrawMenu();
        }
        private void BeforeStart(out User user, out TimeCheck time, DrawLogin login)
        {
            user = login.Login(_userService);
            map.CreateMap();
            DetermineElements(ref player, ref ball);
            Console.ReadKey();
            Console.CursorVisible = false;
            time = new TimeCheck();
            time.StartTimeChecking();
        }

        private void Start()
        {
            bool changeWall = false;
            Stopwatch sw = new Stopwatch();
            CheckTick(ref sw,ref changeWall);
            MakeAction(changeWall);
            map.UpdateMap();
            currentDirectionPlayer = Direction.Stop;
        }

        private void End()
        {
            time.StartTimeChecking();
            user.Record = time.stopwatch.Elapsed.ToString();
            _userService.UpdateUser(user, user.Id);
            Console.Clear();
            Console.SetCursorPosition(50, 30);
            Console.WriteLine($"You won! your record: ${user.Record}");
        }

        private void CheckTick(ref Stopwatch sw, ref bool changeWall)
        {
            sw.Start();
            while (sw.ElapsedMilliseconds <= _frameRate)
            {
                var movement = new Movement();
                movement.ProcessKey(ref currentDirectionPlayer, ref changeWall);
            }
        }

        private void MakeAction(bool changeWall)
        {
            currentDirection = _check.FrameTickBall(currentDirection, ref ball, map, player, ref _score);
            currentDirectionPlayer = _check.FrameTick(currentDirectionPlayer, player, map);
            player.Action(ref map, currentDirectionPlayer, changeWall);
            ball.Action(ref map, currentDirection);
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
