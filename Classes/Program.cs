using System;
using System.Collections.Generic;

namespace Classes
{
    class Shipe
    {
        public void ImA()
        {
            Console.WriteLine("I'm a Shape");
        }
    }

    class Circle : Shipe
    {
        public void ImA()
        {
            Console.WriteLine("I'm a Circle");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var things = new List<Shipe>();

            var shape1 = new Shipe();
            var shape2 = new Shipe();
            var circle1 = new Circle();
            var circle2 = new Circle();

            //Adding circles to this list of shapes upcasts them all to shapes.
            things.Add(shape1);
            things.Add(circle1);
            things.Add(shape2);
            things.Add(circle2);

            foreach(var thing in things)
            {
                Circle circle = thing as Circle;
                if(circle != null)
                {
                    circle.ImA();
                    continue;
                }

                thing.ImA();
            }

        }
    }
}
