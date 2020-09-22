using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Credentials
{
    public class JsonContent
    {
        Dictionary<string, object> dict;

        public JsonContent(string jsonPath)
        {
            if (!File.Exists(jsonPath))
                throw new Exception(String.Format("{0} file doesn't exhist", jsonPath));
            string json;
            using (StreamReader r = new StreamReader(jsonPath))
            {
                json = r.ReadToEnd();
            }
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
