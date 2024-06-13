
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

public class GarageService<ParkingLotType, VehicleType>(
    IGarage<ParkingLotType, VehicleType> garage
) :
    IGarageService<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    public uint Capacity => garage.Capacity;

    public bool IsFullGarage()
    {
        return garage.IsFullGarage();
    }

    public bool IsOccupiedLot(ParkingLotType parkingLot)
    {
        return garage.IsOccupiedLot(parkingLot);
    }

    public bool TryAddVehicle(
        uint parkingLotId,
        VehicleType vehicle,
        out ParkingLotType? parkingLot)
    {
        return garage.TryAddVehicle(parkingLotId, vehicle, out parkingLot);
    }


    public bool TryRemoveVehicle(uint parkingLotId, out VehicleType? vehicle)
    {
        return garage.TryRemoveVehicle(parkingLotId, out vehicle);
    }
}

