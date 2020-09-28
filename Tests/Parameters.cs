namespace Credentials.Tests
{
    public class Parameters
    {
        private string host { get; }
        private string port { get; }
        private string description { get; }

        public Parameters(string host, string port, string description)
        {
            this.host = host;
            this.port = port;
            this.description = description;
        }

        public override int GetHashCode()
        {
            int sum = 0;
            string parameters = host + port + description;
            sum += stringCharSum(parameters);
            return sum;
        }

        public override bool Equals(object compare)
        {
            Parameters sample = compare as Parameters;
            if (host.Equals(sample.host) &&
                port.Equals(sample.port) &&
                description.Equals(sample.description))
                return true;
            return false;
        }

        private int stringCharSum(string str)
        {
            int sum = 0;
            char[] characters = str.ToCharArray();
            foreach (char i in characters)
                sum += (int) char.GetNumericValue(i);
            return sum;
        }
    }
}
