using System;
using System.Diagnostics;
using BLL.Services;
using BLL.Interfaces;
using Core.Models;
using Core.NewModels;
using PL.Services;
using BLL;
using System.Threading.Tasks;
using Core.Methods;

namespace PL.StartupMethods
{
    public class Startup
    {
        private UserService _userService = new UserService();
        Core.NewModels.Player player = new Core.NewModels.Player(0,0);
        Core.NewModels.Ball ball = new Core.NewModels.Ball(0,0);
        Direction currentDirection = Direction.Right;
        Direction currentDirectionPlayer = Direction.Stop;
        private int _score = 0;
        private int _total = 0;
        ConsoleGraphic graphic = new ConsoleGraphic();
        private User user = new User();
        private Methods methods = new Methods();
        private Core.Methods.TimeCheck time;
        private int _frameRate = 50;
        bool changeWall = false;
        EventHandler functionForMovement;

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
            functionForMovement += ChangeWall;
            Console.SetWindowSize(140, 100);
            Console.SetBufferSize(300, 350);
            var menu = new DrawMainMenu();
            menu.DrawMenu();
        }
        private void BeforeStart(out User user, out Core.Methods.TimeCheck time, DrawLogin login)
        {
            user = login.Login(_userService);
            map.CreateMap();
            methods.DetermineElements(ref player, ref ball, map, ref _total);
            Console.ReadKey();
            Console.CursorVisible = false;
            time = new Core.Methods.TimeCheck();
            time.StartTimeChecking();
        }

        private void Start()
        {
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
                var movement = new Core.NewModels.Movement();
                movement.ProcessKey(ref currentDirectionPlayer, functionForMovement);
            }
        }
        
        private void ChangeWall(object sender, EventArgs e)
        {
            changeWall = !changeWall;
        }

        private void MakeAction(bool changeWall)
        {
            currentDirection = _check.FrameTickBall(currentDirection, ref ball, map, player, ref _score);
            currentDirectionPlayer = _check.FrameTick(currentDirectionPlayer, player, map);
            player.Action(ref map, currentDirectionPlayer, changeWall);
            ball.Action(ref map, currentDirection);
        }
    }
}
