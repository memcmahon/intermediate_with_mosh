using System;

namespace Classes
{
    public class Person
    {
        public DateTime Birthdate { get; set; }
        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;

                return years;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Birthdate = new DateTime(1988, 01, 13);
            Console.WriteLine(person.Age);
          
        }
    }
}
