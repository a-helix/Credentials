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

        public object selectedParameter(string parameter)
        {

            if (dict.ContainsKey(parameter))
            {
                return dict[parameter];
            }
            throw new Exception(String.Format("{0} parameter doesn't exhist.", parameter));
        }
    }
}
