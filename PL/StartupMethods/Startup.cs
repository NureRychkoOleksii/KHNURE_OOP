using System;
using System.Diagnostics;
using Core.Models;
using Core.NewModels;
using Console.Services;
using Core.Methods;

namespace Console.StartupMethods
{
    public class Startup
    {
        private UserService _userService = new UserService();
        Core.NewModels.Player player = new Core.NewModels.Player(0,0,"default");
        Core.NewModels.Ball ball = new Core.NewModels.Ball(0,0);
        Direction currentDirection = Direction.Right;
        Direction currentDirectionPlayer = Direction.Stop;
        private int _score = 0;
        private int _total = 0;
        ConsoleGraphic graphic = new ConsoleGraphic();
        private User user = new User();
        private Methods methods = new Methods();
        private TimeCheck time;
        private int _frameRate = 50;
        bool changeWall = false;
        EventHandler functionForMovement;

        private Map map= new Map(50,50);

        public void StartGame()
        {
            SettingConsole();
            if (System.Console.ReadKey(true).Key == ConsoleKey.D1)
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
                    _userService.UpdateUser(ref user, user.Id);
                }
            }
            else if (System.Console.ReadKey(true).Key == ConsoleKey.D2)
            {
                System.Console.WriteLine("Ok...");
            }
            else if (System.Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                System.Console.WriteLine("It's not right button, but ok, you won (Easter egg for Vitaliy Nikolaevich)");
            }
            else
            {
                System.Console.WriteLine("Bruh, learn how to read");
            }
        }
        
        private void SettingConsole()
        {
            BaseElement.DrawElement += graphic.Draw;
            BaseElement.ClearElement += graphic.Clear;
            functionForMovement += ChangeWall;
            System.Console.SetWindowSize(140, 100);
            System.Console.SetBufferSize(300, 350);
            var menu = new DrawMainMenu();
            menu.DrawMenu();
        }
        private void BeforeStart(out User user, out TimeCheck time, DrawLogin login)
        {
            user = login.Login(_userService);
            DrawShop magazine = new DrawShop();
            magazine.Draw(user);
            System.Console.Clear();
            map.CreateMap(user);
            methods.DetermineElements(ref player, ref ball, map, ref _total, user);
            var item = (Core.NewModels.Player)map[player.X, player.Y];
            item.Skin = user.Skin;
            System.Console.ReadKey();
            System.Console.CursorVisible = false;
            time = new TimeCheck();
            time.StartTimeChecking();
        }

        private void Start()
        {
            Stopwatch sw = new Stopwatch();
            CheckTick(ref sw);
            MakeAction(changeWall);
            map.UpdateMap();
            currentDirectionPlayer = Direction.Stop;
        }

        private void End()
        {
            time.StartTimeChecking();
            user.Record = time.stopwatch.Elapsed.ToString();
            _userService.UpdateUser(ref user, user.Id);
            System.Console.Clear();
            System.Console.SetCursorPosition(50, 30);
            System.Console.WriteLine($"You won! your record: ${user.Record}");
        }

        private void CheckTick(ref Stopwatch sw)
        {
            sw.Start();
            while (sw.ElapsedMilliseconds <= _frameRate)
            {
                var processingKey = new ProcessingKey();
                processingKey.ProcessKey(ref currentDirectionPlayer, functionForMovement, ref map.map, ref user, player);
            }
        }
        
        private void ChangeWall(object sender, EventArgs e)
        {
            changeWall = !changeWall;
        }

        private void MakeAction(bool changeWall)
        {
            currentDirection = methods.FrameTickBall(currentDirection, ref ball, map, player, ref _score, ref user.CoinsCount);
            currentDirectionPlayer = methods.FrameTick(currentDirectionPlayer, player, map);
            player.Action(ref map, currentDirectionPlayer, changeWall);
            ball.Action(ref map, currentDirection);
            this.changeWall = false;
        }
    }
}
