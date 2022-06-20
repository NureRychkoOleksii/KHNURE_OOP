using System;

namespace Core.NewModels
{
    public class BaseElement
    {
        public string ElementType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public BaseElement(int x, int y, string type = "default")
        {
            X = x;
            Y = y;
            ElementType = type;
        }

        public virtual void Draw(int X, int Y, char pixel = ' ', ConsoleColor Color = ConsoleColor.Black)
        {
            Console.ForegroundColor = Color;
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    Console.SetCursorPosition(X * 2 + x, Y * 2 + y);
                    Console.Write(pixel);
                }
            }
        }


        public virtual void Clear(int X, int Y)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    Console.SetCursorPosition(X * 2 + x, Y * 2 + y);
                    Console.Write(' ');
                }
            }
        }

    }
}
