namespace Garage.Model.Vehicle;

internal interface IAirPlane : IVehicle
{
    uint WingSpan { get; }

    uint PassengerCapacity { get; }
}
