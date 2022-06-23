using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public static class DirectionsDictionary
    {
        public static Dictionary<Direction, (int, int)> directions = new Dictionary<Direction, (int, int)>();

        static DirectionsDictionary()
        {
            directions.Add(Direction.Right, (1, 0));
            directions.Add(Direction.Left, (-1, 0));
            directions.Add(Direction.Up, (0, -1));
            directions.Add(Direction.Down, (0, 1));
            directions.Add(Direction.Stop, (0, 0));
        }
    }
}
