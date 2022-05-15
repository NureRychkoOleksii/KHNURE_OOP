using Lab1Rychko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko
{
    class Movement
    {
        public Direction ReadMovement(Direction currentDirection)
        {
            if (!Console.KeyAvailable)
            {
                return currentDirection;
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            //Dictionary<Direction, string> lst = new Dictionary<Direction, string>();

            //Console.WriteLine($"up : {lst.Where(x => x.Key == Direction.Up).FirstOrDefault().Value}");

            switch(key)
            {
                case ConsoleKey.UpArrow:
                    currentDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    currentDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    currentDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    currentDirection = Direction.Right;
                    break;
                case ConsoleKey.Tab:
                    currentDirection = Direction.ChangeWall;
                    break;
                default:
                    currentDirection = Direction.Stop;
                    break;
            }

            return currentDirection;
        }
    }
}
