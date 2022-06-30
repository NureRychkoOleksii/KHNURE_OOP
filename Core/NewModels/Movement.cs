using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class Movement
    {
        public void ProcessKey(ref Direction currentDirection, EventHandler function)
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
                    function.Invoke(this, EventArgs.Empty);
                    break;
                default:
                    currentDirection = Direction.Stop;
                    break;
            }
        }
    }
}
