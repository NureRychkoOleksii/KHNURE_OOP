using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class Player : BaseElement
    {
        public const char pixel = '/';
        public bool reverseSlash = false;
        public Player(int x, int y) : base(x, y)
        {
        }
        public void Move(Direction direction)
        {
            Clear(X,Y);

            switch (direction)
            {
                case Direction.Right:
                    X += 1;
                    break;
                case Direction.Left:
                    X -= 1;
                    break;
                case Direction.Up:
                    Y -= 1;
                    break;
                case Direction.Down:
                    Y += 1;
                    break;
                case Direction.Stop:
                    break;
            }
        }
    }
}
