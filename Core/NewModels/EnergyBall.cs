using System;

namespace Core.NewModels
{
    public class EnergyBall : BaseElement
    {
        public EnergyBall(int x, int y) : base(x, y)
        {
            isCollecting = true;
        }
    }
}
