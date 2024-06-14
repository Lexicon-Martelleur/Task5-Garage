namespace Garage.Model.Garage;

public class InvalidGarageStateException : InvalidOperationException
{
    public InvalidGarageStateException() { }

    public InvalidGarageStateException(string message) : base(message) { }

    public InvalidGarageStateException(string message, Exception innerException)
        : base(message, innerException) { }
}
