using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class BigRoom
    {
        public List<BaseElement> room = new List<BaseElement>();
        public (int, int) doorCords = (0, 0);
        public (int, int) reverseDoorCords = (0, 0);
        Random random = new Random();

        public BigRoom(ref BaseElement[,] map, int location, int door, int additionalLocation = 0)
        {
            for (int i = location - 1; i < location + 15; i++)
            {
                for (int j = location - 1; j < location + 8; j++)
                {
                    if (i < location || i > location + 13)
                    {
                        map[i, j + additionalLocation] = new Empty(i, j + additionalLocation);
                        continue;
                    }

                    if ((i == location) || (i == location + 13) || j == location + 6 || j == location - 1)
                    {
                        if (j == location-1)
                        {
                            if (i - door == location)
                            {
                                map[i, j + additionalLocation] = new Empty(i, j + additionalLocation);
                                doorCords = (i, j + additionalLocation);
                                reverseDoorCords = (i + 13, j + additionalLocation);
                                continue;
                            }
                            map[i, j + additionalLocation] = new Wall(i, j + additionalLocation);
                            continue;
                        }
                        map[i, j + additionalLocation] = new Wall(i, j + additionalLocation);
                        continue;
                    }
                    int q = random.Next(100);
                    map[i, j + additionalLocation] = q switch
                    {
                        <= 25 => new EnergyBall(i, j + additionalLocation),
                        _ => new Empty(i, j + additionalLocation),
                    };
                    BaseElement element = q switch
                    {
                        <= 25 => new EnergyBall(i, j + additionalLocation),
                        _ => new Empty(i, j + additionalLocation),
                    };
                    room.Add(element);
                }
            }
        }

        public void OpenDoor(ref BaseElement[,] map)
        {
            var res = false;
            foreach (var i in room)
            {
                if (i is not Empty)
                {
                    res = true;
                    break;
                }
            }
            if (!res)
            {
                map[reverseDoorCords.Item1, reverseDoorCords.Item2] = new Empty(reverseDoorCords.Item1, reverseDoorCords.Item2);
            }
        }
    }
}
