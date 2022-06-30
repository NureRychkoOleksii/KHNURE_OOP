using BLL;
using BLL.Interfaces;
using Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Services
{
    public class DrawLogin
    {
        public User Login(UserService _userService)
        {
            Console.Clear();
            Console.WriteLine(@"   __             _        __                                                          __ 
  / /  ___  ___ _(_)__    / /____    __ _____  __ ______  ___ ____________  __ _____  / /_
 / /__/ _ \/ _ `/ / _ \  / __/ _ \  / // / _ \/ // / __/ / _ `/ __/ __/ _ \/ // / _ \/ __/
/____/\___/\_, /_/_//_/  \__/\___/  \_, /\___/\_,_/_/    \_,_/\__/\__/\___/\_,_/_//_/\__/ 
          /___/                    /___/                                                  ");
            Console.SetCursorPosition(50, 5);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("enter your nickname");
            var nick = Console.ReadLine();
            Console.WriteLine("enter your password");
            var pass = Console.ReadLine();
            var user = _userService.GetUsers().Where(u => u.Name == nick && u.Password == pass);
            if(user.FirstOrDefault() != null)
            {
                return user.FirstOrDefault();
            }
            else
            {
                var res = new User() { Id = 0, Name = nick, Password = pass, Record = "0" };
                _userService.AddUser(res);
                return res;
            }
        }
    }
}
