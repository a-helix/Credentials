namespace Credentials
{
    public interface ICredentials
    {
        public T deserialize<T>(string jsonPath);
    }
}
