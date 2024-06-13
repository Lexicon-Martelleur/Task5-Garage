
using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public interface IParkingLotFactory<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    ParkingLotType Create(uint id);
}
