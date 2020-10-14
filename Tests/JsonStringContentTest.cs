using System;
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
        public void ParameterPositiveTest()
        {
            Assert.AreEqual(test.Parameter("family_name"), "Escobar");
        }

        [Test]
        public void ParameterNegativeTest()
        {
            object not_exhist;
            Assert.Throws<Exception>(() => not_exhist = test.Parameter("witnesses"),
               "witnesses parameter doesn't exhist");
        }

        [Test]
        public void ParameterInvalidStringTest()
        {
            string wrongString = "Invalid string for JsonStringContent.";
            JsonStringContent invalid;
            Assert.Throws<Newtonsoft.Json.JsonReaderException>(
                          () => invalid = new JsonStringContent(wrongString));
        }
    }
}
