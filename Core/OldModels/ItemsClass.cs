using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class ItemsClass
    {
        public List<Pixel> items;
        public ItemsClass(List<Pixel> items)
        {
            this.items = items;
        }

        public Pixel this[int x,int y]
        {
            get
            {
                return items.Where(p => p.X == x && p.Y == y).FirstOrDefault();
            }
            set
            {
                items.Add(new Pixel(x, y, ConsoleColor.Green));
            }
        }
    }
}
