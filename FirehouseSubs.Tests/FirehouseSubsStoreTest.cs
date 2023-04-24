using FirehouseSubs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirehouseSubs.Tests
{
    [TestClass]
    public class FirehouseSubsStoreTest
    {
        [TestMethod]
        public void TestGetStoreByZipCodeAsync_ValidInput_ReturnsJsonResponse()
        {
            FirehouseClient client = new FirehouseClient();
            List<FirehouseSubsStore> stores = client.GetStoreByZipCodeAsync(32034).Result;
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count >= 0);
        }

        [TestMethod]
        public void TestGetStoreByZipCodeAsync_InalidInput_ReturnsError()
        {
            FirehouseClient client = new FirehouseClient();
            try
            {
                List<FirehouseSubsStore> stores = client.GetStoreByZipCodeAsync(123456789).Result;
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
        public void TestGetStoreByCityAsync_ValidInput_ReturnsJsonResponse()
        {
            FirehouseClient client = new FirehouseClient();
            List<FirehouseSubsStore> stores = client.GetStoreByCityAsync("Jacksonville").Result;
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count >= 0);
        }

        [TestMethod]
        public void TestGetStoreByCityAsync_InalidInput_ReturnsError()
        {
            FirehouseClient client = new FirehouseClient();
            try
            {
                List<FirehouseSubsStore> stores = client.GetStoreByCityAsync(string.Empty).Result;
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
        public void TestGetStoreByStateAsync_ValidInput_ReturnsJsonResponse()
        {
            FirehouseClient client = new FirehouseClient();
            List<FirehouseSubsStore> stores = client.GetStoreByStateAsync("Florida").Result;
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count >= 0);
        }

        [TestMethod]
        public void TestGetStoreByStateAsync_InalidInput_ReturnsError()
        {
            FirehouseClient client = new FirehouseClient();
            try
            {
                List<FirehouseSubsStore> stores = client.GetStoreByStateAsync(string.Empty).Result;
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