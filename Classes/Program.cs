using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point(10, 20);
            point.Move(null);

            Console.WriteLine(point.X + ", " + point.Y);

            point.Move(100, 200);

            Console.WriteLine(point.X + ", " + point.Y);
        }
    }
}
