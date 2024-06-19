using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

/// <summary>
/// A utility class used to create unique ids for parking lots.
/// </summary>
/// <typeparam name="ParkingLotType">
/// A type parameter of <see cref="IParkingLot"/> type or its subclasses.
/// </typeparam>
/// <typeparam name="VehicleType">
/// A type parameter of <see cref="IVehicle"/> type or its subclasses.
/// </typeparam>
internal static class GarageUtility<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    private static readonly HashSet<uint> _IDs = [];

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

    internal static HashSet<ParkingLotType> CreateParkingLots(
        uint capacity,
        Func<uint, ParkingLotType> parkingLotCreator)
    {
        var parkingLots = new ParkingLotType[capacity];

        for (int i = 0; i < capacity; i++)
        {
            var id = GetUniqueID();
            parkingLots[i] = parkingLotCreator(id);
        }
        return parkingLots.ToHashSet();
    }
}
