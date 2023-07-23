using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutAPI.Domain
{
    public class WatchRepository
    {
        public List<Watch> GetAllWatches()
        {
            return new List<Watch>()
            {
                new Watch("001","Rolex",100, new Tuple<int, decimal>(3,200)),
                new Watch("002","Michael Kors",80,new Tuple<int, decimal>(2,120)),
                new Watch("003","Swatch",50),
                new Watch("004","Casio",30)
            };
        }
    }
}
