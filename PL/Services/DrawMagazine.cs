using System.Threading;
using Core.Models;

namespace Console.Services
{
    public class DrawShop
    {
        private const int _yellowSkin = 150;
        private const int _cyanSkin = 500;

        public void Draw(User user)
        {
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

            System.Console.ReadKey();
        }
    }
}
