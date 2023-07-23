using CheckoutAPI.Domain;
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
        
        /// <summary>
        /// Review the list of available watches in the catalogue
        /// </summary>
        [HttpGet("GetWatchCatalogue")]
        public IEnumerable<Watch> GetWatchCatalogue ()
        {
            return new WatchRepository().GetAllWatches();
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
            var item = new WatchRepository().GetAllWatches().Where(t => t.Id == id).FirstOrDefault();
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
