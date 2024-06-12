
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

internal interface IGarageService<ParkingLotType>
    where ParkingLotType : IParkingLot
{
    uint Capacity { get; }
    bool IsFullGarage();
    bool IsOccupiedLot(ParkingLotType parkingLot);
    bool TryAddVehicle(uint parkingLotId, IVehicle vehicle, out ParkingLotType? parkingLot);
    bool TryRemoveVehicle(uint parkingLotId, out IVehicle? vehicle);
}
