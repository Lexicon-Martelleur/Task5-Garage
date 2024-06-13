using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;
using System.Collections;

namespace Garage.Model.Garage;

public class UniversalGarage<ParkingLotType> : IGarage<ParkingLotType>
    where ParkingLotType : IParkingLot
{
    private readonly uint _capacity;

    private ParkingLotType[] _parkingLots;

    public UniversalGarage(uint capacity, IParkingLotFactory<ParkingLotType> parkingLotFactory)
    {
        _capacity = capacity;
        _parkingLots = GarageUtility<ParkingLotType>.CreateParkingLots(capacity, parkingLotFactory);
    }

    public UniversalGarage(HashSet<ParkingLotType> parkingLots)
    {
        _capacity = (uint)parkingLots.Count;
        _parkingLots = parkingLots.ToArray();
    }

    public uint Capacity => _capacity;

    public ParkingLotType[] ParkingLots
    {
        get => _parkingLots;
        init => _parkingLots = value;
    }

    public bool TryAddVehicle(uint parkingLotId, IVehicle vehicle, out ParkingLotType? parkingLot)
    {
        parkingLot = this.FirstOrDefault(item => item.ID == parkingLotId);
        if (parkingLot == null)
        {
            return false;
        }

        if (IsOccupiedLot(parkingLot) || IsFullGarage())
        {
            return false;
        }

        parkingLot.CurrentVehicle = vehicle;
        return true;
    }

    public bool IsFullGarage()
    {
        var occupiedParkingLots = this.Where(parkingLot => parkingLot.CurrentVehicle != null);
        return occupiedParkingLots.Count() == Capacity;
    }

    public bool IsOccupiedLot(ParkingLotType parkingLot)
    {
        return parkingLot.CurrentVehicle != null;
    }

    public bool TryRemoveVehicle(uint parkingLotId, out IVehicle? vehicle)
    {
        var parkingLot = this.FirstOrDefault(item => item.ID == parkingLotId);
        if (parkingLot == null)
        {
            vehicle = null;
            return false;
        }

        vehicle = parkingLot.CurrentVehicle;
        if (vehicle != null)
        {
            parkingLot.CurrentVehicle = null;
            return true;
        }

        return false;
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
