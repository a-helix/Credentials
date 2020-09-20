using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Credentials
{
    public static class ConfigHandler
    {
        public static Parameters deserialize(string jsonLocation)
        {
            JObject json = JObject.Parse(File.ReadAllText(jsonLocation));
            var values = json.ToObject<Dictionary<string, object>>();
            Parameters parameters = new Parameters(
                                    (string) getParameter(values, "host"),
                                    (string) getParameter(values, "port"),
                                    (string) getParameter(values, "description"),
                                    values);
            return parameters;
        }

        private static object getParameter(Dictionary<string, object> dict, string parameter)
        {
            if (dict.ContainsKey(parameter))
            {
                object output = dict[parameter];
                dict.Remove(parameter);
                return output;
            }
            throw new ArgumentException("{0} doesn't exhist.", parameter);
        }

    }
}
