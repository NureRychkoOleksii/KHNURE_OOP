using Core.Models;
using System;
using System.Linq;

namespace Core.NewModels
{

    public class Map
    {
        public BaseElement[,] map;
        public int scoreToWin = 0;

        public Map(int x, int y)
        {
            map = new BaseElement[x, y];
        }

        public BaseElement this[int x, int y]
        {
            get
            {
                return map[x, y];
            }
            set
            {
                map[x, y] = value;
            }
        }
        public void CreateMap(User user)
        {
            RoomSpawner roomSpawner = new RoomSpawner(ref map);
            Random random = new Random();
            //RoomService rooms = new RoomService(ref map);
            //roomWithLabyrinth = rooms.RoomWithLabyrinth;
            //roomWithoutLabyrinth = rooms.RoomWithoutLabyrinth;
            //rooms.GeneratePassBetweenRooms(ref map);
            //for (int k = 0; k < 2; k++)
            //{
            //    int l = 2;
            //    int a = random.Next(2, 40);
            //    for (int i = a; i < (a + 5); i++)
            //    {
            //        if (i == a + 3)
            //        {
            //            l--;
            //        }
            //        else if (i > a + 3)
            //        {
            //            l -= 2;
            //        }
            //        for (int j = a; j < (a + 5); j++)
            //        {
            //            if (i == a + 2)
            //            {
            //                map[i, j] = new Empty(i, j);
            //                continue;
            //            }
            //            if (j == a + (4 - l))
            //            {
            //                map[i, j] = new Wall(i, j);
            //                if (map[i, a + (a + 4 - j)] == null)
            //                {
            //                    map[i, a + (a + 4 - j)] = new Wall(i, a + (a + 4 - j));
            //                }
            //                l++;
            //            }
            //            else if (map[i, j] == null)
            //            {
            //                int q = random.Next(100);
            //                map[i, j] = q switch
            //                {
            //                    <= 75 => new EnergyBall(i, j),
            //                    _ => new Empty(i, j),
            //                };
            //            }
            //        }
            //    }
            //}
            //for (int k = 0; k < 2; k++)
            //{
            //    int a = random.Next(40);
            //    for (int i = a; i < (a + 5); i++)
            //    {
            //        for (int j = a; j < (a + 5); j++)
            //        {
            //            if (i == j)
            //            {
            //                map[i, j] = new Wall(i, j);
            //            }
            //            else if ((i + j) - a == a + 4)
            //            {
            //                map[i, j] = new Wall(i, j);
            //            }
            //            else
            //            {
            //                map[i, j] = new Empty(i, j);
            //            }
            //        }
            //    }
            //}
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == null)
                    {
                        int randNumb = random.Next(100);
                        map[i, j] = randNumb switch
                        {
                            <= 1 => new EnergyBall(i, j),
                            <= 5 => new Wall(i, j),
                            _ => new Empty(i, j)
                        };
                        if (map[i, j] is EnergyBall)
                        {
                            scoreToWin++;
                        }
                    }
                }
            }
            int teleportX = random.Next(20, 35), teleportY = random.Next(20, 35);
            map[teleportX, teleportY] = new Teleport(teleportX, teleportY);
            int x = random.Next(20, 35), y = random.Next(20, 35);
            map[x, y] = new Player(x, y,user.Skin); 
            x = random.Next(20, 35);
            y = random.Next(20, 35);
            map[x, y] = new Ball(x, y);
            UpdateMap();
        }

        public void CreateEmptyMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == null)
                    {
                        map[i, j] = new Empty(i, j);
                    }
                }
            }
        }
        public void UpdateMap()
        {
            foreach (var item in map)
            {
                item.Draw();
            }
        }
    }
}