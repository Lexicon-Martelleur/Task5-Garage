namespace Garage.Model.Garage;

public class InvalidGarageStateException : InvalidOperationException
{
    internal InvalidGarageStateException() { }

    internal InvalidGarageStateException(string message) : base(message) { }

    internal InvalidGarageStateException(string message, Exception innerException)
        : base(message, innerException) { }
}
