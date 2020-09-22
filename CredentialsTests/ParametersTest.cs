using Microsoft.VisualStudio.TestTools.UnitTesting;
using Credentials;


namespace CredentialsTests

{
    [TestClass]
    public class ParametersTest
    {
        Parameters etalon = new Parameters("127.0.0.1", "88", "test");
        Parameters positiveTest = new Parameters("127.0.0.1", "88", "test");
        Parameters negativeTest = new Parameters("192.168.0.1", "88", "test");


        [TestMethod]
        public void ParametersCOmparingPositiveTest()
        {
            Assert.IsTrue(etalon.Equals(positiveTest));
            Assert.AreEqual(etalon.GetHashCode(), positiveTest.GetHashCode());
        }

        [TestMethod]
        public void ParametersCOmparingNegativeTest()
        {
            Assert.IsFalse(etalon.Equals(negativeTest));
            Assert.AreNotEqual(etalon.GetHashCode(), negativeTest.GetHashCode());
        }
    }
}
