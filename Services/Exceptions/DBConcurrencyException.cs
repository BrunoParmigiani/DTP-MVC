namespace DTP.Services.Exceptions
{
    public class DBConcurrencyException : ApplicationException
    {
        public DBConcurrencyException(string message) : base(message)
        {
        }
    }
}
