using Microsoft.VisualStudio.TestTools.UnitTesting;
using Credentials;
using System;

namespace CredentialsTests

{
    [TestClass]
    public class JsonDeserializerTest
    {
        static JsonDeserializer deserializer = new JsonDeserializer();
        Parameters etalon = deserializer.deserialize<Parameters>("testParameters.json");
        Parameters test;
        Parameters notExhist;

        [TestMethod]
        public void deserializePositiveTest()
        {
            test = new Parameters("127.0.0.1", "88", "test");
            bool check = etalon.Equals(test);
            Assert.IsTrue(check);
            Assert.AreEqual(etalon.GetHashCode(), test.GetHashCode());
        }

        [TestMethod]
        public void deserializeNegativeTest()
        {
            test = new Parameters("192.168.0.1", "88", "test");
            Assert.IsFalse(etalon.Equals(test));
            Assert.AreNotEqual(etalon.GetHashCode(), test.GetHashCode());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "not_exhist.json file doesn't exhist")]
        public void deserializeFileNotFoundTest()
        {
            notExhist = deserializer.deserialize<Parameters>("not_exhist.json");
        }
    }
}
