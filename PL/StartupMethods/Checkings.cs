using BLL.Services;
using Core.Models;
using Core.NewModels;

namespace PL.StartupMethods
{
    public class Checkings
    {
        public Direction FrameTick(Direction currentDirection, Core.NewModels.Player player, Map map)
        {
            var (dx, dy) = DirectionsDictionary.directions[currentDirection];
            foreach (var item in map.map)
            {
                var condition = player.X + dx == item.X && player.Y + dy == item.Y;
                if (condition && (item.isStopping || item.isCollecting))
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

        public Direction FrameTickBall(Direction dir, ref Core.NewModels.Ball ball, Map map, Core.NewModels.Player player, ref int _score)
        {
            var (dx, dy) = DirectionsDictionary.directions[dir];
            if (ball.X + 1 == map.map.GetLength(0) || ball.Y + 1 == map.map.GetLength(1) || ball.X == 0 || ball.Y == 0)
            {
                return ChangeDirection(dir);
            }
            foreach (var item in map.map)
            {
                if (ball.X + dx == item.X && ball.Y + dy == item.Y)
                {
                    if(item.isStopping && item.isHorizontal)
                    {
                        return ChangeDirection(dir);
                    }    
                    else if(!item.isHorizontal)
                    {
                        int ballX = ball.X;
                        int ballY = ball.Y;
                        map[ballX, ballY] = new Empty(ballX, ballY);
                        map[ball.X, ball.Y] = new Core.NewModels.Ball(ball.X, ball.Y);
                        ball.X += dx;
                        ball.Y += dy;
                        return ChangeDirectionWithPlayer(dir, player);
                    }
                    else if(item.isCollecting)
                    {
                        _score++;
                        return dir;
                    }

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
