using System;

namespace Classes
{
    public class Person
    {
        public string Name;

        public void Introduce(string otherName)
        {
            Console.WriteLine("Hi {0}, I am {1}", otherName, Name);
        }

        public static Person Parse(string name)
        {
            var person = new Person();
            person.Name = name;

            return person;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.Parse("Megan");

            person.Introduce("Mosh");
            
        }
    }
}
