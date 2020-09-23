using NUnit.Framework;
using Credentials;
using System;

namespace CredentialsTests
{
    public class JsonContentTest
    {
        JsonContent test = new JsonContent("testJsonContent.json");

        [Test]
        public void selectedParameterPositiveTest()
        {
            Assert.AreEqual(test.selectedParameter("family_name"), "Escobar");
        }

        [Test]
        public void selectedParameterNegativeTest()
        {
            object not_exhist;
            Assert.Throws<Exception>(() => not_exhist = test.selectedParameter("witnesses"),
               "witnesses parameter doesn't exhist");
        }

        [Test]
        public void selectedParameterDoesNotExhistTest()
        {
            JsonContent not_exhist;
            Assert.Throws<Exception>(() => not_exhist = new JsonContent("not_exhist.json"), 
                "not_exhist.json file doesn't exhist");
        }
    }
}
