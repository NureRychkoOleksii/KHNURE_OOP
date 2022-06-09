
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Items
    {
        public Pixel Wall { get; set; }


        public Pixel GenerateWall()
        {
            Random rnd = new Random();

            Wall = new Pixel(rnd.Next(1, 55), rnd.Next(5, 35), ConsoleColor.White);

            return Wall;
        }

        public Pixel GenerateEnergyBall(Ball ball)
        {
            Pixel enerBall;

            Random rnd = new Random();

            do
            {
                enerBall = new Pixel(rnd.Next(1, 55), rnd.Next(5, 35), ConsoleColor.Green);
            } while (ball.BallPixel.X == enerBall.X && ball.BallPixel.Y == enerBall.Y);

            return enerBall;
        }
    }
}
