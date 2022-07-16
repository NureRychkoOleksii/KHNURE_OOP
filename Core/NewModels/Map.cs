using Core.Models;
using System;

namespace Core.NewModels
{

    public class Map : IdKey
    {
        public BaseElement[,] map;
        public int scoreToWin = 0;

        public string Name { get; set; }

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