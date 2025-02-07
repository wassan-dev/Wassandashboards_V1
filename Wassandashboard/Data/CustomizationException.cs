namespace Wassandashboard.Data
{
    public class CustomizationException : Exception
    {
        public string ErrorCode { get; }

        public CustomizationException(string message) : base(message)
        {
        }

        public CustomizationException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public CustomizationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
