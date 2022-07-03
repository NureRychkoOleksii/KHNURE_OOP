using System;
using System.Collections.Generic;

namespace Core.NewModels
{
    public class RoomWithoutLabyrinth
    {
        public List<BaseElement> room = new List<BaseElement>();
        public (int, int) doorCords = (0, 0);
        public (int, int) reverseDoorCords = (0, 0);
        Random random = new Random();
        int door;

        public RoomWithoutLabyrinth(ref BaseElement[,] map, int location, int door)
        {
            for (int i = location - 1; i < location + 6; i++)
            {
                for(int j = location - 1; j < location + 6; j++)
                {
                    if (i < location || i > location + 5)
                    {
                        map[i, j] = new Empty(i, j);
                        continue;
                    }

                    if ((i == location) || (i == location + 5) || j == location + 5 || j == location - 1)
                    {
                        if (i == location && j - location == door)
                        {
                            map[i, j] = new Empty(i, j);
                            doorCords = (i, j);
                            reverseDoorCords = (i + 5, j);
                            continue;
                        }
                        map[i, j] = new Wall(i, j);
                        continue;
                    }
                    int q = random.Next(100);
                    map[i, j] = q switch
                    {
                        <= 25 => new EnergyBall(i, j),
                        _ => new Empty(i, j),
                    };
                    BaseElement element = q switch
                    {
                        <= 25 => new EnergyBall(i, j),
                        _ => new Empty(i, j),
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
