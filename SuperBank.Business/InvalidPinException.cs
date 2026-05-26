namespace SuperBank.Business
{
    [Serializable]
    public class InvalidPinException : Exception
    {
        public InvalidPinException()
        {
        }

        public InvalidPinException(string? message) : base(message)
        {
        }

        public InvalidPinException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}