using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using BLL;

namespace PL.StartupMethods
{
    class ConsoleMethods
    {
        private const int _mapWidth = 60;
        private const int _mapHeight = 40;

        private Dictionary<Direction, string> directions = new Dictionary<Direction, string>();

        public ConsoleMethods()
        {
            directions.Add(Direction.Right, "x-1");
            directions.Add(Direction.Left, "x+1");
            directions.Add(Direction.Up, "y-1");
            directions.Add(Direction.Down, "y+1");
        }

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

        public void DrawItems(DrawBorder border, Music music, Teleport tp, out List<Pixel> itemsList, out List<Pixel> walls, Player player, Ball ball, Items item) 
        {
            item = new Items();
            itemsList = new List<Pixel>();
            ItemsClass items = new ItemsClass(itemsList);
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
                items[(int)templateItem.X, (int)templateItem.Y]= templateItem;
            }
            itemsList = items.items;
            player.DrawSlash();
        }

        public Player PlayerCheckings(Player player, ref Ball ball, ref Direction currentDirection, ref Direction currentDirectionWall, ref List<Pixel> walls, ref List<Pixel> items)
        {
            if (player.WallPixel.X == ball.BallPixel.X && player.WallPixel.Y == ball.BallPixel.Y)
            {
                currentDirection = ChangeDirectionWalls(currentDirection, player.SlashWall);
            }
            if ((player.WallPixel.X == _mapWidth - 2 || player.WallPixel.X == 1 || player.WallPixel.Y == 1 || player.WallPixel.Y == _mapHeight - 2) ||
                        ComparePlayerAndWalls(player, walls) || ComparePlayerAndBalls(player, items))
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
            var currDirCopy = currentDirection;

            if (items.Any(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y))
            {
                score++;
                items.Where(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y).FirstOrDefault().Clear();
                items.Remove(items.Where(p => p.X == ball.BallPixel.X && p.Y == ball.BallPixel.Y).FirstOrDefault());
                ball.Move(currentDirection);
            }

            foreach(var p in walls)
            {
                if(this.directions.Any(d => (d.Key == currDirCopy) && CompareBallCoordinates(ball, d.Value, p)))
                {
                    currentDirection = ChangeDirection(currentDirection);
                    break;
                }
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

        private bool CompareBallCoordinates(Ball ball, string coordinate, Pixel wall)
        {
            switch(coordinate)
            {
                case "x-1":
                    return wall.X - 1 == ball.BallPixel.X && wall.Y == ball.BallPixel.Y;
                case "y+1":
                    return wall.X == ball.BallPixel.X && wall.Y - 1 == ball.BallPixel.Y;
                case "x+1":
                    return wall.X + 1 == ball.BallPixel.X && wall.Y == ball.BallPixel.Y;
                case "y-1":
                    return wall.X == ball.BallPixel.X && wall.Y + 1 == ball.BallPixel.Y;
            }
            return false;
        }

        private bool ComparePlayerAndWalls(Player player, List<Pixel> walls)
        {
            bool result = false;
            var tempWallsY = walls.Where(w => w.Y == player.WallPixel.Y);
            var tempWallsX = walls.Where(w => w.X == player.WallPixel.X);
            if(tempWallsX != null)
            {
               result = tempWallsX.Any(w => w.Y - 1 == player.WallPixel.Y || w.Y + 1 == player.WallPixel.Y);
            }
            if (tempWallsY != null)
            {
                if(result)
                {
                    return result;
                }
                result = tempWallsY.Any(w => w.X - 1 == player.WallPixel.X || w.X + 1 == player.WallPixel.X);
            }

            return result;
        }

        private bool ComparePlayerAndBalls(Player wall, List<Pixel> items)
        {
            bool result = false;
            var tempRes = false;
            var tempWallsY = items.Where(w => w.Y == wall.WallPixel.Y);
            var tempWallsX = items.Where(w => w.X == wall.WallPixel.X);
            if (tempWallsX != null)
            {
                tempRes = tempWallsX.Any(w => w.Y - 1 == wall.WallPixel.Y || w.Y + 1 == wall.WallPixel.Y);
            }
            if (tempWallsY != null)
            {
                if (tempRes)
                {
                    return tempRes;
                }
                result = tempWallsY.Any(w => w.X - 1 == wall.WallPixel.X || w.X + 1 == wall.WallPixel.X);
            }

            return result;
        }

        //if ((player.WallPixel.X == _mapWidth - 2 || player.WallPixel.X == 1 || player.WallPixel.Y == 1 || player.WallPixel.Y == _mapHeight - 2) ||
        //                walls.Any(p => p.X - 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y - 1 == player.WallPixel.Y)
        //                                   || (p.X + 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y + 1 == player.WallPixel.Y)))
        //                || items.Any(p => (p.X - 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y - 1 == player.WallPixel.Y))
        //                                   || (p.X + 1 == player.WallPixel.X && p.Y == player.WallPixel.Y || (p.X == player.WallPixel.X && p.Y + 1 == player.WallPixel.Y))))
        //    {
    }
}
