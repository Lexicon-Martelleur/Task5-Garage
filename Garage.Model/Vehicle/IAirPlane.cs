namespace Garage.Model.Vehicle;
public interface IAirplane : IVehicle
{
    uint WingSpan { get; }

    uint PassengerCapacity { get; }
}
