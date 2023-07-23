using System;
using System.Collections.Generic;

namespace CheckoutAPI
{
    public class Watch
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }


        // item1 = items needed to apply discount. item2 = applied discount price.
        public Tuple<int,decimal> Discount { get; set; }
        

        public Watch(string id, string name, decimal price, Tuple<int,decimal> discount = null)
        {
            Id = id;
            Name = name;
            UnitPrice = price;           
            Discount = discount;
        }

        public bool HasDiscount() { return Discount != null;  }

    }

}
    
