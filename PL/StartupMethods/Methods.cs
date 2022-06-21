using Core.NewModels;
using System;


namespace PL.StartupMethods
{
    public class Methods
    {
        public BaseElement[,] map = new BaseElement[50, 30];
        public int scoreToWin = 0;

        public void CreateMap()
        {
            Random random = new Random();
            for(int i =0;i<map.GetLength(0);i++)
            {
                for(int j = 0; j < map.GetLength(1);j++)
                {
                    int randNumb = random.Next(100);
                    map[i, j] = randNumb switch
                    {
                        < 5 => new EnergyBall(i, j),
                        < 10 => new Wall(i, j),
                        _ => new BaseElement(i, j)
                    };
                    if (map[i,j] is EnergyBall)
                    {
                        scoreToWin++;
                    }
                }
            }
            int x = random.Next(50), y = random.Next(30);
            map[x, y] = new Player(x, y);
            x = random.Next(50);
            y = random.Next(30);
            map[x, y] = new Ball(x, y);
            Console.SetCursorPosition(15, 5);
            foreach(var item in map)
            {
                switch(item)
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
                    default:
                        item.Draw(item.X, item.Y);
                        break;
                }
            }
        }

        public void UpdateMap()
        {
            foreach(var item in map)
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
                        if(!k.reverseSlash)
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
                    default:
                        item.Draw(item.X, item.Y);
                        break;
                }
            }
        }
    }
}
