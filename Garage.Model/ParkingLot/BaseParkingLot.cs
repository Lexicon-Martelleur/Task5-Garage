
using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public abstract class BaseParkingLot<VehicleType> : IParkingLot<VehicleType>
    where VehicleType : IVehicle
{
    private readonly uint _id;

    public uint ID
    {
        get => _id;
        init => _id = value;
    }

    public VehicleType? CurrentVehicle { get; set; }

    public bool Equals(IParkingLot<VehicleType>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _id == other.ID;
    }

    public abstract override bool Equals(object? obj);

    public abstract override int GetHashCode();
}
