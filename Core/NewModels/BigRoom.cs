using System;
using System.Collections.Generic;

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
                for (int j = location - 2; j < location + 8; j++)
                {
                    if (i < location || i > location + 13 || j == location - 2)
                    {
                        map[i, j + additionalLocation] = new Empty(i, j + additionalLocation);
                        continue;
                    }

                    if ((i == location) || (i == location + 13) || j == location + 6 || j == location - 1)
                    {
                        if (j == location-1)
                        {
                            if (i - door * 5 == location)
                            {
                                if (additionalLocation < 0)
                                {
                                    doorCords = (i, j + additionalLocation + 7);
                                    map[doorCords.Item1, doorCords.Item2] = new Empty(doorCords.Item1, doorCords.Item2);
                                    reverseDoorCords = (i, j + additionalLocation);
                                    map[i, j + additionalLocation] = new Wall(i, j + additionalLocation);
                                    continue;
                                }
                                map[i, j + additionalLocation] = new Empty(i, j + additionalLocation);
                                doorCords = (i, j + additionalLocation);
                                reverseDoorCords = (i, j + additionalLocation + 7);
                                continue;
                            }
                            map[i, j + additionalLocation] = new Wall(i, j + additionalLocation);
                            continue;
                        }
                        if (map[i, j + additionalLocation] == null)
                        {
                            map[i, j + additionalLocation] = new Wall(i, j + additionalLocation);
                            continue;
                        }
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
