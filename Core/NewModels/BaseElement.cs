using System;
using System.Drawing;

namespace Core.NewModels
{
    public class BaseElement
    {
        public static event EventHandler DrawElement;
        public static event EventHandler ClearElement;
        public int X { get; set; }
        public int Y { get; set; }

        public bool isStopping = false;

        public bool isHorizontal = true;

        public bool isCollecting = false;


        public BaseElement(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void Draw()
        {
            DrawElement?.Invoke(this, EventArgs.Empty);
        }


        public virtual void Clear(int X, int Y)
        {
            ClearElement?.Invoke(this, EventArgs.Empty);
        }

    }
}
