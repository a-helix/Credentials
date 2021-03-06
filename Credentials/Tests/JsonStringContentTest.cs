﻿using System;
using NUnit.Framework;

namespace Credentials.Tests
{
    public class JsonStringContentTest
    {
        static string json = "{\"id\":\"1\"," +
                              "\"personal_name\":\"Pablo\"," +
                              "\"family_name\":\"Escobar\"," +
                              "\"date_of_birth\":\"01.12.1949\"}";
        JsonStringContent test = new JsonStringContent(json);

        [Test]
        public void ValueTest()
        {
            Assert.AreEqual(test.Value("family_name"), "Escobar");

            object not_exhist;
            Assert.Throws<Exception>(() => not_exhist = test.Value("witnesses"),
               "witnesses parameter doesn't exhist");

            string wrongString = "Invalid string for JsonStringContent.";
            JsonStringContent invalid;
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(
                          () => invalid = new JsonStringContent(wrongString));
        }
    }
}
