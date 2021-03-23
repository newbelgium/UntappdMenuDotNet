using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UntappdMenuDotNet.UnitTest
{
    [TestClass]
    public class MenuTests
    {
        private string email = "validemail@domain.com";
        private string token = "validtoken";

        [ExpectedException(typeof(ArgumentNullException), "An ArgumentNullException was expected but one was not thrown")]
        [TestMethod]
        public void NoAuthBytes()
        {
            _ = new UntappdService(null);
        }

        [ExpectedException(typeof(ArgumentNullException), "An ArgumentNullException was expected but one was not thrown")]
        [TestMethod]
        public void NoAuthStrings()
        {
            _ = new UntappdService(null, null);
        }

        [ExpectedException(typeof(UntappdException), "An UntappdException was expected but one was not thrown")]
        [TestMethod]
        public async Task MalformedAuthBytes()
        {
            var service = new UntappdService(new byte[] { 1, 2, 3 });
            _ = await service.GetLocationCollection();
        }

        [ExpectedException(typeof(UntappdException),"An UntappdException was expected but one was not thrown")]
        [TestMethod]
        public async Task MalformedAuthStrings()
        {
            var service = new UntappdService("fake@nothing.net", "incorrect");
            _ = await service.GetLocationCollection();
        }

        [TestMethod]
        public async Task Locations()
        {
            var service = new UntappdService(email, token);
            var locationCollection = await service.GetLocationCollection();
            Assert.IsNotNull(locationCollection);
            Assert.IsNotNull(locationCollection.Locations);
        }
    }
}
