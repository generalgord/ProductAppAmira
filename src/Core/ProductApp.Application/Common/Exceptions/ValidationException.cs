namespace ProductApp.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : this("Validation error occured") { }

        public ValidationException(string? message) : base(message) { }

        public ValidationException(Exception? innerException) : this(innerException?.Message) { }
    }
}
