using System;

namespace Core.NewModels
{
    public class RoomService
    {
        public RoomWithLabyrinth RoomWithLabyrinth { get; set; }
        public RoomWithoutLabyrinth RoomWithoutLabyrinth { get; set; }

        private Random _random = new Random();

        public RoomService(ref BaseElement[,] map)
        {
            var location = _random.Next(5, 20);
            var door = _random.Next(1, 3);
            RoomWithoutLabyrinth = new RoomWithoutLabyrinth(ref map, location, door);
            RoomWithLabyrinth = new RoomWithLabyrinth(ref map, location, door);
        }


        public void GeneratePassBetweenRooms(ref BaseElement[,] map)
        {
            for(int i = RoomWithoutLabyrinth.reverseDoorCords.Item1 + 1; i < RoomWithoutLabyrinth.reverseDoorCords.Item1 + 5; i++)
            {
                for (int j = RoomWithoutLabyrinth.reverseDoorCords.Item2 - 1; j < RoomWithoutLabyrinth.reverseDoorCords.Item2 + 2; j++)
                {
                    if(j == RoomWithoutLabyrinth.reverseDoorCords.Item2)
                    {
                        map[i, j] = new Empty(i, j);
                    }
                    else
                    {
                        map[i, j] = new Wall(i, j);
                    }
                }
            }
        }
    }   
}
