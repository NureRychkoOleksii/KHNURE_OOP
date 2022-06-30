using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Methods
{
    public class TimeCheck
    {
        public Stopwatch stopwatch = new Stopwatch();
        public void StartTimeChecking()
        {
            stopwatch.Start();
        }
        public void StopTimeChecking()
        {
            stopwatch.Stop();
            Console.Write("Your time: "+ stopwatch.Elapsed + " ");
        }
    }
}
