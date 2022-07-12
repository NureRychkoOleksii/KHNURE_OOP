using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class ProcessingKey
    {
        public void ProcessKey(ref Direction currentDirection, EventHandler function, ref BaseElement[,] map, ref User user, Player player)
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            if(key == ConsoleKey.F9)
            {
                map[player.X, player.Y + 1] = user.Inventory.FirstOrDefault() switch
                {
                    Wall => new Wall(player.X,player.Y + 1),
                    Teleport => new Teleport(player.X,player.Y + 1),
                    _ => new Empty(player.X, player.Y + 1)
                };
                user.Inventory.Remove(user.Inventory.FirstOrDefault());
                return;
            }

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

        public Direction ProcessKeyWinForms(string key, EventHandler function)
        {
            switch (key)
            {
                case "Right":
                    return Direction.Right;
                    
                case "Left":
                    return Direction.Left;
                    
                case "Down":
                    return Direction.Down;
                    
                case "Up":
                    return Direction.Up;
                    
                case "Tab":
                    function.Invoke(this, EventArgs.Empty);
                    return Direction.Stop;
                    
            }
            return Direction.Right;
        }
    }
}
