using Lab1Rychko.Models;
using System;

namespace Lab1Rychko
{
    class DrawBorder : DrawClass
    {
        private readonly int _mapWidth;
        private readonly int _mapHeight;
        private const ConsoleColor BorderColor = ConsoleColor.Gray;

        public DrawBorder(int mapWidth, int mapHeight)
        {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
        }

        public override void Draw()
        {
            for (int i = 0; i < _mapWidth; i++)
            {
                new Pixel(i, 0, BorderColor).Draw();
                new Pixel(i, _mapHeight - 1, BorderColor).Draw();
            }

            for (int i = 0; i < _mapHeight; i++)
            {
                new Pixel(0, i, BorderColor).Draw();
                new Pixel(_mapWidth - 1, i, BorderColor).Draw();
            }
        }

        public override void Clear()
        {
            //
        }
    }
}
