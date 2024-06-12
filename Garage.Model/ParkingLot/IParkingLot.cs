using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public interface IParkingLot : IEquatable<IParkingLot>
{
    uint ID { get; init; }
    IVehicle? CurrentVehicle { get; set; }
}
