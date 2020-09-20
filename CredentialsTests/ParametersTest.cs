using Microsoft.VisualStudio.TestTools.UnitTesting;
using Credentials;
using System;


namespace CredentialsTests

{
    [TestClass]
    public class ParametersTest
    {
        string test;
        Parameters parameters = ConfigHandler.deserialize("positive.json");


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Host is not specified")]
        public void GetHostNegativeTest()
        {
            ConfigHandler.deserialize("negative.json");
        }

        [TestMethod]
        public void GetHostPositiveTest()
        {
            test = "127.0.0.1";
            Assert.AreEqual(test, parameters.getHost());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Port is not specified")]
        public void GetPortNegativeTest()
        {
            ConfigHandler.deserialize("negative.json");
        }

        [TestMethod]
        public void GetPortPositiveTest()
        {
            test = "88";
            Assert.AreEqual(test, parameters.getPort());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Description is not specified")]
        public void GetDescriptionNegativeTest()
        {
            ConfigHandler.deserialize("negative.json");
        }

        [TestMethod]
        public void GetDescriptionPositiveTest()
        {
            test = "test";
            Assert.AreEqual(test, parameters.getDescription());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Random is not specified")]
        public void GeAdditionalParameterTest()
        {
            Assert.AreEqual(test, parameters.getAdditionalParameter("Random"));
        }

        [TestMethod]
        public void GetAdditionalParameterPositiveTest()
        {
            test = "2.0";
            Assert.AreEqual(test, parameters.getAdditionalParameter("version"));
        }
    }
}
