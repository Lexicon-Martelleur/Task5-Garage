using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;
using System.Collections;

namespace Garage.Model.Garage;

public class UniversalGarage<ParkingLotType, VehicleType> :
    IGarage<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    private readonly uint _capacity;

    private string _address;

    private string _garageType;

    private ParkingLotType[] _parkingLots;

    private static readonly HashSet<uint> _IDs = new();

    public UniversalGarage(
        HashSet<ParkingLotType> parkingLots,
        string address,
        string garageType)
    {
        _capacity = (uint)parkingLots.Count;
        _address = address;
        _garageType = garageType;
        _parkingLots = parkingLots.ToArray();
    }

    public uint Capacity => _capacity;

    public string Address {
        get => _address;
        set => _address = value;
    }

    public string Description {
        get => _garageType;
        set => _garageType = value;
    }

    public ParkingLotType[] ParkingLots
    {
        get => _parkingLots;
        init => _parkingLots = value;
    }
 
    public bool TryAddVehicle(uint parkingLotId, VehicleType vehicle, out ParkingLotType? parkingLot)
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

    public bool TryRemoveVehicle(uint parkingLotId, out VehicleType? vehicle)
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

    public ParkingLotType AddVehicle(uint parkingLotId, VehicleType vehicle)
    {
        var addCarResult = TryAddVehicle(parkingLotId, vehicle, out ParkingLotType? parkingLot);

        if (!addCarResult || parkingLot == null)
        {
            throw new InvalidGarageStateException($"Could not add car to parking lot id: {parkingLotId}.");
        }
        return parkingLot;
    }

    public VehicleType RemoveVehicle(uint parkingLotId)
    {
        var removeCarResult = TryRemoveVehicle(parkingLotId, out VehicleType? vehicle);

        if (!removeCarResult || vehicle == null)
        {
            throw new InvalidGarageStateException($"Could not remove car from parking lot id: {parkingLotId}");
        }
        return vehicle;
    }

    public bool Equals(IGarage<ParkingLotType, VehicleType>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _address == other.Address;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as IGarage<ParkingLotType, VehicleType>);
    }

    public override int GetHashCode()
    {
        return Address.GetHashCode();
    }
}
