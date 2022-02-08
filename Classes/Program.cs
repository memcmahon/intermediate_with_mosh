using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conversions option 1
            try
            {
                int.Parse("abc");
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert");
            }

            // Option 2
            int number;
            bool result = int.TryParse("123", out number);

            if (result)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Unable to convert");
            }

            
            
        }

        static void UsePoints()
        {
            try
            {
                var point = new Point(10, 20);
                point.Move(null);

                Console.WriteLine(point.X + ", " + point.Y);

                point.Move(100, 200);

                Console.WriteLine(point.X + ", " + point.Y);
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occured");
            }
        }
    }
}
