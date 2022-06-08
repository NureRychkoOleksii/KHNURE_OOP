using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DrawMenu
    {
        public void DrawMenuConsole()
        {
            Console.WriteLine(@" _  _  ____  __     ___  __   _  _  ____    ____  __     ____  _  _  ____    __ _  ____   ___  _                  
/ )( \(  __)(  )   / __)/  \ ( \/ )(  __)  (_  _)/  \   (_  _)/ )( \(  __)  (  ( \(  _ \ / __)/ \                 
\ /\ / ) _) / (_/\( (__(  O )/ \/ \ ) _)     )( (  O )    )(  ) __ ( ) _)   /    / ) _ (( (_ \\_/                 
(_/\_)(____)\____/ \___)\__/ \_)(_/(____)   (__) \__/    (__) \_)(_/(____)  \_)__)(____/ \___/(_)                 
 ____  ____  ____  ____  ____     __   __ _  _  _    __ _  ____  _  _    ____  __     ____  ____  __   ____  ____ 
(  _ \(  _ \(  __)/ ___)/ ___)   / _\ (  ( \( \/ )  (  / )(  __)( \/ )  (_  _)/  \   / ___)(_  _)/ _\ (  _ \(_  _)
 ) __/ )   / ) _) \___ \\___ \  /    \/    / )  /    )  (  ) _)  )  /     )( (  O )  \___ \  )( /    \ )   /  )(  
(__)  (__\_)(____)(____/(____/  \_/\_/\_)__)(__/    (__\_)(____)(__/     (__) \__/   (____/ (__)\_/\_/(__\_) (__) ");
            Console.WriteLine(@"                                                               


                                                                UpArrow - Up
                                                                DownArrow - Down
                                                                LeftArrow - Left
                                                                RightArrow - Right
                                                                Tab - change wall");
        }
    }
}
