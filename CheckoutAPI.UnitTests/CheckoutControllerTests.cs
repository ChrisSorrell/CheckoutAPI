using CheckoutAPI.Controllers;
using CheckoutAPI.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CheckoutAPI.UnitTests
{
    [TestClass]
    public class CheckoutControllerTests
    {
        [TestMethod]
        public void CheckoutTest()
        {
            List<string> watchIds = new List<string> { "001", "002", "001", "004", "003" };
           
            var priceTotal = new CheckoutController().Checkout(watchIds);

            Assert.AreEqual(priceTotal, 360);


        }

        [TestMethod]
        public void CheckoutDiscountTest()
        {
            // 3 for 200 discount + 2 full price
            List<string> watchIds = new List<string> { "001", "001", "001", "001", "001" };

            var priceTotal = new CheckoutController().Checkout(watchIds);

            Assert.AreEqual(priceTotal, 400);


        }
    }
}
