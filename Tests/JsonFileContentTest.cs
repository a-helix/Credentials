﻿using System;
using System.IO;
using NUnit.Framework;

namespace Credentials.Tests
{
    public class JsonFileContentTest
    {
        static string path = Path.Join(Directory.GetCurrentDirectory(), "Tests", "Configs", "JsonFileContentTest.json");
        JsonFileContent test = new JsonFileContent(path);

        [Test]
        public void ParameterTest()
        {
            Assert.AreEqual(test.Parameter("family_name"), "Escobar");

            object not_real;
            Assert.Throws<Exception>(() => not_real = test.Parameter("witnesses"),
               "witnesses parameter doesn't exhist");

            JsonFileContent not_exhist;
            Assert.Throws<Exception>(() => not_exhist = new JsonFileContent("not_exhist.json"),
                "not_exhist.json file doesn't exhist");
        }
    }
}
