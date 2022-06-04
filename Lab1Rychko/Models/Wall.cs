
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko.Models
{
    class Wall
    {
        private const char _wallCharSlash = '/';
        private const char _wallCharBackSlash = '\\';
        private const ConsoleColor _color = ConsoleColor.Red;

        public Pixel WallPixel { get; set; }

        public char SlashWall { get; set; } = _wallCharSlash;

        public Wall(int initialX, int initialY)
        {
            WallPixel = new Pixel(initialX, initialY, _color, 1);
        }

        public void DrawSlash()
        {
            WallPixel.Draw(_wallCharSlash);
        }

        public void DrawBackSlash()
        {
            WallPixel.Draw(_wallCharBackSlash);
        }

        public void Clear()
        {
            WallPixel.Clear();
        }

        public void Move(Direction direction, bool changeWall)
        {
            Clear();

            switch(direction)
            {
                case Direction.Right:
                    WallPixel = new Pixel(WallPixel.X + 1, WallPixel.Y, _color);
                    break;
                case Direction.Left:
                    WallPixel = new Pixel(WallPixel.X - 1, WallPixel.Y, _color);
                    break;
                case Direction.Up:
                    WallPixel = new Pixel(WallPixel.X, WallPixel.Y - 1, _color);
                    break;
                case Direction.Down:
                    WallPixel = new Pixel(WallPixel.X, WallPixel.Y + 1, _color);
                    break;
                case Direction.Stop:
                    WallPixel = WallPixel;
                    break;
            }

            if(changeWall)
            {
                ChangeWall();
            }    

            if (SlashWall == '\\')
            {
                DrawBackSlash();
            }
            else
            {
                DrawSlash();
            }
        }

        private void ChangeWall()
        {
            SlashWall = SlashWall == '/' ? '\\' : '/';
        }
    }
}
