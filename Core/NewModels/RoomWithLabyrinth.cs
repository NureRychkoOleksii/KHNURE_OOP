using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class RoomWithLabyrinth
    {
        public List<BaseElement> room = new List<BaseElement>();
        public (int, int) doorCords = (0, 0);
        public (int, int) reverseDoorCords = (0, 0);
        Random random = new Random();

        public RoomWithLabyrinth(ref BaseElement[,] map, int location, int door)
        {
            int coords = 10;
            for (int i = location - 1; i < location + 7; i++)
            {
                for (int j = location - 1; j < location + 6; j++)
                {
                    if (i < location ||  i > location +5)
                    {
                        map[i + coords, j] = new Empty(i + coords, j);
                        continue;
                    }

                    if ((i == location) || (i == location + 5) || j == location + 5 || j == location - 1)
                    {
                        if (i == location)
                        {
                            if (j - door== location)
                            {
                                map[i + coords, j] = new Empty(i + coords, j);
                                doorCords = (i + coords, j);
                                reverseDoorCords = (i + coords + 5, j);
                                continue;
                            }
                            map[i + coords, j] = new Wall(i + coords, j);
                            continue;
                        }
                        map[i + coords, j] = new Wall(i + coords, j);
                        continue;
                    }
                    if (j - door == location + 1)
                    {
                        if (i >= location + 3)
                        {
                            map[i + coords, j] = new Empty(i + coords, j);
                            continue;
                        }
                        else
                        {
                            map[i + coords, j] = new Wall(i + coords, j);
                            continue;
                        }
                    }
                    int q = random.Next(100);
                    map[i + coords, j] = q switch
                    {
                        <= 25 => new EnergyBall(i + coords, j),
                        _ => new Empty(i + coords, j),
                    };
                    BaseElement element = q switch
                    {
                        <= 25 => new EnergyBall(i + coords, j),
                        _ => new Empty(i + coords, j),
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
            if(!res)
            {
                map[reverseDoorCords.Item1, reverseDoorCords.Item2] = new Empty(reverseDoorCords.Item1, reverseDoorCords.Item2);
            }
        }
    }
}
