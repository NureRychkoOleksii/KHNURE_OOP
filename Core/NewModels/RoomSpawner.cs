using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.NewModels.Rooms;

namespace Core.NewModels
{
    public class RoomSpawner
    {
        public string OpeningDirection { get; set; }

        private Random _random = new Random();

        private int _location;

        private int _x;

        private int _y;

        public RoomSpawner(ref BaseElement[,] map)
        {
            int k = 0;
            _location = _random.Next(10, 15);
            _x = _location;
            _y = _location;
            OpeningDirection = "Right";
            while(k <= 4)
            {
                Update(ref map);
                k++;
            }
        }

        private void DetermineDirection(Room room)
        {
            OpeningDirection = room switch
            {
                LeftAndRightRoom => "Right",
                BottomAndLeftRoom => "Bottom",
                TopAndLeftRoom => "Top",
                BottomAndRight => "Right",
                TopAndBottomRoom => "Bottom",
                TopAndRightRoom => "Right",
            };
        }

        private void Update(ref BaseElement[,] map)
        {
            var rand = _random.Next(1, 3);
            switch (OpeningDirection)
            {
                case "Right":
                    var rightRoom = RoomTemplate.RightRooms[rand];

                    var room = rightRoom switch
                    {
                        LeftAndRightRoom => (LeftAndRightRoom)rightRoom,
                        BottomAndLeftRoom =>(BottomAndLeftRoom)rightRoom,
                        TopAndLeftRoom => (TopAndLeftRoom)rightRoom,
                        _ => rightRoom
                    };
                    room.Create(ref map, _x,_y);
                    ChangeLocation(room, true);
                    DetermineDirection(room);
                    break;
                case "Left":
                    var leftRoom= RoomTemplate.LeftRooms[rand];
                    room = leftRoom switch
                    {
                        LeftAndRightRoom => (LeftAndRightRoom)leftRoom,
                        BottomAndRight => (BottomAndRight)leftRoom,
                        TopAndRightRoom => (TopAndRightRoom)leftRoom,
                        _ => leftRoom
                    };
                    room.Create(ref map, _x, _y);
                    ChangeLocation(room, true, true);
                    DetermineDirection(room);
                    break;
                case "Top":
                    var topRoom = RoomTemplate.TopRooms[rand];
                    room = topRoom switch
                    {
                        TopAndBottomRoom => (TopAndBottomRoom)topRoom,
                        BottomAndRight => (BottomAndRight)topRoom,
                        BottomAndLeftRoom => (BottomAndLeftRoom)topRoom,
                        _ => topRoom
                    };
                    room.Create(ref map, _x, _y);
                    ChangeLocation(room, false,false,true);
                    DetermineDirection(room);
                    break;
                case "Bottom":
                    var bottomRoom = RoomTemplate.BottomRooms[rand];
                    room = bottomRoom switch
                    {
                        TopAndBottomRoom => (TopAndBottomRoom)bottomRoom,
                        TopAndLeftRoom => (TopAndLeftRoom)bottomRoom,
                        TopAndRightRoom => (TopAndRightRoom)bottomRoom,
                        _ => bottomRoom
                    };
                    room.Create(ref map, _x, _y);
                    ChangeLocation(room, false,false, false);
                    DetermineDirection(room);
                    break;
            }
        }


        public void ChangeLocation(Room room, bool nextHorizontal, bool fromLefToRight = false, bool fromTopToBottom = false)
        {
            switch(room)
            {
                case LeftAndRightRoom:
                    if(fromLefToRight)
                    {
                        _x += 5;
                    }
                    else
                    {
                        _x -= 5;
                    }
                    break;
                case BottomAndLeftRoom:
                    if(nextHorizontal)
                    {
                        _y += 5;
                    }
                    else {
                        _x -= 5;
                    }
                    break;
                case TopAndLeftRoom:
                    if (nextHorizontal)
                    {
                        _y -= 5;
                    }
                    else
                    {
                        _x -= 5;
                    }
                    break;
                case BottomAndRight:
                    if (nextHorizontal)
                    {
                        _y += 5;
                    }
                    else
                    {
                        _x += 5;
                    }
                    break;
                case TopAndRightRoom:
                    if (nextHorizontal)
                    {
                        _y -= 5;
                    }
                    else
                    {
                        _x += 5;
                    }
                    break;
                case TopAndBottomRoom:
                    if (fromTopToBottom)
                    {
                        _y += 5;
                    }
                    else
                    {
                        _y -= 5;
                    }
                    break;
            }
        }
    }
}
