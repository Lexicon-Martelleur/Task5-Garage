namespace Garage.Model.Vehicle;

public interface IBus : IVehicle
{
    uint StandingPassengerCapacity { get; }

    uint SeatingPassengerCapacity { get; }
}
