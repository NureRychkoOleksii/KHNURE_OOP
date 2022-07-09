using System.Threading;
using Core.Models;
using Core.NewModels;

namespace Console.Services
{
    public class DrawShop
    {
        private const int _yellowSkin = 150;
        private const int _cyanSkin = 500;
        private const int _wall = 50;
        private const int _teleport = 100;

        private User user;

        public void Draw(User user)
        {
            this.user = user;
            System.Console.Clear();
            System.Console.WriteLine(@" ____      ____      __                                       _             _   __                     __                       _  
|_  _|    |_  _|    [  |                                     / |_          / |_[  |                   [  |                     | | 
  \ \  /\  / /.---.  | |  .---.   .--.   _ .--..--.  .---.  `| |-' .--.   `| |-'| |--.  .---.   .--.   | |--.   .--.   _ .--.  | | 
   \ \/  \/ // /__\\ | | / /'`\]/ .'`\ \[ `.-. .-. |/ /__\\  | | / .'`\ \  | |  | .-. |/ /__\\ ( (`\]  | .-. |/ .'`\ \[ '/'`\ \| | 
    \  /\  / | \__., | | | \__. | \__. | | | | | | || \__.,  | |,| \__. |  | |, | | | || \__.,  `'.'.  | | | || \__. | | \__/ ||_| 
     \/  \/   '.__.'[___]'.___.' '.__.' [___||__||__]'.__.'  \__/ '.__.'   \__/[___]|__]'.__.' [\__) )[___]|__]'.__.'  | ;.__/ (_) 
                                                                                                                      [__|     ");

            Thread.Sleep(2000);

            System.Console.Clear();

            System.Console.SetCursorPosition(50, 5);

            System.Console.WriteLine($"Your coins: {user.CoinsCount}");

            System.Console.WriteLine("1) Yellow skin (rare skin for cool guys) - " + _yellowSkin);
            System.Console.WriteLine("2) Cyan skin (epic skin for guys with big ) - " + _cyanSkin);
            System.Console.WriteLine("3) Buy extra wall! " + _wall);
            System.Console.WriteLine("4) Buy a teleport! " + _teleport);

            System.Console.WriteLine("Choose one to buy!");

            switch(System.Console.ReadKey(true).Key)
            {
                case System.ConsoleKey.D1:
                    CheckBalance(_yellowSkin, "yellow");
                    break;
                case System.ConsoleKey.D2:
                    CheckBalance(_cyanSkin, "cyan");
                    break;
                case System.ConsoleKey.D3:
                    CheckBalanceForItems(_wall, "wall");
                    break;

            }

            System.Console.ReadKey();
        }

        private void CheckBalanceForItems(int price, string itemName)
        {
            if (user.CoinsCount >= price)
            {
                var item = itemName switch
                {
                    "wall" => new Wall(0,0),
                };
                user.Inventory.Add(item);
                user.CoinsCount -= price;
                System.Console.WriteLine("Successful!");
                return;
            }
        }

        public void CheckBalance(int skinPrice, string skinName)
        {
            if(user.CoinsCount >= skinPrice && CheckSkin(skinName))
            {
                user.Skin = skinName;
                user.CoinsCount -= skinPrice;
                System.Console.WriteLine("Successful!");
                return;
            }
            if(CheckSkin(skinName))
            {
                System.Console.WriteLine("You already have this skin");
                return;
            }
            System.Console.WriteLine("Not enough money");
        }

        public bool CheckSkin(string skin)
        {
            return !(user.Skin == skin);
        }
    }
}
