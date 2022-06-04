using Lab1Rychko.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab1Rychko.StartupMethods
{
    class Startup
    {
        private const int _mapWidth = 60;
        private const int _mapHeight = 40;

        private const int _screenWidth = _mapWidth * 2;
        private const int _screenHeight = _mapHeight * 2;

        private int _frameRate = 200;

        private readonly ConsoleMethods _console= new ConsoleMethods();
        private readonly DrawMenu _drawMenu = new DrawMenu();

        public void StartGame()
        {
            _console.SetConsole(_screenWidth, _screenHeight);
            var menu = new DrawMainMenu();
            menu.DrawMenu();
            if (Console.ReadKey(true).Key == ConsoleKey.D1)
            {
                Console.Clear();
                _drawMenu.DrawMenuConsole();
                Console.ReadKey();
                Console.Clear();
                Console.CursorVisible = false;

                var drawBorder = new DrawBorder(_mapWidth, _mapHeight);
                var music = new Music();
                var tp = new Teleport(new Random().Next(1, 55), new Random().Next(5, 35));
                var timeWatch = new TimeCheck();

                var ball = new Ball(10, 5);

                var item = new Items();
                var items = new List<Pixel>();
                var walls = new List<Pixel>();
                var player = new Wall(8, 4);

                _console.DrawItems(drawBorder, music, tp, out items, out walls, player, ball, item);

                var count = items.Count;

                int score = 0;

                var movement = new Movement();

                var currentDirection = Direction.Right;
                var currentDirectionWall = Direction.Stop;

                Stopwatch sw = new Stopwatch();

                timeWatch.StartTimeChecking();
                while (true)
                {
                    sw.Restart();
                    var oldMovementWall = currentDirectionWall;
                    var oldMovement = currentDirection;
                    bool changeWall = false;

                    while (sw.ElapsedMilliseconds <= _frameRate)
                    {
                        if (currentDirectionWall == oldMovementWall)
                        {
                            currentDirectionWall = movement.ReadMovement(currentDirectionWall, ref changeWall);
                        }
                    }
                    player = _console.PlayerCheckings(player, ref ball, ref currentDirection, ref currentDirectionWall, ref walls, ref items);
                    ball = _console.BallCheckings(ball, ref items, ref score, ref currentDirection, ref walls, ref tp);
                    ball.Move(currentDirection);
                    player.Move(currentDirectionWall, changeWall);
                    changeWall = false;
                    currentDirectionWall = Direction.Stop;
                    if (score == count)
                    {
                        break;
                    }
                }
                ball.Clear();
                player.Clear();
                tp.Clear();
                foreach (var i in walls)
                {
                    i.Clear();
                }
                foreach (var i in items)
                {
                    i.Clear();
                }

                Console.SetCursorPosition(_screenWidth / 3, _screenHeight / 3);

                timeWatch.StopTimeChecking();

                Console.Write($"Game over, your score is {score}");

                Console.ReadKey();
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
    }

}
