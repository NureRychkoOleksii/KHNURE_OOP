using Core.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Methods
{
    public class Methods
    {
        public void DetermineElements(ref Core.NewModels.Player player, ref Core.NewModels.Ball ball, Map map, ref int _total)
        {
            foreach (var i in map.map)
            {
                if (i is Core.NewModels.Player)
                {
                    player = (Core.NewModels.Player)i;
                }
                else if (i is Core.NewModels.Ball)
                {
                    ball = (Core.NewModels.Ball)i;
                }
                else if (i is EnergyBall)
                {
                    _total++;
                }
            }
        }
    }
}
