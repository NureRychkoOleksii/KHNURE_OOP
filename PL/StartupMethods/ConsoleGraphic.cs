using Core.NewModels;
using System;
namespace Console.StartupMethods
{
    public class ConsoleGraphic
    {
        public void Draw(object? sender, EventArgs e)
        {
            if (sender is not BaseElement pixel)
            {
                return;
            }

            var symbol = pixel switch
            {
                Empty => " ",
                Player => ((Player)pixel).reverseSlash ? "\\" : "/",
                EnergyBall => "%",
                Wall => "#",
                Ball => "█",
                _ => "?"
            };

            var color = pixel switch
            {
                Player => DetermineSkin((Player)pixel),
                Wall => ConsoleColor.White,
                EnergyBall => ConsoleColor.Green,
                Ball => ConsoleColor.Blue,
                _ => ConsoleColor.Black
            };
            System.Console.ForegroundColor = color;
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    System.Console.SetCursorPosition(pixel.X * 2 + x, pixel.Y * 2 + y);
                    System.Console.Write(symbol);
                }
            }
        }

        private ConsoleColor DetermineSkin(Player player)
        {
            var res = ConsoleColor.Red;
            switch (player.Skin)
            {
                case "yellow":
                    res = ConsoleColor.Yellow;
                    break;
                case "purple":
                    res = ConsoleColor.Cyan;
                    break;
                default:
                    break;
            }

            return res;
        }

        public void Clear(object? sender, EventArgs e)
        {
            if (sender is not BaseElement pixel)
            {
                return;
            }

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    System.Console.SetCursorPosition(pixel.X * 2 + x, pixel.Y * 2 + y);
                    System.Console.Write(' ');
                }
            }
        }
    }
}
