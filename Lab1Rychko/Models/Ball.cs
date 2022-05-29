using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko.Models
{
    class Ball : DrawClass
    {
        private const ConsoleColor _color = ConsoleColor.Blue;

        public Pixel BallPixel { get; set; }

        public Ball(int initialX, int initialY)
        {
            BallPixel = new Pixel(initialX, initialY, _color, 2);
        }

        public override void Draw()
        {
            BallPixel.Draw();
        }

        public override void Clear()
        {
            BallPixel.Clear();
        }

        public void Move(Direction direction, bool eat = false)
        {
            Clear();
            BallPixel = direction switch
            {
                Direction.Right => new Pixel(BallPixel.X + 1, BallPixel.Y, _color),
                Direction.Left => new Pixel(BallPixel.X - 1, BallPixel.Y, _color),
                Direction.Up => new Pixel(BallPixel.X, BallPixel.Y - 1, _color),
                Direction.Down => new Pixel(BallPixel.X, BallPixel.Y + 1, _color),
                _ => BallPixel
            };
            Draw();
        }

    }
}
