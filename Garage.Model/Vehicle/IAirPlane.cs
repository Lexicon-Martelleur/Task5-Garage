namespace Garage.Model.Vehicle;

internal interface IAirplane : IVehicle
{
    uint WingSpan { get; }

    uint PassengerCapacity { get; }
}
