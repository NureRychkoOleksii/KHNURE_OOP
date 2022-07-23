using System;
using System.Collections.Generic;

namespace Core.NewModels
{
    public static class Room
    {
        public static Dictionary<string, (int, int)> _exits = new Dictionary<string, (int, int)>();

        public static Dictionary<string, (int, int)> _locations = new Dictionary<string, (int, int)>();

        static Room()
        {
            _exits.Add("up", (2, 4));
            _exits.Add("down", (2, 0));
            _exits.Add("left", (4, 2));
            _exits.Add("right", (0, 2));
            _locations.Add("up", (0, -4));
            _locations.Add("down", (0, 4));
            _locations.Add("left", (-4, 0));
            _locations.Add("right", (4, 0));
        }

        static Random random = new Random();
        public static void Create(ref BaseElement[,] map, int x, int y, string nextExit, string previousExit)
        {
            bool randomRoomCreated = false;
            for (int i = x; i < x + 5; i++)
            {
                for (int j = y; j < y + 5; j++)
                {
                    if (i == x || i == x + 4 || j == y + 4 || j == y)
                    {
                        var (dx,dy) = _exits[nextExit];
                        if (i == x + dx && j == y + dy)
                        {
                            map[i, j] = new Empty(i, j);
                            continue;
                        }
                        (dx, dy) = _exits[previousExit];
                        if (i == x + dx && j == y + dy)
                        {
                            map[i, j] = new Empty(i, j);
                            continue;
                        }
                        (dx, dy) = _exits[GetNewExit(previousExit)];
                        if (i == x + dx && j == y + dy && !randomRoomCreated)
                        {
                            map[i, j] = new Empty(i, j);
                            randomRoomCreated = true;
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
                }
            }
        }

        public static string GetNextRoom(string currentRoom)
        {
            string res = "";
            while(true)
            {
                res = random.Next(1, 4) switch
                {
                    1 => "left",
                    2 => "up",
                    3 => "right",
                    4 => "down",
                    _ => currentRoom
                };
                if(res != currentRoom)
                {
                    break;
                }    

            }

            return res;
        }

        private static string GetNewExit(string currentExit)
        {
            var res = random.Next(1, 100) switch
            {
                <= 10 => GetRandomExit(),
                _ => currentExit
            };

            return res;
        }

        private static string GetRandomExit()
        {
            return random.Next(1, 4) switch
            {
                1 => "left",
                2 => "up",
                3 => "right",
                4 => "down"
            };
        }
    }
}
