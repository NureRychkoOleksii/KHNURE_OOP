using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class RoomSpawner
    {
        private Random _random = new Random();

        private int _location;

        private int _x;

        private int _y;

        private string _next = "";

        private string _previous = "left";

        public RoomSpawner(ref BaseElement[,] map)
        {
            int k = 0;
            _location = _random.Next(20, 40);
            _x = _location;
            _y = _location;
            while(k <= 4)
            {
                Update(ref map);
                k++;
            }
        }

        private void Update(ref BaseElement[,] map)
        {
            GetNextRoom();
            Room.Create(ref map, _x, _y, _next, _previous);
            _previous = _next;
            ChangeLocation();
        }

        public void GetNextRoom()
        {
            _next = Room.GetNextRoom(_previous);
        }


        public void ChangeLocation()
        {
            var (dx, dy) = Room._locations[_next];
            _x += dx;
            _y += dy;
        }
    }
}
