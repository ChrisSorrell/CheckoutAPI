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
            new Watch("0001","Rolex",100),
            new Watch("0002","Michael Kors",80),
            new Watch("0003","Swatch",50),
            new Watch("0004","Casio",30)
        };

        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(ILogger<CheckoutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Watch> GetWatchCatalogue ()
        {
            return watches.ToArray();
        }
    }
}
