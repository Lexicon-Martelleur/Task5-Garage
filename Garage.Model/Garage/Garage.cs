using Garage.Model.Base;
using Garage.Model.ParkingLot;
using Garage.Model.Service;
using Garage.Model.Vehicle;
using System.Collections;
using System.Linq;

namespace Garage.Model.Garage;

public class Garage<VehicleType> :
    IGarage<VehicleType>
    where VehicleType : IVehicle
{
    private readonly uint _capacity;

    private Address _address;

    private string _garageDescription;

    private IParkingLot<VehicleType>[] _parkingLots;

    private static readonly HashSet<uint> _IDs = [];

    public Garage(
        HashSet<IParkingLot<VehicleType>> parkingLots,
        Address address,
        string description)
    {
        _capacity = (uint)parkingLots.Count;
        _address = address;
        _garageDescription = description;
        _parkingLots = [.. parkingLots];
    }

    public string VehicleTypeName()
    {
        return this.GetType()
            .GetGenericArguments()
            .FirstOrDefault()?.Name ?? "IVehicle";
    }

    public uint Capacity => _capacity;

    public Address Address => _address;

    public string Description => _garageDescription;
  

    public IParkingLot<VehicleType>[] ParkingLots
    {
        get => _parkingLots;
        init => _parkingLots = value;
    }
  
    public bool TryAddVehicle(uint parkingLotId, VehicleType vehicle, out IParkingLot<VehicleType>? parkingLot)
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

    public bool IsOccupiedLot(IParkingLot<VehicleType> parkingLot)
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

    public IEnumerator<IParkingLot<VehicleType>> GetEnumerator()
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

    public IParkingLot<VehicleType> AddVehicle(uint parkingLotId, VehicleType vehicle)
    {
        var addCarResult = TryAddVehicle(parkingLotId, vehicle, out IParkingLot<VehicleType>? parkingLot);

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

    public bool Equals(IGarage<VehicleType>? other)
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
        return Equals(obj as IGarage<VehicleType>);
    }

    public override int GetHashCode()
    {
        return Address.GetHashCode();
    }

    public IEnumerable<GroupedVehicle> GroupVehiclesByVehicleType()
    {
        return this
            .Where(lot => lot.CurrentVehicle != null)
            .Select(lot => new { VehicleType = lot.CurrentVehicle!.Type })
            .GroupBy(item => item.VehicleType)
            .Select(group => new GroupedVehicle(group.Key, group.Count()));
    }
}
