using System;
using System.Drawing;

namespace Core.NewModels
{
    public class BaseElement
    {
        public static event EventHandler DrawElement;
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
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    Console.SetCursorPosition(X * 2 + x, Y * 2 + y);
                    Console.Write(' ');
                }
            }
        }

    }
}
