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
            isHorizontal = false;
        }
        public void Move(Direction direction)
        {
            Clear(X,Y);

            var (dx, dy) = DirectionsDictionary.directions[direction];
            X += dx;
            Y += dy;
        }

    }
}
