
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

internal class GarageService(IGarage<IParkingLot> garage) : IGarageService<IParkingLot>
{
    public uint Capacity => garage.Capacity;

    public bool IsFullGarage()
    {
        return garage.IsFullGarage();
    }

    public bool IsOccupiedLot(IParkingLot parkingLot)
    {
        return garage.IsOccupiedLot(parkingLot);
    }

    public bool TryAddVehicle(uint parkingLotId, IVehicle vehicle, out IParkingLot? parkingLot)
    {
        return garage.TryAddVehicle(parkingLotId, vehicle, out parkingLot);
    }

    public bool TryRemoveVehicle(uint parkingLotId, out IVehicle? vehicle)
    {
        return garage.TryRemoveVehicle(parkingLotId, out vehicle);
    }
}
