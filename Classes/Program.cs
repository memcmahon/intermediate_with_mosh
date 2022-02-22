using System;
using System.Collections.Generic;

namespace Classes
{
    public class Order
    {
        public bool IsShipped { get; set; }
        
    }

    public class ShippingCalculator
    {

    }

    public class OrderProcessor
    {
        private readonly ShippingCalculator _shippingCalculator;

        public OrderProcessor()
        {
            _shippingCalculator = new ShippingCalculator();
        }

        public void Process(Order order)
        {
            if(order.IsShipped)
            {
                throw new InvalidOperationException("This order is already shipped");
            }

            order.Shipment = new Shipment
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor();
        }
    }
}

