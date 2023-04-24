using FirehouseSubs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirehouseSubs.Tests
{
    [TestClass]
    public class FirehouseSubsStoreTest
    {
        [TestMethod]
        public void TestGetStoresByZipCodeAsync_ValidInput_ReturnsJsonResponse()
        {
            FirehouseClient client = new FirehouseClient();
            List<FirehouseSubsStore> stores = client.GetStoresByZipCodeAsync(32034).Result;
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count >= 0);
        }

        [TestMethod]
        public void TestGetStoresByZipCodeAsync_InalidInput_ReturnsError()
        {
            FirehouseClient client = new FirehouseClient();
            try
            {
                List<FirehouseSubsStore> stores = client.GetStoresByZipCodeAsync(123456789).Result;
                Assert.IsNotNull(stores);
            }
            catch (Exception ex) 
            {
                Assert.IsInstanceOfType(ex, typeof(AggregateException));
                Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
                Assert.IsTrue(ex.InnerException.Message.Equals("No stores found with the entered information"));
            }
        }


        [TestMethod]
        public void TestGetStoresByCityAsync_ValidInput_ReturnsJsonResponse()
        {
            FirehouseClient client = new FirehouseClient();
            List<FirehouseSubsStore> stores = client.GetStoresByCityAsync("Jacksonville").Result;
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count >= 0);
        }

        [TestMethod]
        public void TestGetStoresByCityAsync_InalidInput_ReturnsError()
        {
            FirehouseClient client = new FirehouseClient();
            try
            {
                List<FirehouseSubsStore> stores = client.GetStoresByCityAsync(string.Empty).Result;
                Assert.IsNotNull(stores);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AggregateException));
                Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
                Assert.IsTrue(ex.InnerException.Message.Equals("No stores found with the entered information"));
            }
        }

        [TestMethod]
        public void TestGetStoresByStateAsync_ValidInput_ReturnsJsonResponse()
        {
            FirehouseClient client = new FirehouseClient();
            List<FirehouseSubsStore> stores = client.GetStoresByStateAsync("Florida").Result;
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count >= 0);
        }

        [TestMethod]
        public void TestGetStoresByStateAsync_InalidInput_ReturnsError()
        {
            FirehouseClient client = new FirehouseClient();
            try
            {
                List<FirehouseSubsStore> stores = client.GetStoresByStateAsync(string.Empty).Result;
                Assert.IsNotNull(stores);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AggregateException));
                Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
                Assert.IsTrue(ex.InnerException.Message.Equals("Entered state does not exist"));
            }
        }
    }
}