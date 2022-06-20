using System;
using Core.Models;

namespace BLL
{
    public class Movement
    {
        public Direction ReadMovement(Direction currentDirection, ref bool changeWall)
        {
            if (!Console.KeyAvailable)
            {
                return currentDirection;
            }

            ConsoleKey key = Console.ReadKey(true).Key;

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
                    currentDirection = Direction.Stop;
                    changeWall = true;
                    break;
                default:
                    currentDirection = Direction.Stop;
                    break;
            }

            return currentDirection;
        }
    }
}
