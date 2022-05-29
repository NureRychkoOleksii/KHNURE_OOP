using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko.Models
{
    class Teleport
    {
        private const char _tpChar = '&';
        private const ConsoleColor _color = ConsoleColor.Yellow;

        public Pixel TpPixel { get; set; }

        public Teleport(int initialX, int initialY)
        {
            TpPixel = new Pixel(initialX, initialY, _color, 2);
        }

        public void DrawTp()
        {
            TpPixel.Draw(_tpChar);
        }

        public void Clear()
        {
            TpPixel.Clear();
        }
    }
}
