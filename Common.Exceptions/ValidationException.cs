namespace Common.Exceptions;

public class ValidationException: Exception
{
    public ValidationException()
    {
    }
    
    public ValidationException(string? message) : base(message)
    {
    }

    public ValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public IEnumerable<string> Errors { get; init; } = [];
}