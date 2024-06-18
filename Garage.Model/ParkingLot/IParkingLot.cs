using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public interface IParkingLot<VehicleType> :
    IParkingLotInfo,
    IEquatable<IParkingLot<VehicleType>>
    where VehicleType : IVehicle
{
    VehicleType? CurrentVehicle { get; set; }
}
