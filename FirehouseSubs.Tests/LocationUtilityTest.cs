using FirehouseSubs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirehouseSubs.Tests
{
    [TestClass]
    public class LocationUtilityTest
    {
        [TestMethod]
        public void TestGetLocationInformationFromInputAsync_ValidInput_ReturnsJsonResponse()
        {
            List<UmbracoLocation> locations = LocationUtility.GetLocationInformationFromInputAsync("US").Result;
            Assert.IsNotNull(locations);
            Assert.IsTrue(locations[0].Latitude == 39.7837304);
            Assert.IsTrue(locations[0].Longitude == -100.445882);
        }

        [TestMethod]
        public void TestGetLocationInformationFromInputAsync_InvalidInput_ReturnsError()
        {
            List<UmbracoLocation> locations = LocationUtility.GetLocationInformationFromInputAsync(string.Empty).Result;
            Assert.IsNull(locations);
        }
    }
}
