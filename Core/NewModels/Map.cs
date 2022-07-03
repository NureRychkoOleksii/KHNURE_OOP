using System;
using System.Linq;

namespace Core.NewModels
{

    public class Map
    {
        public BaseElement[,] map = new BaseElement[48,48];
        public int scoreToWin = 0;
        RoomWithLabyrinth roomWithLabyrinth;
        RoomWithoutLabyrinth roomWithoutLabyrith;


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
        public void CreateRoomsWithoutLabyrinth()
        {
            roomWithoutLabyrith = new RoomWithoutLabyrinth(ref map);
        }

        public void CreateRoomsWithLabyrinth()
        {
            roomWithLabyrinth = new RoomWithLabyrinth(ref map);
        }

        public void CreateMap()
        {
            Random random = new Random();
            CreateRoomsWithoutLabyrinth();
            CreateRoomsWithLabyrinth();
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
            int x = random.Next(5,25), y = random.Next(5,25);
            map[x, y] = new Player(x, y);
            x = random.Next(5, 25);
            y = random.Next(5, 25);
            map[x, y] = new Ball(x, y);
            UpdateMap();
        }

        public void UpdateMap()
        {
            foreach(var i in map)
            {
                var itemFromRoomWithLabyrinth = roomWithLabyrinth.room.FirstOrDefault(elem => elem.X == i.X && elem.Y == i.Y);
                var itemFromRoomWithoutLabyrinth = roomWithoutLabyrith.room.FirstOrDefault(elem => elem.X == i.X && elem.Y == i.Y);
                if (itemFromRoomWithLabyrinth != null && i is Empty)
                {
                    roomWithLabyrinth.room.Remove(itemFromRoomWithLabyrinth);
                }
                if(itemFromRoomWithoutLabyrinth != null && i is Empty)
                {
                    roomWithLabyrinth.room.Remove(itemFromRoomWithoutLabyrinth);
                }
            }
            foreach(var i in map)
            {
                var itemFromRoomWithoutLabyrinth = roomWithoutLabyrith.room.FirstOrDefault(elem => elem.X == i.X && elem.Y == i.Y);
                if (itemFromRoomWithoutLabyrinth != null && i is Empty)
                {
                    roomWithoutLabyrith.room.Remove(itemFromRoomWithoutLabyrinth);
                }
            }
            roomWithLabyrinth.OpenDoor(ref map);
            roomWithoutLabyrith.OpenDoor(ref map);
            foreach (var item in map)
            {
                item.Draw();
            }
        }
    }
}