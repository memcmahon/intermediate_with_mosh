using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            string input = null;
            Console.WriteLine("This is a stopwatch, enter 'start', 'stop', 'lap' or 'end'");
            while (input != "end")
            {
                input = Console.ReadLine();
                if (input == "start")
                {
                    stopwatch.Start();
                }
                else if (input == "stop")
                {
                    stopwatch.Stop();
                }
                else if (input == "lap")
                {
                    stopwatch.Lap();
                }
            }
            Console.WriteLine(stopwatch.Summary());
        }
    }
}
