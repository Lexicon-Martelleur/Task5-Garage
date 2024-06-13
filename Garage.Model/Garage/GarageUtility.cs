using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

internal static class GarageUtility<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    private static readonly HashSet<uint> _IDs = new();

    internal static uint GetUniqueID()
    {
        Random random = new();
        uint id;
        do
        {
            id = (uint)random.Next(1, int.MaxValue);
        } while (!_IDs.Add(id));
        return id;
    }

    internal static ParkingLotType[] CreateParkingLots(
        uint capacity, IParkingLotFactory<ParkingLotType,
        VehicleType> factory)
    {
        var parkingLots = new ParkingLotType[capacity];

        for (int i = 0; i < capacity; i++)
        {
            var id = GetUniqueID();
            parkingLots[i] = factory.Create(id);
        }
        return parkingLots;
    }
}
