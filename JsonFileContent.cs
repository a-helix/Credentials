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
                throw new Exception(String.Format("{0} file doesn't exhist", jsonPath));
            string jsonContent;
            using (StreamReader r = new StreamReader(jsonPath))
            {
                jsonContent = r.ReadToEnd();
            }
            dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonContent);
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
