namespace Garage.Model.Garage;

/// <summary>
/// A custom domain exception used to describe incorrect
/// garage state.
/// </summary>
public class InvalidGarageStateException : InvalidOperationException
{
    public InvalidGarageStateException() { }

    public InvalidGarageStateException(string message) : base(message) { }

    public InvalidGarageStateException(string message, Exception innerException)
        : base(message, innerException) { }
}
