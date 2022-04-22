using Lab1Rychko.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko
{
    class Startup
    {
        private const int _mapWidth = 30;
        private const int _mapHeight = 20;

        private const int _screenWidth = _mapWidth * 2;
        private const int _screenHeight = _mapHeight * 2;

        private int _frameRate = 200;

        public void StartGame()
        {
            Console.SetWindowSize(200, 100);
            Console.SetBufferSize(200, 100);
            var drawMenu = new DrawMenu();
            drawMenu.DrawMenuConsole();
            Console.ReadKey();
            Console.Clear();
            Console.SetWindowSize(_screenWidth, _screenHeight);
            Console.SetBufferSize(_screenWidth, _screenHeight);
            Console.CursorVisible = false;

            var drawBorder = new DrawBorder(_mapWidth, _mapHeight);

            drawBorder.Draw();

            var ball = new Ball(10,5);

            var item = new Items();

            var wall1 = item.GenerateWall();
            wall1.DrawWall();
            var wall2 = item.GenerateWall();
            wall2.DrawWall();
            var item1 = item.GenerateEnergyBall(ball);
            item1.DrawBall();
            var item2 = item.GenerateEnergyBall(ball);
            item2.DrawBall();

            var items = new List<Pixel>() { item1, item2 };
            var count = items.Count;
            var walls = new List<Pixel>() { wall1, wall2 };

            var wall = new Wall(8,4);
            wall.DrawSlash();

            int score = 0;

            var movement = new Movement();

            var currentDirection = Direction.Right;
            var currentDirectionWall = Direction.Stop;

            Stopwatch sw = new Stopwatch();

            while (true)
            {
                sw.Restart();
                var oldMovementWall = currentDirectionWall;
                var oldMovement = currentDirection;

                while (sw.ElapsedMilliseconds <= _frameRate)
                {
                    if (currentDirectionWall == oldMovementWall)
                    {
                        currentDirectionWall = movement.ReadMovement(currentDirectionWall);
                    }
                }

                if(wall.WallPixel.X == ball.BallPixel.X && wall.WallPixel.Y == ball.BallPixel.Y)
                {
                   currentDirection = ChangeDirectionWalls(currentDirection, wall.SlashWall);
                }

                var itemBall = items.Any(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y);

                if (itemBall)
                {
                    score++;
                    items.Remove(items.Where(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y).FirstOrDefault());
                    ball.Move(currentDirection);
                }
                else if((walls.Any(p => p.X - 1 == ball.BallPixel.X) || walls.Any(p => p.X + 1 == ball.BallPixel.X) || walls.Any(p => p.X == ball.BallPixel.X))  && (walls.Any(p => p.Y - 1 == ball.BallPixel.Y) || walls.Any(p => p.Y + 1 == ball.BallPixel.Y) || walls.Any(p => p.Y == ball.BallPixel.Y)))
                {
                    currentDirection = ChangeDirection(currentDirection);
                }

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

                ball.Move(currentDirection);

                if(wall.WallPixel.X == _mapWidth - 2 || wall.WallPixel.X == 1 || wall.WallPixel.Y == 1 || wall.WallPixel.Y == _mapHeight - 2) 
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
                wall.Move(currentDirectionWall);
                currentDirectionWall = Direction.Stop;
                if(score == count)
                {
                    break;
                }
            }
            Console.Write($"Game over, your score is {score}");

            Console.ReadKey();
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
                    if(direction == Direction.Right)
                    {
                        direction = Direction.Up;
                    }
                    else if(direction == Direction.Left){
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
