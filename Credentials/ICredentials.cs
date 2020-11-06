namespace Credentials
{
    public interface ICredentials
    {
        public T Deserialize<T>(string jsonPath);
    }
}
