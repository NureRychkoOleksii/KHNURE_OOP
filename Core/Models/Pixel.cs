using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Pixel : DrawClass
    {
        private const char _pixelChar = '█';
        private const char _wallChar = '#';
        private const char _enerBallChar = '@';

        public double X { get; set; }

        public double Y { get; set; }

        public ConsoleColor Color { get;  }

        public int PixelSize { get; }

        public Pixel(double x, double y, ConsoleColor color, int pixelSize = 2)
        {
            X = x;
            Y = y;
            Color = color;
            PixelSize = pixelSize;
        }

        public void Draw(char pixel = _pixelChar)
        {
            Console.ForegroundColor = Color;
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((int)X * PixelSize + x, (int)Y * PixelSize + y);
                    Console.Write(pixel);
                }
            }
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((int)X * PixelSize + x, (int)Y * PixelSize + y);
                    Console.Write(_pixelChar);
                }
            }
        }

        public override void Clear()
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((int)X * PixelSize + x, (int)Y * PixelSize + y);
                    Console.Write(' ');
                }
            }
        }

        public void DrawWall(char pixel = _wallChar)
        {
            Console.ForegroundColor = Color;
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((int)X * PixelSize + x, (int)Y * PixelSize + y);
                    Console.Write(pixel);
                }
            }
        }
        public void ClearWall()
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((int)X * PixelSize + x, (int)Y * PixelSize + y);
                    Console.Write(' ');
                }
            }
        }

        public void DrawBall(char pixel = _enerBallChar)
        {
            Console.ForegroundColor = Color;
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((int)X * PixelSize + x, (int)Y * PixelSize + y);
                    Console.Write(pixel);
                }
            }
        }
        public void ClearBall()
        {
            for (int x = 0; x < PixelSize; x++)
            {
                for (int y = 0; y < PixelSize; y++)
                {
                    Console.SetCursorPosition((int)X * PixelSize + x, (int)Y * PixelSize + y);
                    Console.Write(' ');
                }
            }
        }
    }
}
