
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko.Models
{
    class Items
    {
        public Pixel GenerateWall()
        {
            Pixel wall;

            Random rnd = new Random();

            wall = new Pixel(rnd.Next(1, 25), rnd.Next(1, 15), ConsoleColor.Green);

            return wall;
        }

        public Pixel GenerateEnergyBall(Ball ball)
        {
            Pixel enerBall;

            Random rnd = new Random();

            do
            {
                enerBall = new Pixel(rnd.Next(1, 28), rnd.Next(1, 18), ConsoleColor.Green);
            } while (ball.BallPixel.X == enerBall.X && ball.BallPixel.Y == enerBall.Y);

            return enerBall;
        }
    }
}
