namespace Credentials
{
    public interface IContent
    {
        public object Parameter(string parameter);
        public bool Contains(string parameter);
    }
}
