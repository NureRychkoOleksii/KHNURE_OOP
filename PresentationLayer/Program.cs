using System;
using PresentationLayer.StartupMethods;

namespace PresentationLayer
{
    class Program
    {
        static void Main()
        {
            var startup = new Startup();

            startup.StartGame();
        }
    }
}