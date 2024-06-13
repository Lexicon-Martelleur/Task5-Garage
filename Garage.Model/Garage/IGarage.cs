using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage
{
    public interface IGarage<ParkingLotType, VehicleType> : IEnumerable<ParkingLotType>
        where VehicleType : IVehicle
        where ParkingLotType : IParkingLot<VehicleType>
    {
        uint Capacity { get; }
        ParkingLotType[] ParkingLots { get; init; }
        bool IsFullGarage();
        bool IsOccupiedLot(ParkingLotType parkingLot);
        bool TryAddVehicle(uint parkingLotId, VehicleType vehicle, out ParkingLotType? parkingLot);
        bool TryRemoveVehicle(uint parkingLotId, out VehicleType? vehicle);
    }
}