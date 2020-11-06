using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Credentials
{
    public class JsonStringContent : IContent
    {
        Dictionary<string, object> dict;

        public JsonStringContent(string json)
        {
            dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }

        public object Value(string parameter)
        {

            if (dict.ContainsKey(parameter))
            {
                return dict[parameter];
            }
            throw new Exception($"{parameter} parameter doesn't exhist.");
        }

        public bool Contains(string parameter)
        {
            if (dict.ContainsKey(parameter))
            {
                return true;
            }
            return false;
        }
    }
}
