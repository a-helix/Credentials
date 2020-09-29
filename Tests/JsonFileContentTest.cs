using System;
using System.IO;
using NUnit.Framework;

namespace Credentials.Tests
{
    public class JsonFileContentTest
    {
        static string path = Path.Join("Tests", "Configs", "JsonFileContentTest.json");
        JsonFileContent test = new JsonFileContent(path);

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
