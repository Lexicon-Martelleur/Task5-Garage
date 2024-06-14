
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

public class GarageService<VehicleType>(
    IGarage<IParkingLot<VehicleType>, VehicleType> garage
) :
    IGarageService<IParkingLot<VehicleType>, VehicleType>
    where VehicleType : IVehicle
{
    public uint Capacity => garage.Capacity;

    public bool IsFullGarage()
    {
        return garage.IsFullGarage();
    }

    public bool IsOccupiedLot(IParkingLot<VehicleType> parkingLot)
    {
        return garage.IsOccupiedLot(parkingLot);
    }

    public bool TryAddVehicle(
        uint parkingLotId,
        VehicleType vehicle,
        out IParkingLot<VehicleType>? parkingLot)
    {
        return garage.TryAddVehicle(parkingLotId, vehicle, out parkingLot);
    }

    public bool TryRemoveVehicle(uint parkingLotId, out VehicleType? vehicle)
    {
        return garage.TryRemoveVehicle(parkingLotId, out vehicle);
    }

    public IParkingLot<VehicleType> AddVehicle(uint parkingLotId, VehicleType vehicle)
    {
        return garage.AddVehicle(parkingLotId, vehicle);
    }

    public VehicleType RemoveVehicle(uint parkingLotId)
    {
        return garage.RemoveVehicle(parkingLotId);
    }
}

