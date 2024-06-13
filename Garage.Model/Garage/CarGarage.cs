using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;
using System;
using System.Collections;
namespace Garage.Model.Garage;

internal class CarGarage : IGarage<CarParkingLot, ICar>
{
    private readonly uint _capacity;

    private CarParkingLot[] _parkingLots;

    public CarGarage(
        uint capacity,
        IParkingLotFactory<CarParkingLot, ICar> parkingLotFactory)
    {
        _capacity = capacity;
        _parkingLots = GarageUtility<CarParkingLot, ICar>.CreateParkingLots(capacity, parkingLotFactory);
    }

    public CarGarage(HashSet<CarParkingLot> parkingLots)
    {
        _capacity = (uint)parkingLots.Count;
        _parkingLots = parkingLots.ToArray();
    }

    public uint Capacity => _capacity;

    public CarParkingLot[] ParkingLots {
        get => _parkingLots;
        init => _parkingLots = value;
    }

    public bool IsFullGarage()
    {
        var occupiedParkingLots = this.Where(parkingLot => parkingLot.CurrentVehicle != null);
        return occupiedParkingLots.Count() == Capacity;
    }

    public bool IsOccupiedLot(CarParkingLot parkingLot)
    {
        return parkingLot.CurrentVehicle != null;
    }

    public bool TryAddVehicle(uint parkingLotId, ICar vehicle, out CarParkingLot? parkingLot)
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

    public bool TryRemoveVehicle(uint parkingLotId, out ICar? vehicle)
    {
        var parkingLot = this.FirstOrDefault(item => item.ID == parkingLotId);
        if (parkingLot == null)
        {
            vehicle = default;
            return false;
        }

        vehicle = parkingLot.CurrentVehicle;
        if (vehicle != null)
        {
            parkingLot.CurrentVehicle = default;
            return true;
        }

        return false;
    }


    public IEnumerator<CarParkingLot> GetEnumerator()
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
