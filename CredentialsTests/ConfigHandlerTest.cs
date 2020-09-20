using Microsoft.VisualStudio.TestTools.UnitTesting;
using Credentials;
using System.Collections.Generic;


namespace CredentialsTests

{
    [TestClass]
    public class ConfigHandlerTest
    {
        static string host = "127.0.0.1";
        static string port = "88";
        static string description = "test";
        static Dictionary<string, object> additionalParameters = new Dictionary<string, object>() {{ "version", "2.0" }};
        Parameters positiveControl = new Parameters(host, port, description, additionalParameters);
        Parameters etalon = ConfigHandler.deserialize("positive.json");
        Parameters negativeControl = new Parameters(host, "8888", description, additionalParameters);

        [TestMethod]
        public void deserializePositiveTest()
        {
            Assert.IsTrue(etalon.Equals(positiveControl));
            Assert.AreEqual(etalon.GetHashCode(), positiveControl.GetHashCode());
        }

        [TestMethod]
        public void deserializeNegativeTest()
        {
            Assert.IsFalse(etalon.Equals(negativeControl));
            Assert.AreNotEqual(etalon.GetHashCode(), negativeControl.GetHashCode());
        }
    }
}
