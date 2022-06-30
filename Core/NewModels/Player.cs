using Core.Models;
using System;

namespace Core.NewModels
{
    public class Player : BaseElement
    {
        public bool reverseSlash = false;
        public Player(int x, int y) : base(x, y)
        {
            isStopping = true;
            isAngleChanging = true;
        }
        public void Move(Direction direction)
        {
            if(direction == Direction.Stop)
            {
                return;
            }
            Clear(X,Y);

            var (dx, dy) = DirectionsDictionary.directions[direction];
            X += dx;
            Y += dy;
        }

        public void Action(ref Map map, Direction currentDirectionPlayer, bool changeWall = false)
        {
            int x = this.X, y = this.Y;
            this.Move(currentDirectionPlayer);
            map[x, y] = new Empty(x, y);
            map[this.X, this.Y] = new Core.NewModels.Player(this.X, this.Y) { reverseSlash = changeWall ? !this.reverseSlash : this.reverseSlash };
        }


    }
}
