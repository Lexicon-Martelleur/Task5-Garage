
using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public class ParkingLot<VehicleType> : IParkingLot<VehicleType>
    where VehicleType : IVehicle
{
    private readonly uint _id;

    public uint ID
    {
        get => _id;
        init => _id = value;
    }

    public VehicleType? CurrentVehicle { get; set; }

    public string? VehicleRegistrationNumber => CurrentVehicle?.RegistrationNumber.Value;    

    public string? VehicleTypeName => CurrentVehicle?.Type;

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

    public override bool Equals(object? obj)
    {
        return Equals(obj as IParkingLot<VehicleType>);
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}
