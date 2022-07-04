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

        public static List<RightRoom> RightRooms = new List<RightRoom>() { _lr, _bl, _tl};
        public static List<RightRoom> LeftRooms = new List<RightRoom>() { _br,_tr,_lr };
        public static List<RightRoom> BottomRooms = new List<RightRoom>() { _tb, _tl, _tr };
        public static List<RightRoom> TopRooms = new List<RightRoom>() { _bl,_br,_tb };
    }
}
