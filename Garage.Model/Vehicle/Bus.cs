namespace Garage.Model.Vehicle;

public class Bus : Vehicle, IBus
{
    private readonly uint _standingPassengerCapacity;

    private readonly uint _seatingPassengerCapacity;

    public Bus(
        RegistrationNumber registrationNumber,
        uint standingPassengerCapacity,
        uint seatingPassengerCapacity,
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
        _seatingPassengerCapacity = seatingPassengerCapacity;
        _standingPassengerCapacity = standingPassengerCapacity;
    }

    public uint StandingPassengerCapacity => _standingPassengerCapacity;

    public uint SeatingPassengerCapacity => _seatingPassengerCapacity;
}
