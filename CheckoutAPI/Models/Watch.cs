using System;

namespace CheckoutAPI
{
    public class Watch
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public bool HasDiscount { get; set; }

        public Watch(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            UnitPrice = price;

        }
    }
}
    
