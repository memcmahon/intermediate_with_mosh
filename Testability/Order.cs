using System;
namespace Testability
{
    public class Order
    {
        public DateTime DatePlaced { get; set; }
        public float TotalPrice { get; set; }
        public Shipment Shipment { get; set; }

        public Order()
        {
            Shipment = null;
        }

        public bool IsShipped
        {
            get
            {
                return Shipment != null;
            }

        }
    }
}
