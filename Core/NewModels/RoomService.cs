using System;

namespace Core.NewModels
{
    public class RoomService
    {
        public RoomWithLabyrinth RoomWithLabyrinth { get; set; }
        public RoomWithoutLabyrinth RoomWithoutLabyrinth { get; set; }

        public BigRoom bigRoom { get; set; }

        private Random _random = new Random();

        private int additionalPlace;

        private bool chance;

        public RoomService(ref BaseElement[,] map)
        {
            additionalPlace = _random.Next(10, 15);
            var location = _random.Next(25, 27);
            var door = _random.Next(1, 3);
            chance = Convert.ToBoolean(_random.Next(-1, 1));
            if (chance)
            {
                RoomWithoutLabyrinth = new RoomWithoutLabyrinth(ref map, location, door);
                RoomWithLabyrinth = new RoomWithLabyrinth(ref map, location, door, additionalPlace);
                bigRoom = new BigRoom(ref map, location, door, additionalPlace);
            }
            else
            {
                RoomWithLabyrinth = new RoomWithLabyrinth(ref map, location, door);
                RoomWithoutLabyrinth = new RoomWithoutLabyrinth(ref map, location, door, additionalPlace);
                bigRoom = new BigRoom(ref map, location, door, 0-additionalPlace);
            }
        }


        public void GeneratePassBetweenRooms(ref BaseElement[,] map)
        {
            if (chance)
            {
                for (int i = RoomWithoutLabyrinth.reverseDoorCords.Item1 + 1; i < RoomWithoutLabyrinth.reverseDoorCords.Item1 + additionalPlace - 5; i++)
                {
                    for (int j = RoomWithoutLabyrinth.reverseDoorCords.Item2 - 1; j < RoomWithoutLabyrinth.reverseDoorCords.Item2 + 2; j++)
                    {
                        if (j == RoomWithoutLabyrinth.reverseDoorCords.Item2)
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
            else
            {
                for (int i = RoomWithLabyrinth.reverseDoorCords.Item1 + 1; i < RoomWithLabyrinth.reverseDoorCords.Item1 + additionalPlace - 5; i++)
                {
                    for (int j = RoomWithLabyrinth.reverseDoorCords.Item2 - 1; j < RoomWithLabyrinth.reverseDoorCords.Item2 + 2; j++)
                    {
                        if (j == RoomWithLabyrinth.reverseDoorCords.Item2)
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
}
