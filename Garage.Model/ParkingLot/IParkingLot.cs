using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public interface IParkingLot<VehicleType> : IEquatable<IParkingLot<VehicleType>>
{
    uint ID { get; init; }
    VehicleType? CurrentVehicle { get; set; }

}
