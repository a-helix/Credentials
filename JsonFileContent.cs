using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Credentials
{
    public class JsonFileContent : IContent
    {
        Dictionary<string, object> dict;

        public JsonFileContent(string jsonPath)
        {
            if (!File.Exists(jsonPath))
                throw new Exception($"{jsonPath} file doesn't exhist");
            string jsonContent;
            using (StreamReader r = new StreamReader(jsonPath))
            {
                jsonContent = r.ReadToEnd();
            }
            dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
        }

        public object Parameter(string parameter)
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
