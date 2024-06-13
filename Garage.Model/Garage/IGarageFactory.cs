using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public interface IGarageFactory<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    IGarage<ParkingLotType, VehicleType> CreateGarage(
        HashSet<ParkingLotType> parkingLots);

    IGarage<ParkingLotType, VehicleType> CreateGarage(uint capacity);
}
