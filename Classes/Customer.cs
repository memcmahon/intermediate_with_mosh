using System;
using System.Collections.Generic;

namespace Classes
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Order> Orders = new List<Order>();
        // the readonly flag will stop you from being able to do something like on line 27
        //public readonly List<Order> Orders = new List<Order>();

        public Customer(int id)
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            :this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            Orders = new List<Order>();
            //...
        }
    }
}
