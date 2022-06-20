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
        public const char pixel = '@';
        public Player(int x, int y, string type = "player") : base(x, y, type)
        {
            X = x;
            Y = y;
            ElementType = type;
        }
        public void Move(Direction direction, bool changeWall)
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
