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
        public Wall(int x, int y) : base(x, y)
        {
            isStopping = true;
        }
    }
}
