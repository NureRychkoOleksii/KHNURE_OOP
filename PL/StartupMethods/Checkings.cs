using BLL.Services;
using Core.Models;
using Core.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.StartupMethods
{
    public class Checkings
    {
        public Direction FrameTick(Direction currentDirection, Core.NewModels.Player player, Map map)
        {
            var (dx, dy) = DirectionsDictionary.directions[currentDirection];
            foreach (var item in map.map)
            {
                if (player.X + dx == item.X && player.Y + dy == item.Y && (item is Wall || item is EnergyBall))
                {
                    return Direction.Stop;
                }
                else if (player.X == 0 || player.Y == 0 || player.X + 1 == map.map.GetLength(0) || player.Y + 1 == map.map.GetLength(1))
                {
                    return ChangeDirection(currentDirection);
                }
            }
            return currentDirection;
        }

        public Direction FrameTickBall(Direction dir, Core.NewModels.Ball ball, Map map, Core.NewModels.Player player, ref int _score)
        {
            var (dx, dy) = DirectionsDictionary.directions[dir];
            if (ball.X + 1 == map.map.GetLength(0) || ball.Y + 1 == map.map.GetLength(1) || ball.X == 0 || ball.Y == 0)
            {
                return ChangeDirection(dir);
            }
            foreach (var item in map.map)
            {
                if (ball.X + dx == item.X && ball.Y + dy == item.Y && (item is EnergyBall))
                {
                    _score++;
                    return dir;
                }

                if (ball.X + dx == item.X && ball.Y + dy == item.Y && (item is Wall))
                {
                    return ChangeDirection(dir);
                }
                if (ball.X + dx == item.X && ball.Y + dy == item.Y && (item is Core.NewModels.Player))
                {
                    return ChangeDirectionWithPlayer(dir, player);
                }
            }
            return dir;
        }

        public Direction ChangeDirectionWithPlayer(Direction dir, Core.NewModels.Player player)
        {

            var vertical = dir == Direction.Up || dir == Direction.Down;
            int delta;
            delta = vertical ? 1 : -1;
            if (player.reverseSlash)
            {
                delta *= -1;
            }

            return (Direction)(((int)dir + delta) % 4);
        }

        public Direction ChangeDirection(Direction dir)
        {
            return (Direction)(((int)dir + 2) % 4);
        }
    }
}
