namespace Credentials
{
    public interface IContent
    {
        public object Value(string parameter);
        public bool Contains(string parameter);
    }
}
