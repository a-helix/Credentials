using System;
using System.IO;
using NUnit.Framework;

namespace Credentials.Tests
{
    public class JsonDeserializerTest
    {
        static JsonDeserializer deserializer = new JsonDeserializer();
        static string path = Path.Join("Tests", "Configs", "ParametersTest.json");
        Parameters etalon = deserializer.deserialize<Parameters>(path);
        Parameters test;
        Parameters notExhist;

        [Test]
        public void deserializePositiveTest()
        {
            test = new Parameters("127.0.0.1", "88", "test");
            bool check = etalon.Equals(test);
            Assert.IsTrue(check);
            Assert.AreEqual(etalon.GetHashCode(), test.GetHashCode());
        }

        [Test]
        public void deserializeNegativeTest()
        {
            test = new Parameters("192.168.0.1", "88", "test");
            Assert.IsFalse(etalon.Equals(test));
            Assert.AreNotEqual(etalon.GetHashCode(), test.GetHashCode());
        }

        [Test]
        public void deserializeFileNotFoundTest()
        {
            Assert.Throws<Exception>(() => notExhist = deserializer.deserialize<Parameters>("not_exhist.json"), 
                "not_exhist.json file doesn't exhist");
        }
    }
}
