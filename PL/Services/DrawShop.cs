using System.Threading;
using Core.Models;

namespace Console.Services
{
    public class DrawShop
    {
        private const int _yellowSkin = 150;
        private const int _cyanSkin = 500;

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

            System.Console.WriteLine("1) Yellow skin - " + _yellowSkin);
            System.Console.WriteLine("2) Cyan skin - " + _cyanSkin);

            System.Console.WriteLine("Choose one to buy!");

            switch(System.Console.ReadKey(true).Key)
            {
                case System.ConsoleKey.D1:
                    CheckBalance(_yellowSkin, "yellow");
                    break;
                case System.ConsoleKey.D2:
                    CheckBalance(_cyanSkin, "cyan");
                    break;
            }

            System.Console.ReadKey();
        }

        public void CheckBalance(int skin, string skinName)
        {
            if(user.CoinsCount >= skin)
            {
                user.Skin = skinName;
                System.Console.WriteLine("Successful!");
                return;
            }
            System.Console.WriteLine("Not enough money");
        }
    }
}
