using System;
using System.Collections.Generic;

namespace Classes
{
    public class Customer
    {
        public int Id;
        public string Name;

        public void Promote()
        {
            var rating = CalculateRating();
            if (rating == 0)
                Console.WriteLine("Promoted to Level 1");
            else
                Console.WriteLine("Promoted to Level 2");
        }

        public int CalculateRating()
        {
            return 0;
        }
    }
}
