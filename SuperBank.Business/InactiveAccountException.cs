namespace SuperBank.Business
{
    [Serializable]
    public class InactiveAccountException : Exception
    {
        public InactiveAccountException()
        {
        }

        public InactiveAccountException(string? message) : base(message)
        {
        }

        public InactiveAccountException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}