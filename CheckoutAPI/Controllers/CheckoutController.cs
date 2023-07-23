using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CheckoutAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private static readonly List<Watch> watches = new List<Watch>()
        {
            new Watch("001","Rolex",100, new Tuple<int, decimal>(3,200)),
            new Watch("002","Michael Kors",80,new Tuple<int, decimal>(2,120)),
            new Watch("003","Swatch",50),
            new Watch("004","Casio",30)
        };

        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(ILogger<CheckoutController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Review the list of available watches in the catalogue
        /// </summary>
        [HttpGet("GetWatchCatalogue")]
        public IEnumerable<Watch> GetWatchCatalogue ()
        {
            return watches.ToArray();
        }

        /// <summary>
        /// Calculate total cost for checkout
        /// </summary>
        [HttpPost]
        public decimal Checkout(List<string>itemIds)
        {
            var itemGroups = itemIds.GroupBy(t => t).Select(group => new
            {
                itemName = group.Key,
                itemCount = group.Count()
            });

            decimal total = 0;
            foreach (var itemGroup in itemGroups)
                total += GetItemGroupPrice(itemGroup.itemName, itemGroup.itemCount);
            


            return total;
        }

        private decimal GetItemGroupPrice(string id, int count){
            var item = watches.Where(t => t.Id == id).FirstOrDefault();
            if (item != null)
            {
                if (item.HasDiscount())
                {
                    var unitsRequiredForDiscount = item.Discount.Item1;
                    var discountedPrice = item.Discount.Item2;
                    //get total for all discounted items
                    var total = (count / unitsRequiredForDiscount) * discountedPrice;

                    // add full price on remainder of items that don't quality for the discount
                    total += (count % unitsRequiredForDiscount) * item.UnitPrice;

                    return total;

                }
                else
                {
                    return item.UnitPrice * count;
                }
            }
            return 0;

        }

    }
}
