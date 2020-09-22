using Microsoft.VisualStudio.TestTools.UnitTesting;
using Credentials;
using System;

namespace CredentialsTests
{
    [TestClass]
    public class JsonContentTest
    {
        JsonContent test = new JsonContent("testJsonContent.json");

        [TestMethod]
        public void selectedParameterPositiveTest()
        {
            Assert.AreEqual(test.selectedParameter("family_name"), "Escobar");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "witnesses parameter doesn't exhist")]
        public void selectedParameterNegativeTest()
        {
            object not_exhist = test.selectedParameter("witnesses");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "not_exhist.json file doesn't exhist")]
        public void selectedParameterDoesNotExhistTest()
        {
            JsonContent not_exhist = new JsonContent("not_exhist.json");
        }
    }
}
