
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

internal interface IGarageService<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    uint Capacity { get; }
    bool IsFullGarage();
    bool IsOccupiedLot(ParkingLotType parkingLot);
    bool TryAddVehicle(uint parkingLotId, VehicleType vehicle, out ParkingLotType? parkingLot);
    bool TryRemoveVehicle(uint parkingLotId, out VehicleType? vehicle);
}
