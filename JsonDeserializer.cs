using System;
using System.IO;
using Newtonsoft.Json;

namespace Credentials
{
    public class JsonDeserializer : ICredentials
    {
        public T deserialize<T>(string jsonPath)
        {
            if (!File.Exists(jsonPath))
                throw new Exception(String.Format("{0} file doesn't exhist", jsonPath));
            string json;
            using (StreamReader r = new StreamReader(jsonPath))
            {
                json = r.ReadToEnd();
            }
                return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
