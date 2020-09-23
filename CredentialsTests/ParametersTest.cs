using NUnit.Framework;

namespace CredentialsTests

{
    public class ParametersTest
    {
        Parameters etalon = new Parameters("127.0.0.1", "88", "test");
        Parameters positiveTest = new Parameters("127.0.0.1", "88", "test");
        Parameters negativeTest = new Parameters("192.168.0.1", "88", "test");


        [Test]
        public void ParametersCOmparingPositiveTest()
        {
            Assert.IsTrue(etalon.Equals(positiveTest));
            Assert.AreEqual(etalon.GetHashCode(), positiveTest.GetHashCode());
        }

        [Test]
        public void ParametersCOmparingNegativeTest()
        {
            Assert.IsFalse(etalon.Equals(negativeTest));
            Assert.AreNotEqual(etalon.GetHashCode(), negativeTest.GetHashCode());
        }
    }
}
