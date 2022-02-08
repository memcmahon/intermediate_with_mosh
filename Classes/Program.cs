using System;

namespace Classes
{
    public class Person
    {
        private DateTime _birthdate;

        public void SetBirthdate(DateTime birthdate)
        {
            _birthdate = birthdate;
        }

        public DateTime getBirthdate()
        {
            return _birthdate;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.SetBirthdate(new DateTime(1988, 1, 13));
            Console.WriteLine(person.getBirthdate());
          
        }
    }
}
