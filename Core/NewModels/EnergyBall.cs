using System;

namespace Core.NewModels
{
    public class EnergyBall : BaseElement
    {
        public const char pixel = '@';

        public EnergyBall(int x, int y, string type = "energyBall") : base(x, y, type)
        {
            X = x;
            Y = y;
            ElementType = type;
        }
    }
}
