using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class Teleport : BaseElement
    {
        public Teleport(int x, int y) : base(x, y)
        {
            isAngleChanging = false;
            isCollecting = false;
            isStopping = false;
        }
    }
}
