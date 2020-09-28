using NUnit.Framework;
using Credentials;
using System;

namespace Credentials.Tests
{
    public class JsonContentTest
    {
        JsonFileContent test = new JsonFileContent("testJsonContent.json");

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
            JsonFileContent not_exhist;
            Assert.Throws<Exception>(() => not_exhist = new JsonFileContent("not_exhist.json"), 
                "not_exhist.json file doesn't exhist");
        }
    }
}
