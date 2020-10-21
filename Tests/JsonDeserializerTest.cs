using System;
using System.IO;
using NUnit.Framework;

namespace Credentials.Tests
{
    public class JsonDeserializerTest
    {
        static JsonDeserializer deserializer = new JsonDeserializer();
        static string path = Path.Join(Directory.GetCurrentDirectory(), "Tests", "Configs", "ParametersTest.json");
        Parameters etalon = deserializer.Deserialize<Parameters>(path);
        Parameters test;
        Parameters notExhist;

        [Test]
        public void deserializeTest()
        {
            test = new Parameters("127.0.0.1", "88", "test");
            bool check = etalon.Equals(test);
            Assert.IsTrue(check);
            Assert.AreEqual(etalon.GetHashCode(), test.GetHashCode());

            test = new Parameters("192.168.0.1", "88", "test");
            Assert.IsFalse(etalon.Equals(test));
            Assert.AreNotEqual(etalon.GetHashCode(), test.GetHashCode());

            Assert.Throws<Exception>(() => notExhist = deserializer.Deserialize<Parameters>("not_exhist.json"),
                                                                "not_exhist.json file doesn't exhist");
        }
    }
}
