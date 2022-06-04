using Lab1Rychko.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1Rychko.StartupMethods
{
    class ConsoleMethods
    {
        private const int _mapWidth = 60;
        private const int _mapHeight = 40;
        private const int _screenWidth = _mapWidth * 2;
        private const int _screenHeight = _mapHeight * 2;
        private int _frameRate = 200;

        public void SetConsole(int screenWidth, int screenHeight)
        {
            Console.SetWindowSize(150, 100);
            Console.SetBufferSize(150, 100);
            Console.SetWindowSize(screenWidth, screenHeight);
            Console.SetBufferSize(screenWidth, screenHeight);
        }

        public void DrawMenu()
        {
            var menu = new DrawMainMenu();
            menu.DrawMenu();
        }

        public void DrawItems(DrawBorder border, Music music, Teleport tp, out List<Pixel> items, out List<Pixel> walls, Wall player, Ball ball, Items item) 
        {
            item = new Items();
            items = new List<Pixel>();
            walls = new List<Pixel>();

            border.Draw();
            music.Play();
            tp.DrawTp();


            for (int i = 0; i < 10; i++)
            {
                var templateItem = item.GenerateEnergyBall(ball);
                templateItem.DrawBall();
                var templateWall = item.GenerateWall();
                templateWall.DrawWall();
                walls.Add(templateWall);
                items.Add(templateItem);
            }
            player.DrawSlash();
        }

        public Wall PlayerCheckings(Wall player, ref Ball ball, ref Direction currentDirection, ref Direction currentDirectionWall, ref List<Pixel> walls, ref List<Pixel> items)
        {
            if (player.WallPixel.X == ball.BallPixel.X && player.WallPixel.Y == ball.BallPixel.Y)
            {
                currentDirection = ChangeDirectionWalls(currentDirection, player.SlashWall);
            }
            if ((player.WallPixel.X == _mapWidth - 2 || player.WallPixel.X == 1 || player.WallPixel.Y == 1 || player.WallPixel.Y == _mapHeight - 2) ||
                        walls.Any(p => p.X - 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y - 1 == player.WallPixel.Y)
                                           || (p.X + 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y + 1 == player.WallPixel.Y)))
                        || items.Any(p => (p.X - 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y - 1 == player.WallPixel.Y))
                                           || (p.X + 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y + 1 == player.WallPixel.Y))))
            {
                switch (currentDirectionWall)
                {
                    case Direction.Right:
                        currentDirectionWall = Direction.Left;
                        break;
                    case Direction.Left:
                        currentDirectionWall = Direction.Right;
                        break;
                    case Direction.Up:
                        currentDirectionWall = Direction.Down;
                        break;
                    case Direction.Down:
                        currentDirectionWall = Direction.Up;
                        break;
                }
            }
            return player;
        }

        public Ball BallCheckings(Ball ball, ref List<Pixel> items, ref int score, ref Direction currentDirection, ref List<Pixel> walls, ref Teleport tp)
        {
            var itemBall = items.Any(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y);
            var currDirCopy = currentDirection;

            if (itemBall)
            {
                score++;
                items.Where(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y).FirstOrDefault().Clear();
                items.Remove(items.Where(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y).FirstOrDefault());
                ball.Move(currentDirection);
            }

            else if (walls.Any(p => (p.X - 1 == ball.BallPixel.X && p.Y == ball.BallPixel.Y && (currDirCopy == Direction.Right))
                                   || (p.X == ball.BallPixel.X && p.Y - 1 == ball.BallPixel.Y && (currDirCopy == Direction.Down))
                                   || (p.X + 1 == ball.BallPixel.X && p.Y == ball.BallPixel.Y && (currDirCopy == Direction.Left))
                                   || (p.X == ball.BallPixel.X && p.Y + 1 == ball.BallPixel.Y && (currDirCopy == Direction.Up))))
            {
                currentDirection = ChangeDirection(currentDirection);
            }
            currentDirection = currDirCopy;
            if ((ball.BallPixel.X == _mapWidth - 2 || ball.BallPixel.X == 1 || ball.BallPixel.Y == 1 || ball.BallPixel.Y == _mapHeight - 2)
                        || (ball.BallPixel.X == _mapWidth - 1 || ball.BallPixel.X == 0 || ball.BallPixel.Y == 0 || ball.BallPixel.Y == _mapHeight - 1))
            {
                switch (currentDirection)
                {
                    case Direction.Right:
                        currentDirection = Direction.Left;
                        break;
                    case Direction.Left:
                        currentDirection = Direction.Right;
                        break;
                    case Direction.Up:
                        currentDirection = Direction.Down;
                        break;
                    case Direction.Down:
                        currentDirection = Direction.Up;
                        break;
                }
            }
            if (ball.BallPixel.X == tp.TpPixel.X && ball.BallPixel.Y == tp.TpPixel.Y)
            {
                ball.Clear();
                ball.BallPixel.X = new Random().Next(1, 55);
                ball.BallPixel.Y = new Random().Next(5, 35);
                ball.Draw();
                tp.Clear();
                tp.TpPixel.X = 0;
                tp.TpPixel.Y = 0;
            }

            return ball;
        }

        private Direction ChangeDirection(Direction currentDirection)
        {
            var dir = currentDirection;

            switch (currentDirection)
            {
                case Direction.Right:
                    dir = Direction.Left;
                    break;
                case Direction.Left:
                    dir = Direction.Right;
                    break;
                case Direction.Up:
                    dir = Direction.Down;
                    break;
                case Direction.Down:
                    dir = Direction.Up;
                    break;
            }

            return dir;
        }

        private Direction ChangeDirectionWalls(Direction direction, char wall)
        {
            switch (wall)
            {
                case '/':
                    if (direction == Direction.Right)
                    {
                        direction = Direction.Up;
                    }
                    else if (direction == Direction.Left)
                    {
                        direction = Direction.Down;
                    }
                    else if (direction == Direction.Up)
                    {
                        direction = Direction.Right;
                    }
                    else if (direction == Direction.Down)
                    {
                        direction = Direction.Left;
                    }
                    break;
                case '\\':
                    if (direction == Direction.Right)
                    {
                        direction = Direction.Down;
                    }
                    else if (direction == Direction.Left)
                    {
                        direction = Direction.Up;
                    }
                    else if (direction == Direction.Up)
                    {
                        direction = Direction.Left;
                    }
                    else if (direction == Direction.Down)
                    {
                        direction = Direction.Right;
                    }
                    break;

            }

            return direction;
        }
    }
}
