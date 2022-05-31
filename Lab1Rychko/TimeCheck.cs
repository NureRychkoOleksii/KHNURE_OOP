using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Rychko
{
    class TimeCheck
    {
        private Stopwatch stopwatch = new Stopwatch();
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
