using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Model.Garage;

internal static class GarageUtility<ParkingLotType>
    where ParkingLotType : IParkingLot, new()
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

    internal static ParkingLotType[] CreateParkingLots(uint capacity)
    {
        var parkingLots = new ParkingLotType[capacity]; 

        for (int i = 0; i < capacity; i++) 
        {
            var id = GetUniqueID();
            parkingLots[i] = new ParkingLotType() {
                ID = id,
            };
        }
        return parkingLots;
    } 
}
