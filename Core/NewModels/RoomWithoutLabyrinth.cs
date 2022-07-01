using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.NewModels
{
    public class RoomWithoutLabyrinth
    {
        BaseElement[,] room = new BaseElement[5, 5];
        Random random = new Random();
        int door;

        public RoomWithoutLabyrinth(ref BaseElement[,] map)
        {
            door = random.Next(2, 4);
            int border = random.Next(5, 40);
            for (int i = border - 1; i < border + 6; i++)
            {
                for(int j = border - 1; j < border + 6; j++)
                {
                    if (i < border)
                    {
                        map[i, j] = new Empty(i, j);
                        continue;
                    }

                    if ((i == border) || (i == border + 5) || j == border + 5 || j == border)
                    {
                        if (i == border && j - border == door)
                        {
                            map[i, j] = new Empty(i, j);
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
                    //room[i-border, j-border] = q switch
                    //{
                    //    <= 25 => new EnergyBall(i, j),
                    //    _ => new Empty(i, j),
                    //};

                }
            }
        }

        public bool CheckRoom()
        {
            var res = false;
            foreach(var i in room)
            {
                if(i is not Empty)
                {
                    res = true;
                }
            }

            return res;
        }
    }
}
