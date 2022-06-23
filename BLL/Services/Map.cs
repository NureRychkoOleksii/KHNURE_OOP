using Core.NewModels;
using System;

namespace BLL.Services
{
    public class Map
    {
        public BaseElement[,] map = new BaseElement[50, 30];
        public int scoreToWin = 0;


        public BaseElement this[int x, int y]
        {
            get
            {
                return map[x,y];
            }
            set
            {
                map[x, y] = value;
            }
        }
        public void CreateMap()
        {
            Random random = new Random();
            for (int k = 0; k < 2; k++)
            {
                int l = 2;
                int a = random.Next(2, 25);
                for (int i = a; i < (a + 5); i++)
                {
                    if (i >= a + 3)
                    {
                        l -=2 ;
                    }
                    for (int j = a; j < (a + 5); j++)
                    {
                        if(i == a+2)
                        {
                            map[i, j] = new Empty(i, j);
                            continue;
                        }
                        if (j == a + (4 - l))
                        {
                            map[i, j] = new Wall(i, j);
                            if (map[i, a+(a+4-j)] == null)
                            {
                                map[i, a + (a + 4 - j)] = new Wall(i, a + (a + 4 - j));
                            }
                            l++;
                        }
                        else if (map[i,j] == null)
                        {
                            int q = random.Next(100);
                            map[i, j] = q switch
                            {
                                <= 75 => new EnergyBall(i, j),
                                _ => new Empty(i, j),
                            };
                        }
                    }
                }
            }
            for (int k = 0; k < 2; k++)
            {
                int a = random.Next(25);
                for (int i = a; i < (a + 5); i++)
                {
                    for (int j = a; j < (a + 5); j++)
                    {
                       if (i == j)
                       {
                           map[i, j] = new Wall(i, j);
                       }
                       else if ((i + j) - a == a + 4)
                       {
                           map[i, j] = new Wall(i, j);
                       }
                       else
                       {
                           map[i, j] = new Empty(i, j);
                       }
                   }
               }
           }
            for(int k = 0;k<3;k++)
            {
                int a = random.Next(2,25);
                for(int i=a; i < (a + 5); i++)
                {
                    for(int j = a; j < (a + 5); j++)
                    {
                        if(i == a || i == a + 4 || j == a || j == a + 4)
                        {
                            if (j == a + 3 && i == a)
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
                    }
                }
            }

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
            int x = random.Next(50), y = random.Next(30);
            map[x, y] = new Player(x, y);
            x = random.Next(50);
            y = random.Next(30);
            map[x, y] = new Ball(x, y);
            Console.SetCursorPosition(15, 5);
            foreach (var item in map)
            {
                switch (item)
                {
                    case Wall:
                        item.Draw(item.X, item.Y, '#', ConsoleColor.Gray);
                        break;
                    case EnergyBall:
                        item.Draw(item.X, item.Y, '%', ConsoleColor.Green);
                        break;
                    case Player:
                        var k = (Player)item;
                        if (!k.reverseSlash)
                        {
                            item.Draw(item.X, item.Y, '/', ConsoleColor.Red);
                        }
                        else
                        {
                            item.Draw(item.X, item.Y, '\\', ConsoleColor.Red);
                        }
                        break;
                    case Ball:
                        item.Draw(item.X, item.Y, '█', ConsoleColor.Blue);
                        break;
                    case Empty:
                        item.Draw(item.X, item.Y, ' ');
                        break;
                }
            }
        }

        public void UpdateMap()
        {
            foreach (var item in map)
            {
                switch (item)
                {
                    case Wall:
                        item.Draw(item.X, item.Y, '#', ConsoleColor.Gray);
                        break;
                    case EnergyBall:
                        item.Draw(item.X, item.Y, '%', ConsoleColor.Green);
                        break;
                    case Player:
                        var k = (Player)item;
                        if (!k.reverseSlash)
                        {
                            item.Draw(item.X, item.Y, '/', ConsoleColor.Red);
                        }
                        else
                        {
                            item.Draw(item.X, item.Y, '\\', ConsoleColor.Red);
                        }
                        break;
                    case Ball:
                        item.Draw(item.X, item.Y, '█', ConsoleColor.Blue);
                        break;
                    case Empty:
                        item.Draw(item.X, item.Y, ' ');
                        break;
                }
            }
        }
    }
}
