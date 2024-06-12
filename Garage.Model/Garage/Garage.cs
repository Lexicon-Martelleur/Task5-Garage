using Garage.Model.Vehicle;
using System.Collections;

namespace Garage.Model.Garage;

public class Garage<ParkingLotType> : IEnumerable<ParkingLotType> 
    where ParkingLotType : IParkingLot
{
    private readonly int _capacity;

    private ParkingLotType[] _parkingLots; 

    public Garage(ParkingLotType[] parkingLots)
    {
        _capacity = parkingLots.Length;
        _parkingLots = parkingLots;
    }

    public int Capacity => _capacity;

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
            if (_parkingLots[i] != null)
            {
                yield return _parkingLots[i];
            } 
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
