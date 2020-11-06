using NUnit.Framework;

namespace Credentials.Tests

{
    public class ParametersTest
    {
        Parameters etalon = new Parameters("127.0.0.1", "88", "test");
        Parameters positiveTest = new Parameters("127.0.0.1", "88", "test");
        Parameters negativeTest = new Parameters("192.168.0.1", "88", "test");


        [Test]
        public void ParametersCOmparingTest()
        {
            Assert.IsTrue(etalon.Equals(positiveTest));
            Assert.AreEqual(etalon.GetHashCode(), positiveTest.GetHashCode());

            Assert.IsFalse(etalon.Equals(negativeTest));
            Assert.AreNotEqual(etalon.GetHashCode(), negativeTest.GetHashCode());
        }
    }
}
