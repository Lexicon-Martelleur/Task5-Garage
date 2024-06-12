using Garage.Model.Vehicle;
using System.Collections;

namespace Garage.Model.Garage;

public class Garage<ParkingLotType> : IEnumerable<ParkingLotType> 
    where ParkingLotType : IParkingLot, new()
{
    private readonly uint _capacity;

    private ParkingLotType[] _parkingLots; 

    public Garage(uint capacity)
    {
        _capacity = capacity;
        _parkingLots = GarageUtility<ParkingLotType>.CreateParkingLots(capacity);
    }

    public Garage(HashSet<ParkingLotType> parkingLots)
    {
        _capacity = (uint)parkingLots.Count;
        _parkingLots = parkingLots.ToArray();
    }

    public uint Capacity => _capacity;

    public ParkingLotType[] ParkingLots {
        get => _parkingLots;
        init => _parkingLots = value;
    }

    public bool TryAddVehicle(uint parkingLotId, IVehicle vehicle, out ParkingLotType? parkingLot)
    {
        parkingLot = this.FirstOrDefault(item => item.ID  == parkingLotId);
        if (parkingLot == null)
        {
            return false;
        }
        return true;
    }

    public bool TryRemoveVehicle(uint parkingLotId, out IVehicle? vehicle)
    {
        vehicle = this.FirstOrDefault(item => item.ID == parkingLotId)?.CurrentVehicle;
        return vehicle != null;
    }

    public IEnumerator<ParkingLotType> GetEnumerator()
    {
        for (int i = 0; i < _capacity; i++)
        {
            if (ParkingLots[i] != null)
            {
                yield return ParkingLots[i];
            } 
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
