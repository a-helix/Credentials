using System;
using System.Collections.Generic;
using System.Linq;

namespace Credentials 
{
    public class Parameters : ICredentials
    {
        private string host;
        private string port;
        private string description;
        private Dictionary<string, object> additionalParameters;

        public Parameters(string host, string port, string description, Dictionary<string, object> additionalParameters)
        {
            this.host = host;
            this.port = port;
            this.description = description;
            this.additionalParameters = additionalParameters;
        }

        public string getPort()
        {
            return port;
        }

        public string getHost()
        {
            return host;
        }

        public string getDescription()
        {
            return description;
        }

        public object getAdditionalParameter(string parameter)
        {
            if (additionalParameters.ContainsKey(parameter))
                return additionalParameters[parameter];
            throw new ArgumentException(@"{0} is not specified.", parameter);
        }

        public override int GetHashCode()
        {
            int sum = 0;
            sum += calculateCharSum(host);
            sum += calculateCharSum(port);
            sum += calculateCharSum(description);
            foreach (var kvp in additionalParameters)
            {
                sum += calculateCharSum(kvp.Key);
                sum += calculateCharSum((string) kvp.Value);
            }    
                return sum;
        }

        public override bool Equals(object compare)
        {
            Parameters sample = compare as Parameters;

            if (host != sample.getHost() ||
                port != sample.getPort() ||
                description != sample.getDescription() ||
                additionalParameters.Count != sample.additionalParameters.Count)
                return false;
            foreach (var i in additionalParameters)
            {
                if (!sample.additionalParameters.ContainsKey(i.Key) || (string) i.Value != (string) sample.additionalParameters[i.Key])
                    return false;
            }
            return true;
        }

        private int calculateCharSum(string str)
        {
            int sum = 0;
            char[] characters = str.ToCharArray();
            foreach (Char i in characters)
                sum += i;
            return sum;
        }
    }
}
