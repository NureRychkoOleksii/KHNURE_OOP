using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels.Rooms
{
    public static class RoomTemplate
    {
        private static LeftAndRightRoom _lr = new LeftAndRightRoom();
        private static BottomAndLeftRoom _bl = new BottomAndLeftRoom();
        private static BottomAndRight _br = new BottomAndRight();
        private static TopAndBottomRoom _tb = new TopAndBottomRoom();
        private static TopAndLeftRoom _tl = new TopAndLeftRoom();
        private static TopAndRightRoom _tr = new TopAndRightRoom();

        public static List<Room> RightRooms = new List<Room>() { _lr, _bl, _tl};
        public static List<Room> LeftRooms = new List<Room>() { _br,_tr,_lr };
        public static List<Room> BottomRooms = new List<Room>() { _tb, _tl, _tr };
        public static List<Room> TopRooms = new List<Room>() { _bl,_br,_tb };
    }
}
