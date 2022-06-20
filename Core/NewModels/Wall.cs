using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class Wall : BaseElement
    {
        public const char pixel = '#';
        public Wall(int x, int y, string type = "wall") : base(x, y, type)
        {
            X = x;
            Y = y;
            ElementType = type;
        }
    }
}
