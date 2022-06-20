using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class Ball : BaseElement
    {
        public Ball(int x, int y, string type = "ball") : base(x, y, type)
        {
            X = x;
            Y = y;
            ElementType = type;
        }
        public void Move(Direction direction, bool eat = false)
        {
            Clear(X,Y);
            var tempDir = direction switch
            {
                Direction.Right => X+=1,
                Direction.Left => X -= 1,
                Direction.Up => Y -= 1,
                Direction.Down => Y += 1,
            };
        }
    }
}
