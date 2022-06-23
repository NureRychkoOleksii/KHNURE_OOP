using System;
using Core.Models;

namespace BLL
{
    public class Movement
    {
        public void ProcessKey(ref Direction currentDirection, ref bool changeWall)
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
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
                    changeWall = !changeWall;
                    break;
                default:
                    currentDirection = Direction.Stop;
                    break;
            }
        }
    }
}
