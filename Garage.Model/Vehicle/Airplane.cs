namespace Garage.Model.Vehicle;

public class Airplane : Vehicle, IAirplane
{
    private readonly uint _wingSpan;

    private readonly uint _passengerCapacity;

    public Airplane(
        RegistrationNumber registrationNumber,
        uint wingSpan,
        uint passengerCapacity,
        string color,
        PowerSource powerSource,
        uint weight,
        Dimension dimension
    ) : base(
        registrationNumber,
        color,
        powerSource,
        weight,
        dimension
    )
    {
        _passengerCapacity = passengerCapacity;
        _wingSpan = wingSpan;
    }

    public uint WingSpan => throw new NotImplementedException();

    public uint PassengerCapacity => throw new NotImplementedException();
}
